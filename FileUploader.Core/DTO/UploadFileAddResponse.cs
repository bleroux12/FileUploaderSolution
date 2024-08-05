using FileUploader.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace FileUploader.Core.DTO
{
    public class UploadFileAddResponse
    {
        [Required]
        public string? FileNumber { get; set; }
        public string? InvoiceNumber { get; set; }
        public DateTime? InvoiceDate { get; set; }        
        public int NumberOfDocs { get; set; }
        [ValidateNever]
        public List<SelectListItem> Clients { get; set; }
        [Required]
        public Guid ClientID { get; set; }
    }
}
