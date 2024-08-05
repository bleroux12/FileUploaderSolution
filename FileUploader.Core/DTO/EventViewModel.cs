using FileUploader.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileUploader.Core.DTO
{
    public class EventViewModel
    {
        public Guid FileID { get; set; }
        public IEnumerable<Event> Events { get; set; }
        public string? InvoiceNumber { get; set; }
        public DateTime? InvoiceDate { get; set; }
        public int NumberOfDocs { get; set; }
        public string FileNumber { get; set; }
    }
}
