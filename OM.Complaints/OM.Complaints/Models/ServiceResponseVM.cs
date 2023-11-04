using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OM.Complaints.Models
{
    public class ServiceResponseVM
    {
        public ServiceResponseVM()
        {
            Errors = new List<string>();
            Warnings = new List<string>();

        }

        public bool Success { get; set; }
        public List<string> Errors { get; set; }
        public List<string> Warnings { get; set; }
    }

    public class ServiceResponseVM<TViewModel> : ServiceResponseVM
    {
        public ServiceResponseVM() : base() { }

        public TViewModel Data { get; set; }

    }
}
