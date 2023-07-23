using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.DataProcessor.DepartmentDataProcessor
{
   public interface IDEPARTMENTPROCESSOR
    {
        string Save(DepartmentModel department, out int StatusCode);
        List<DepartmentModel> GetDepartments { get; }

        DepartmentModel GetDepartment(int DepartmentId);
    }
}
