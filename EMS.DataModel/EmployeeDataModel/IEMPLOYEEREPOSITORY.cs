using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.DataModel.EmployeeDataModel
{
   public interface IEMPLOYEEREPOSITORY
    {
        string Save(Employee employee, out int StatusCode);
    }
}
