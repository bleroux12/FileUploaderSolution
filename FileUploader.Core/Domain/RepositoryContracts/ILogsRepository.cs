using FileUploader.Core.Domain.Entities;
using FileUploader.Core.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileUploader.Core.Domain.RepositoryContracts
{
    public interface ILogsRepository
    {
        Task<IEnumerable<Log>> GetLogsAsync();
        Task<PaginatedList<Log>> GetPagedLogsAsync(int pageNumber, int pageSize);
    }
}
