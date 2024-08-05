using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileUploader.Core.Domain.Entities
{
    public class Document
    {
        public Guid ID { get; set; }
        public string DocumentFileName { get; set; }
        public string OutputFileName { get; set; }
        public string FileExtension { get; set; }
        public string DocumentTypeCode { get; set; }
        [ForeignKey("DocumentTypeCode")]
        public DocumentType DocumentType { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public DateTime ModifiedDateTime { get; set; }
        public bool IsDeleted { get; set; }

        public ICollection<FileDocument> FileDocuments { get; set; }

    }
}
