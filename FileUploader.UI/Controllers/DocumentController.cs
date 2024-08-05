using FileUploader.Core.Domain.Entities;
using FileUploader.Core.Domain.RepositoryContracts;
using FileUploader.Core.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Claims;

namespace FileUploader.UI.Controllers
{
    [Authorize]
    [Route("[controller]")]
    public class DocumentController : Controller
    {
        private readonly IDocumentsRepository _dr;
        private readonly IUploadFileRepository _ufr;

        public DocumentController(IDocumentsRepository dr, IUploadFileRepository ufr)
        {
            _dr = dr;
            _ufr = ufr;
        }

        [Route("[action]")]
        public async Task<IActionResult> List(Guid fileID, string? invoiceNumber, 
            DateTime? invoiceDate, int numberOfDocs, string fileNumber)
        {
            List<DocumentDTO> documents = (List<DocumentDTO>)await _dr.GetDocumentsByUploadFileID(fileID);
            var documentTypes = await _dr.GetAllDocumentTypes();
            var model = new FileDocumentResponse
            {
                FileID = fileID,
                InvoiceDate = invoiceDate,
                InvoiceNumber = invoiceNumber,
                NumberOfDocs = numberOfDocs,
                FileNumber = fileNumber,
                Documents = documents,
                AttachDocument = new AttachDocumentResponse { FileID = fileID },
                DocumentTypes = documentTypes.Select(c => new SelectListItem
                {
                    Value = c.Code,
                    Text = c.Description
                }).ToList()
            };

            return View(model);
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<IActionResult> Attach(AttachDocumentResponse model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
                    var username = User.Identity?.Name;
                    await _dr.UploadDocument(model);
                    await _ufr.UpdateUploadFileDocumentCount(1, model.FileID);
                    await _ufr.AddEvent(model.FileID, $"Document {model.File.FileName} added by ", userId, username);
                    TempData["Message"] = "File uploaded successfully.";
                    TempData["MessageType"] = "success";
                    model.NumberOfDocs += 1;
                }
                catch (Exception ex)
                {
                    TempData["Message"] = $"File upload failed: {ex.Message}";
                    TempData["MessageType"] = "danger";
                }

                return RedirectToAction("List", new { fileId = model.FileID, 
                    invoiceNumber = model.InvoiceNumber, invoiceDate = model.InvoiceDate, 
                    numberOfDocs = model.NumberOfDocs });
            }

            List<DocumentDTO> documents = (List<DocumentDTO>)await _dr.GetDocumentsByUploadFileID(model.FileID);
            var documentTypes = await _dr.GetAllDocumentTypes();
            var viewModel = new FileDocumentResponse
            {
                FileID = model.FileID,
                InvoiceNumber = model.InvoiceNumber,
                InvoiceDate = model.InvoiceDate,
                NumberOfDocs = model.NumberOfDocs,
                Documents = documents,
                AttachDocument = new AttachDocumentResponse { FileID = model.FileID },
                DocumentTypes = documentTypes.Select(c => new SelectListItem
                {
                    Value = c.Code,
                    Text = c.Description
                }).ToList()
            };

            return View("List", viewModel);

        }

        [Route("[action]")]
        [HttpGet]
        public async Task<IActionResult> Download(Guid documentID, Guid fileID, string? invoiceNumber, 
            DateTime? invoiceDate, int numberOfDocs)
        {
            var existingDocument = await _dr.GetDocumentByDocumentID(documentID);
            if (existingDocument == null)
            {
                TempData["Message"] = "Document not found!";
                TempData["MessageType"] = "danger";
                return RedirectToAction("List", new { fileID = fileID, invoiceNumber = invoiceNumber, 
                    invoiceDate = invoiceDate, numberOfDocs = numberOfDocs});
            }

            byte[] documentBytes = System.IO.File.ReadAllBytes(existingDocument.DocumentFileName);
            return File(documentBytes, "APPLICATION/octet-stream", existingDocument.OutputFileName);
        }

        [Route("[action]")]
        [HttpGet]
        public async Task<IActionResult> Delete(Guid documentID, Guid fileID, string documentName)
        {
            try
            {
                var userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
                var username = User.Identity?.Name;
                var exisitingFileDocument = 
                    await _dr.GetFileDocumentByFileIDAndDocumentID(fileID, documentID);
                if (exisitingFileDocument != null && exisitingFileDocument.DocumentStatusCode != "SNT")
                {
                    var result = await _dr.DeleteDocument(documentID, fileID);
                    if (result)
                    {
                        await _ufr.UpdateUploadFileDocumentCount(-1, fileID);
                        await _ufr.AddEvent(exisitingFileDocument.FileID, $"Document {documentName} deleted by ", userId, username);
                        TempData["Message"] = "Document deleted successfully.";
                        TempData["MessageType"] = "success";
                    }
                    else
                    {
                        TempData["Message"] = "Cannot delete document.";
                        TempData["MessageType"] = "danger";
                    }
                }
                else if (exisitingFileDocument != null)
                {
                    TempData["Message"] = "Cannot delete document, document has already been sent.";
                    TempData["MessageType"] = "danger";
                }
                else
                {
                    TempData["Message"] = "Cannot delete document, document not found.";
                    TempData["MessageType"] = "danger";
                }
            }
            catch (Exception ex)
            {
                TempData["Message"] = $"File deletion failed: {ex.Message}.";
                TempData["MessageType"] = "danger";
            }
            
            return RedirectToAction("List", new { fileID = fileID });
        }
    }
}
