using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.DataProcessor.DepartmentDataProcessor
{
  public  class Deptrepo2 : IDEPARTMENTPROCESSOR
    {
        public List<DepartmentModel> GetDepartments => throw new NotImplementedException();

        public DepartmentModel GetDepartment(int DepartmentId)
        {
            throw new NotImplementedException();
        }

        public string Save(DepartmentModel department, out int StatusCode)
        {
            throw new NotImplementedException();
        }
    }
}
