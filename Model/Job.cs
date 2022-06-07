using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeServices.Model
{
    public class Job
    {
        public int JobId { get; set; }
        public string Title { get; set; }
        public int NumberofPositions { get; set; }
        public string Location { get; set; }
        public int SalaryRange { get; set; }
    }
}
