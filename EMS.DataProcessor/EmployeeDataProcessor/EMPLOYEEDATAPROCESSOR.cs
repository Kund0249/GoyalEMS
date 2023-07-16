using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EMS.DataModel.EmployeeDataModel;

namespace EMS.DataProcessor.EmployeeDataProcessor
{
   public class EMPLOYEEDATAPROCESSOR : IEMPLOYEEDATAPROCESSOR
    {
       private readonly IEMPLOYEEREPOSITORY _DB;
        public EMPLOYEEDATAPROCESSOR()
        {
            _DB = new EMPLOYEEREPOSITORY();
        }
        public string Save(Employee employee, out int StatusCode)
        {
           return _DB.Save(Employee.Convert(employee), out StatusCode);
        }
    }
}
