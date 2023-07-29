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

        public List<DepartmentModel> GetDepartments
        {
            get
            {
                List<DepartmentModel> departments = new List<DepartmentModel>();

                List<Department> departmentlist = _DB.GetDepartments;

                foreach (var dept in departmentlist)
                {
                    departments.Add(new DepartmentModel()
                    {
                        DeptId = dept.DeptId,
                        DepartmentName = dept.DepartmentName
                    });
                }

                return departments;
            }
        }

        public DepartmentModel GetDepartment(int DepartmentId)
        {
            Department department = _DB.GetDepartment(DepartmentId);

            if (department != null)
            {
                return new DepartmentModel()
                {
                    DeptId = department.DeptId,
                    DepartmentName = department.DepartmentName
                };
            }
            return null;
        }

        public bool Remove(int DepartmentId)
        {
           return _DB.Remove(DepartmentId);
        }

        public string Save(DepartmentModel Model, out int StatusCode)
        {
            Department department = new Department()
            {
                DeptId = Model.DeptId,
                DepartmentName = Model.DepartmentName
            };

            if (department.DeptId == 0)
                return _DB.Save(department, out StatusCode);
            else
                return _DB.Update(department, out StatusCode);
        }
    }
}
