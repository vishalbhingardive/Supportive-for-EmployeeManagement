using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeServices.Model
{
    public class Employees
    {
        [Key]
       public int EmployeeId { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }
        public string  Department { get; set; }
        public  DateTime DateOfJoining { get; set; }
        public string Email { get; set; }
        public int JobId { get; set; }


    }
}
