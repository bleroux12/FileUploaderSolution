using FileUploader.Core.Domain.RepositoryContracts;
using FileUploader.Core.DTO;
using Microsoft.AspNetCore.Mvc;

namespace FileUploader.UI.Controllers
{
    public class LogController : Controller
    {
        private readonly ILogsRepository _lr;

        public LogController(ILogsRepository lr)
        {
            _lr = lr;
        }

        public async Task<IActionResult> List(int pageNumber = 1, int pageSize = 9)
        {
            var pagedLogs = await _lr.GetPagedLogsAsync(pageNumber, pageSize);

            var logs = new LogListViewModel
            {
                Logs = pagedLogs,
            };

            return View(logs);
        }
    }
}
