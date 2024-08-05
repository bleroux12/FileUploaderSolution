using FileUploader.Core.Domain.Entities;
using FileUploader.Core.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileUploader.Core.DTO
{
    public class UploadFileListViewModel
    {
        public PaginatedList<UploadFile> UploadFiles { get; set; }
        public int PageNumber => UploadFiles?.PageIndex ?? 1;
        public int PageSize => UploadFiles?.Count ?? 0;
        public int TotalItems => UploadFiles?.TotalItems ?? 0;
        public int TotalPages => (int)Math.Ceiling((double)TotalItems / TotalPages);
        public bool HasPreviousPage => UploadFiles?.HasPreviousPage ?? false;
        public bool HasNextPage => UploadFiles?.HasNextPage ?? false;
        public int FirstItemIndex => UploadFiles?.TotalPages == PageNumber ? TotalItems - UploadFiles.Count + 1 : (PageNumber - 1) * PageSize + 1;
        public int LastItemIndex => UploadFiles?.TotalPages == PageNumber ? TotalItems : Math.Min(PageNumber * PageSize, TotalItems);
    }
}
