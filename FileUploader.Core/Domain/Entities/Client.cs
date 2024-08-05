using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileUploader.Core.Domain.Entities
{
    public class Client
    {
        [Key]
        public Guid ID { get; set; }
        public string ClientName { get; set; }
        public string FolderStructure { get; set; }
        public string FileNameStructure { get; set; }
        public string FTPServer { get; set; }
        public string FTPUsername { get; set; }
        public string FTPPassword { get; set; }
        public DateTime? CreatedDateTime { get; set; }
        public DateTime? ModifiedDateTime { get; set; }
        public bool IsDeleted { get; set; }
    }
}
