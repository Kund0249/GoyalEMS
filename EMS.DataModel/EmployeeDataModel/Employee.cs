using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.DataModel.EmployeeDataModel
{
   public class Employee
    {
        public int EmpCode { get; set; }
        public string EmpName { get; set; }
        public string Gender { get; set; }
        public string EmailId { get; set; }
        public int Salary { get; set; }
        public DateTime DOB { get; set; }
        public DateTime DOJ { get; set; }
        public int DepartmentId { get; set; }
        public string ProfileImage { get; set; }
    }
}
