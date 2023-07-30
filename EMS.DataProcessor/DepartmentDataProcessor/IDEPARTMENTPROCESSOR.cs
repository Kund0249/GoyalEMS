using EMS.DataModel.DepartmentDataModel;
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

        List<DepartmentModel> GetDepartmentsByPageNumber(int pageNo = 1);

        DepartmentModel GetDepartment(int DepartmentId);

        bool Remove(int DepartmentId);
    }
}
