using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileUploader.Core.DTO
{
    public class ClientUpdateResponse
    {
        [Key]
        public Guid ID { get; set; }
        [Required]
        public string ClientName { get; set; }
        [Required]
        public string FolderStructure { get; set; }
        [Required]
        public string FileNameStructure { get; set; }
        [Required]
        public string FTPServer { get; set; }
        [Required]
        public string FTPUsername { get; set; }
        public string FTPPassword { get; set; }
        public DateTime? CreatedDateTime { get; set; }
        public DateTime? ModifiedDateTime { get; set; }
        public bool IsDeleted { get; set; }
    }
}
