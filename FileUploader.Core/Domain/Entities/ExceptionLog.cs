using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileUploader.Core.Domain.Entities
{
    public class ExceptionLog
    {
        public Guid ID { get; set; }
        public string Message { get; set; }
        public string? StackTrace { get; set; }
        public string EventType { get; set; }
        public string ApplicationName { get; set; }
        public DateTime CreatedDateTime { get; set; }
    }
}
