using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileUploader.Core.Domain.Entities
{
    public class Event
    {
        public Guid ID { get; set; }
        public Guid FileID { get; set; }
        public string EventDescription { get; set; }
        public DateTime CreatedDateTime { get; set; } = DateTime.Now;
        public Guid UserID { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
