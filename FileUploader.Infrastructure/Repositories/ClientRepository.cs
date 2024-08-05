using FileUploader.Core.Domain.Entities;
using FileUploader.Core.Domain.RepositoryContracts;
using FileUploader.Core.DTO;
using FileUploader.Infrastructure.DbContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileUploader.Infrastructure.Repositories
{
    public class ClientRepository : IClientsRepository
    {
        private readonly FileUploadDbContext _db;

        public ClientRepository(FileUploadDbContext db)
        {
            _db = db;
        }

        public async Task<Client> AddClient(Client client)
        {
            _db.Client.Add(client);
            await _db.SaveChangesAsync();

            return client;
        }

        public async Task<Response> DeleteClient(Guid clientID)
        {
            Client? existingClient = await _db.Client.FirstOrDefaultAsync(temp => temp.ID == clientID &&
            temp.IsDeleted == false);

            if (existingClient == null)
            {
                return new Response
                {
                    Message = "Cannot delete client. Client not found.",
                    Type = "danger"
                };
            }

            //Check if there is at least undeleted file allocated to the client
            var file = await _db.UploadFiles.Where(uf => uf.ClientID == clientID && uf.IsDeleted == false)
                .FirstOrDefaultAsync();

            if (file != null)
            {
                return new Response
                {
                    Message = "Cannot delete client. There are active files assigned to this client",
                    Type = "danger"
                };
            }

            existingClient.IsDeleted = true;
            existingClient.ModifiedDateTime = DateTime.Now;
            await _db.SaveChangesAsync();
            return new Response
            {
                Message = "Client deleted successfully.",
                Type = "danger"
            };
        }

        public async Task<IEnumerable<Client>> GetAllClients()
        {
            return await _db.Client.Where(c => c.IsDeleted == false).ToListAsync();
        }

        public async Task<Client?> GetClientByID(Guid clientID)
        {
            return await _db.Client.Where(c => c.ID == clientID && c.IsDeleted == false)
                .FirstOrDefaultAsync();
        }

        public async Task<Client?> GetClientByClientName(string ClientName)
        {
            return await _db.Client.Where(c => c.ClientName == ClientName && c.IsDeleted == false)
                .FirstOrDefaultAsync();
        }

        public async Task<Client> UpdateClient(Client client)
        {
            Client? existingClient = await _db.Client.FirstOrDefaultAsync(temp => temp.ID == client.ID
            && temp.IsDeleted == false);

            if (existingClient == null)
            {
                return client;
            }

            existingClient.ClientName = client.ClientName;
            existingClient.FolderStructure = client.FolderStructure;
            existingClient.FTPServer = client.FTPServer;
            existingClient.FTPUsername = client.FTPUsername;
            if (!string.IsNullOrEmpty(client.FTPPassword))
            {
                existingClient.FTPPassword = client.FTPPassword;
            }
            existingClient.ModifiedDateTime = DateTime.Now;

            await _db.SaveChangesAsync();
            return existingClient;
        }
    }
}
