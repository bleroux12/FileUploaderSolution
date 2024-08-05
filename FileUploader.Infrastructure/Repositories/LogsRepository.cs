using FileUploader.Core.Domain.Entities;
using FileUploader.Core.Domain.RepositoryContracts;
using FileUploader.Core.DTO;
using FileUploader.Core.Helpers;
using FileUploader.Infrastructure.DbContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace FileUploader.Infrastructure.Repositories
{
    public class LogsRepository : ILogsRepository
    {
        private LogDbContext _db;

        public LogsRepository(LogDbContext db)
        {
            _db = db;
        }

        public async Task<IEnumerable<Log>> GetLogsAsync()
        {
            //Fetch the last 1000 records
            return await _db.ExceptionLogs.Where(e => e.ApplicationName == "FileUploaderWeb")
                .OrderByDescending(e => e.CreatedDateTime)
                .Select(e => new Log
                {
                    logMessage = e.Message,
                    EventType = e.EventType,
                    CreatedDateTime = e.CreatedDateTime,
                    ApplicationName = e.ApplicationName
                })
                .Take(1000)                
                .ToListAsync();
        }

        public async Task<PaginatedList<Log>> GetPagedLogsAsync(int pageNumber, int pageSize)
        {
            var query = _db.ExceptionLogs.Where(e => e.ApplicationName == "FileUploaderWeb")
                .OrderByDescending(e => e.CreatedDateTime)
                .Select(e => new Log
                {
                    logMessage = e.Message,
                    EventType = e.EventType,
                    CreatedDateTime = e.CreatedDateTime,
                    ApplicationName = e.ApplicationName
                })
            .Take(1000)
            .AsQueryable();

            return await PaginatedList<Log>.CreateAsync(query, pageNumber, pageSize);
        }
    }
}
