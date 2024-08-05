using FileUploader.Core.Domain.Entities;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileUploader.Core.DTO
{
    public class FileDocumentResponse
    {
        public Guid FileID { get; set; }
        public string? InvoiceNumber { get; set; }
        public DateTime? InvoiceDate { get; set; }
        public int NumberOfDocs { get; set; }
        public string FileNumber { get; set; }
        public List<DocumentDTO> Documents { get; set; }
        public AttachDocumentResponse AttachDocument { get; set; }
        public string DocumentTypeCode { get; set; }
        [ValidateNever]
        public List<SelectListItem> DocumentTypes { get; set; }
    }
}
