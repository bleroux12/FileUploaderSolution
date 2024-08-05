using FileUploader.Core.Domain.Entities;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileUploader.Core.DTO
{
    public class UploadFileEditResponse
    {
        [Key]
        public Guid ID { get; set; }
        [Required]
        public string? FileNumber { get; set; }
        public string? InvoiceNumber { get; set; }
        public DateTime? InvoiceDate { get; set; }
        public string FileStatusCode { get; set; }
        public string FileStatusDescription { get; set; }
        public int NumberOfDocs { get; set; }
        public DateTime? CreatedDateTime { get; set; }
        public DateTime? ModifiedDateTime { get; set; }
        [ValidateNever]
        public List<SelectListItem> Clients { get; set; }
        [Required]
        public Guid ClientID { get; set; }
    }
}
