using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.DataProcessor.DepartmentDataProcessor
{
   public interface IDEPARTMENTPROCESSOR
    {
        string Save(Department department, out int StatusCode);
        List<Department> GetDepartments { get; }
    }
}
