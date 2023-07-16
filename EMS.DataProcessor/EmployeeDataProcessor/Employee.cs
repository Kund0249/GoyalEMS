using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.DataProcessor.EmployeeDataProcessor
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

        public static EMS.DataModel.EmployeeDataModel.Employee Convert(Employee employee)
        {
            return new DataModel.EmployeeDataModel.Employee()
            {
                EmpCode = employee.EmpCode,
                DepartmentId = employee.DepartmentId,
                DOB = employee.DOB,
                DOJ = employee.DOJ,
                EmailId = employee.EmailId,
                EmpName = employee.EmpName,
                Gender = employee.Gender,
                ProfileImage = employee.ProfileImage,
                Salary = employee.Salary
            };
        }
    }
}
