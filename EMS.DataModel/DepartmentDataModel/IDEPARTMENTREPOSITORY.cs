using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.DataModel.DepartmentDataModel
{
   public interface IDEPARTMENTREPOSITORY
    {
        string Save(Department department,out int StatusCode);

        string Update(Department department, out int StatusCode);
        List<Department> GetDepartments { get; }
        List<Department> GetDepartmentsByPageNumber(int pageNo = 1);
        Department GetDepartment(int DepartmentId);

        bool Remove(int DepartmentID);
    }
}
