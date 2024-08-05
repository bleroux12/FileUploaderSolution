using FileUploader.Core.Domain.RepositoryContracts;
using FileUploader.Core.DTO;
using Microsoft.AspNetCore.Mvc;

namespace FileUploader.UI.Controllers
{
    public class EventController : Controller
    {
        private readonly IUploadFileRepository _ufr;

        public EventController(IUploadFileRepository ufr)
        {
            _ufr = ufr;
        }

        public async Task<IActionResult> List(Guid fileID, string invoiceNumber,
            DateTime invoiceDate, int numberOfDocs, string fileNumber)
        {
            var events = await _ufr.GetAllEvents(fileID);
            EventViewModel evm = new EventViewModel
            {
                FileID = fileID,
                Events = events,
                InvoiceNumber = invoiceNumber,
                InvoiceDate = invoiceDate,
                NumberOfDocs = numberOfDocs,
                FileNumber = fileNumber
            };

            return View(evm);
        }
    }
}
