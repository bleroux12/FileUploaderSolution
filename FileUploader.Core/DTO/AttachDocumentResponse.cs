using FileUploader.Core.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileUploader.Core.DTO
{
    public class AttachDocumentResponse
    {
        public Guid FileID { get; set; }
        public string? InvoiceNumber { get; set; }
        public DateTime? InvoiceDate { get; set; }
        public int NumberOfDocs { get; set; }
        public IFormFile File { get; set; }
        public string DocumentTypeCode { get; set; }
        [ValidateNever]
        public List<SelectListItem> DocumentTypes { get; set; }
    }
}
