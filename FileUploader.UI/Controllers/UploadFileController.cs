using FileUploader.Core.Domain.Entities;
using FileUploader.Core.Domain.RepositoryContracts;
using FileUploader.Core.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OfficeOpenXml;
using System.Security.Claims;

namespace FileUploader.UI.Controllers
{
    [Authorize]
    [Route("[controller]")]
    public class UploadFileController : Controller
    {
        private readonly IUploadFileRepository _ufr;
        private readonly IClientsRepository _cr;
        private readonly ILogger<UploadFileController> _logger;

        public UploadFileController(IUploadFileRepository ufr, IClientsRepository cr, ILogger<UploadFileController> logger)
        {
            _ufr = ufr;
            _cr = cr;
            _logger = logger;
        }

        [Route("/")]
        [Route("[action]")]
        public async Task<IActionResult> Dashboard(int pageNumber = 1, int pageSize = 3)
        {
            var paginatedFiles = await _ufr.GetPagedFilesAsync(pageNumber, pageSize);

            var files = new UploadFileListViewModel
            {
                UploadFiles = paginatedFiles
            };

            return View(files);
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> Add()
        {
            var clients = await _cr.GetAllClients();
            var uploadFileAddResponse = new UploadFileAddResponse
            {
                Clients = clients.Select(c => new SelectListItem
                {
                    Value = c.ID.ToString(),
                    Text = c.ClientName
                }).ToList()
            };

            return View(uploadFileAddResponse);
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> Add(UploadFileAddResponse uploadFileAddResponse)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var uploadFile = new UploadFile
            {
                FileNumber = uploadFileAddResponse.FileNumber,
                InvoiceNumber = uploadFileAddResponse.InvoiceNumber,
                InvoiceDate = uploadFileAddResponse.InvoiceDate,
                ClientID = uploadFileAddResponse.ClientID,
                NumberOfDocs = uploadFileAddResponse.NumberOfDocs,
                CreatedDateTime = DateTime.Now,
                FileStatusCode = "NEW",
                IsDeleted = false
            };

            if (await _ufr.GetUploadFileByFilenumber(uploadFile.FileNumber) != null)
            {
                ViewBag.Error = "File number already exists.";
                var clients = await _cr.GetAllClients();
                uploadFileAddResponse = new UploadFileAddResponse
                {
                    Clients = clients.Select(c => new SelectListItem
                    {
                        Value = c.ID.ToString(),
                        Text = c.ClientName
                    }).ToList()
                };
                return View(uploadFileAddResponse);
            }

            var userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var username = User.Identity?.Name;

            await _ufr.AddFile(uploadFile);
            await _ufr.AddEvent(uploadFile.ID, $"File {uploadFile.FileNumber} added by ", userId, username);

            return RedirectToAction("Dashboard", "UploadFile");
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> Edit(Guid id)
        {
            UploadFile? file = await _ufr.GetUploadFileByID(id);            
            if (file != null)
            {
                var filestatus = await _ufr.GetUploadFileStatus(file.FileStatusCode);
                var clients = await _cr.GetAllClients();                
                var uploadFileEditResponse = new UploadFileEditResponse
                {
                    ID = id,
                    FileNumber = file.FileNumber,
                    InvoiceNumber = file.InvoiceNumber,
                    InvoiceDate = file.InvoiceDate,
                    ClientID = file.ClientID,
                    Clients = clients.Select(c => new SelectListItem
                    {
                        Value = c.ID.ToString(),
                        Text = c.ClientName,
                        Selected = c.ID == file.ClientID
                    }).ToList(),
                    NumberOfDocs = file.NumberOfDocs,
                    CreatedDateTime = file.CreatedDateTime,
                    FileStatusDescription = filestatus.Description
                };
                return View(uploadFileEditResponse);
            }

            TempData["Message"] = "File not found.";
            TempData["MessageType"] = "danger";
            return RedirectToAction("Dashboard");
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> Edit(UploadFileEditResponse uploadFileEditResponse)
        {
            var uploadFile = new UploadFile
            {
                ID = uploadFileEditResponse.ID,
                FileNumber = uploadFileEditResponse.FileNumber,
                InvoiceNumber = uploadFileEditResponse.InvoiceNumber,
                InvoiceDate = uploadFileEditResponse.InvoiceDate,
                ClientID = uploadFileEditResponse.ClientID,
                ModifiedDateTime = DateTime.Now
            };

            var updatedUploadFile = await _ufr.UpdateUploadFile(uploadFile);

            if (updatedUploadFile != null)
            {
                var userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
                var username = User.Identity?.Name;
                await _ufr.AddEvent(uploadFileEditResponse.ID, $"File {uploadFileEditResponse.FileNumber} modified by ", userId, username);
                TempData["Message"] = "File updated successfully.";
                TempData["MessageType"] = "success";
            }
            else
            {
                TempData["Message"] = "Unable update file. File not found.";
                TempData["MessageType"] = "danger";
            }

            return RedirectToAction("Edit", "UploadFile", new { id = uploadFile.ID });
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> Delete(Guid id, string fileNumber)
        {
            var deletedFile = await _ufr.DeleteUploadFile(id);
                        
            var userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var username = User.Identity?.Name;
            await _ufr.AddEvent(id, $"File {fileNumber} deleted by ", userId, username);

            TempData["Message"] = deletedFile.Message;
            TempData["MessageType"] = deletedFile.Type;

            return RedirectToAction("Dashboard", "UploadFile");
        }

        [HttpGet]
        [Route("[action]")]
        public IActionResult UploadFilesViaExcel()
        {
            return View();
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> UploadFilesViaExcel(IFormFile excelFile)
        {
            if (excelFile == null || excelFile.Length == 0)
            {
                ViewBag.ErrorMessage = "Please select an xlsx file";
                return View();
            }

            if (!Path.GetExtension(excelFile.FileName).Equals(".xlsx", StringComparison.OrdinalIgnoreCase))
            {
                ViewBag.ErrorMessage = "Unsupported file. 'xlsx file is expected'";
                return View();
            }

            MemoryStream ms = new MemoryStream();
            await excelFile.CopyToAsync(ms);
            int filesInserted = 0;

            using (ExcelPackage excel = new ExcelPackage(ms))
            {
                ExcelWorksheet ws = excel.Workbook.Worksheets["Files"];
                int rowCount = ws.Dimension.Rows;

                for(int row = 2; row <= rowCount; row++)
                {
                    DateTime invoiceDate;
                    string? cell1Value = Convert.ToString(ws.Cells[row, 1].Value);
                    string? cell2Value = Convert.ToString(ws.Cells[row, 2].Value);
                    DateTime? cell3Value;
                    if (ws.Cells[row, 3].Value != null && DateTime.TryParse(ws.Cells[row, 3].Value.ToString(), out invoiceDate))
                    {
                        cell3Value = invoiceDate;
                    }
                    else
                    {
                        cell3Value = null;
                    }                    
                    string? cell4Value = Convert.ToString(ws.Cells[row, 4].Value);

                    if (!string.IsNullOrEmpty(cell1Value) && !string.IsNullOrEmpty(cell4Value))
                    {
                        var client = await _cr.GetClientByClientName(cell4Value);
                        if (client != null 
                            && await _ufr.GetUploadFileByFilenumber(cell1Value) == null)
                        {
                            UploadFile file = new UploadFile()
                            {
                                FileNumber = cell1Value,
                                InvoiceNumber = cell2Value,
                                InvoiceDate = cell3Value,
                                ClientID = client.ID,
                                FileStatusCode = "NEW",
                                CreatedDateTime = DateTime.Now,
                                ModifiedDateTime = DateTime.Now,
                                IsDeleted = false
                            };

                            await _ufr.AddFile(file);

                            var userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
                            var username = User.Identity?.Name;
                            await _ufr.AddEvent(file.ID, $"File {file.FileNumber} added by ", userId, username);
                            
                            filesInserted++;
                        }
                    }
                }
            }

            ViewBag.FilesInserted = filesInserted;

            return RedirectToAction("Dashboard", "UploadFile");
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> Send(Guid fileID, string invoiceNumber, 
            DateTime invoiceDate, int numberOfDocs, string fileNumber)
        {
            string message = "";
            string type = "danger";
            if (invoiceNumber != null && invoiceDate != DateTime.MinValue && numberOfDocs > 0)
            {
                var response = await _ufr.SendFile(fileID);
                message = response.Message;
                type = response.Type;
            }
            else if (numberOfDocs == 0)
            {
                message = "No documents attached.";
            }
            else
            {
                message = "Please ensure that invoice number and invoice date are populated before " +
                    "sending the file";
            }
            TempData["Message"] = message;
            TempData["MessageType"] = type;

            var userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var username = User.Identity?.Name;
            if (type == "success")
            {
                await _ufr.AddEvent(fileID, $"File {fileNumber} queued for sending by ", userId, username);
            }
            return RedirectToAction("Edit", "UploadFile", new { id = fileID});
        }
    }
}
