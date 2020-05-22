using System;
using System.Collections.Generic; 
using System.Linq;
using System.Threading.Tasks;

namespace ToDo.API.Models 
{
    public class OutputModel
    {
        public string status { get; set; } // to inform the status of the operation in database
        public object data { get; set; } // the data that insert, retrieve, update or delete
        public string message { get; set; } //the message whether the operation is success or error
    } 
}