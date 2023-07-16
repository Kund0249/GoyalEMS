using System;
using System.Collections.Generic;
using EMS.DataModel.DepartmentDataModel;

namespace EMS.DataProcessor.DepartmentDataProcessor
{
   public class DEPARTMENTPROCESSOR : IDEPARTMENTPROCESSOR
    {
      private readonly IDEPARTMENTREPOSITORY _DB;
        public DEPARTMENTPROCESSOR()
        {
            _DB = new DEPARTMENTREPOSITORY();
        }

        public List<Department> GetDepartments
        {
            get
            {
                List<Department> departments = new List<Department>();
                foreach (var item in _DB.GetDepartments)
                {
                    departments.Add(new Department()
                    {
                        DeptId = item.DeptId,
                        DepartmentName = item.DepartmentName
                    });
                }
                return departments;
            }
        }

        public string Save(Department department, out int StatusCode)
        {
            DataModel.DepartmentDataModel.Department department1 = new DataModel.DepartmentDataModel.Department()
            {
                DeptId = department.DeptId,
                DepartmentName = department.DepartmentName
            };
            return _DB.Save(department1,out StatusCode);
        }
    }
}
