using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileUploader.Core.Domain.Entities
{
    public class UploadFile
    {
        [Key]
        public Guid ID { get; set; }
        public string FileNumber { get; set; }
        public string? InvoiceNumber { get; set; }
        public DateTime? InvoiceDate { get; set; }
        public Guid ClientID { get; set; }
        [ForeignKey("ClientID")]
        public Client Client { get; set; }
        public int NumberOfDocs { get; set; }
        public DateTime? CreatedDateTime { get; set; }
        public DateTime? ModifiedDateTime { get; set; }
        public bool IsDeleted { get; set; }
        public string FileStatusCode { get; set; }

        public ICollection<FileDocument> FileDocuments { get; set; }
    }
}
