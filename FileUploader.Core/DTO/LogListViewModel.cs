using FileUploader.Core.Domain.Entities;
using FileUploader.Core.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileUploader.Core.DTO
{
    public class LogListViewModel
    {
        public PaginatedList<Log> Logs { get; set; }
        public int PageNumber => Logs?.PageIndex ?? 1;
        public int PageSize => Logs?.Count ?? 0;
        public int TotalItems => Logs?.TotalItems ?? 0;
        public bool HasPreviousPage => Logs?.HasPreviousPage ?? false;
        public bool HasNextPage => Logs?.HasNextPage ?? false;
        public int FirstItemIndex => Logs?.TotalPages == PageNumber ? TotalItems - Logs.Count + 1 : (PageNumber - 1) * PageSize + 1;
        public int LastItemIndex => Logs?.TotalPages == PageNumber ? TotalItems : Math.Min(PageNumber * PageSize, TotalItems);
    }
}
