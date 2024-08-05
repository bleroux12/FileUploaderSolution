using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileUploader.Core.Domain.Entities
{
    public class Log
    {
        public string logMessage { get; set; }
        public string EventType { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public string ApplicationName { get; set; }
    }
}
