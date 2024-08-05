using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileUploader.Core.Domain.Entities
{
    public class DocumentType
    {
        [Key]
        public string Code { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public bool IsDeleted { get; set; }
        public ICollection<Document> Documents { get; set; }
    }
}
