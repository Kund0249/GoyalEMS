using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.DataProcessor.DepartmentDataProcessor
{
    public class DepartmentModel
    {
        public DepartmentModel()
        {

        }
        public DepartmentModel(int total)
        {
            TotalItem = total;
        }
        public int DeptId { get; set; }
        private string _DepartmentName { get; set; }

        public string DepartmentName { 
            get { return _DepartmentName; }
            set
            {
                if (!(string.IsNullOrEmpty(value) && string.IsNullOrWhiteSpace(value)))
                    _DepartmentName = value;
                else
                    throw new Exception("The value for the property DepartmentName is not valid!");
            }
        }

        public int TotalItem { get;}
    }
}
