using FileUploader.Core.Domain.Entities;
using FileUploader.Core.Domain.RepositoryContracts;
using FileUploader.Core.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FileUploader.UI.Controllers
{
    [Authorize]
    [Route("[controller]")]
    public class ClientController : Controller
    {
        private IClientsRepository _cr;

        public ClientController(IClientsRepository cr)
        {
            _cr = cr;
        }

        [Route("[action]")]
        public async Task<IActionResult> List()
        {
            var clients = await _cr.GetAllClients();
            return View(clients);
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> Edit(Guid id)
        {
            Client? client = await _cr.GetClientByID(id);
            if (client != null)
            {
                var clientUpdateResponse = new ClientUpdateResponse
                {
                    ID = id,
                    ClientName = client.ClientName,
                    FolderStructure = client.FolderStructure,
                    FileNameStructure = client.FileNameStructure,
                    FTPServer = client.FTPServer,
                    FTPUsername = client.FTPUsername,
                    FTPPassword = client.FTPPassword,
                    CreatedDateTime = client.CreatedDateTime
                };
                return View(clientUpdateResponse);
            }

            return View(null);
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> Edit(ClientUpdateResponse clientEditResponse)
        {
            var client = new Client();

            if (!string.IsNullOrEmpty(clientEditResponse.FTPPassword))
            {
                client = new Client
                {
                    ID = clientEditResponse.ID,
                    ClientName = clientEditResponse.ClientName,
                    FolderStructure = clientEditResponse.FolderStructure,
                    FileNameStructure = clientEditResponse.FileNameStructure,
                    FTPServer = clientEditResponse.FTPServer,
                    FTPUsername = clientEditResponse.FTPUsername,
                    FTPPassword = clientEditResponse.FTPPassword,
                    CreatedDateTime = clientEditResponse.CreatedDateTime,
                    ModifiedDateTime = DateTime.Now,
                    IsDeleted = clientEditResponse.IsDeleted
                };
            }
            else
            {
                client = new Client
                {
                    ID = clientEditResponse.ID,
                    ClientName = clientEditResponse.ClientName,
                    FolderStructure = clientEditResponse.FolderStructure,
                    FileNameStructure = clientEditResponse.FileNameStructure,
                    FTPServer = clientEditResponse.FTPServer,
                    FTPUsername = clientEditResponse.FTPUsername,
                    CreatedDateTime = clientEditResponse.CreatedDateTime,
                    ModifiedDateTime = DateTime.Now,
                    IsDeleted = clientEditResponse.IsDeleted
                };
            }            

            var updatedClient = await _cr.UpdateClient(client);

            if (updatedClient != null)
            {
                // Show success notification
            }
            else
            {
                // Show error notification
            }

            return RedirectToAction("List", "Client");
        }

        [HttpGet]
        [Route("[action]")]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> Add(ClientAddResponse clientAddResponse)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var client = new Client
            {
                ClientName = clientAddResponse.ClientName,
                FolderStructure = clientAddResponse.FolderStructure,
                FileNameStructure = clientAddResponse.FileNameStructure,
                FTPServer = clientAddResponse.FTPServer,
                FTPUsername = clientAddResponse.FTPUsername,
                FTPPassword = clientAddResponse.FTPPassword,
                CreatedDateTime = DateTime.Now,
                ModifiedDateTime = DateTime.Now,
                IsDeleted = false
            };

            await _cr.AddClient(client);

            return RedirectToAction("List", "Client");
        }

        [Route("[action]")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var deletedClient = await _cr.DeleteClient(id);

            TempData["Message"] = deletedClient.Message;
            TempData["MessageType"] = deletedClient.Type;

            return RedirectToAction("List", "Client");
        }
    }
}
