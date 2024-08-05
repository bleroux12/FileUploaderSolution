using FileUploader.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileUploader.Core.DTO
{
    public class DocumentDTO
    {
        public Guid DocumentID { get; set; }
        public string DocumentTypeCode { get; set; }
        public string DocumentTypeDescription { get; set; }
        public string DocumentFileName { get; set; }
        public string OutputFileName { get; set; }
        public string FileExtension { get; set; }
        public DateTime CreatedDateTime { get; set; }

        public ICollection<FileDocument> FileDocuments { get; set; }
    }
}
