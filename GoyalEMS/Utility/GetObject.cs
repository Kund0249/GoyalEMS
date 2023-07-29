using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EMS.DataProcessor.DepartmentDataProcessor;
using EMS.DataProcessor.EmployeeDataProcessor;
namespace GoyalEMS.Utility
{
   public enum ObjectCollection
    {
        IDepartmentDataProcessor,
        IEmployeeDataProcessor
    };
   static public class GetObject
    {
        public static object Get(ObjectCollection @object)
        {
            switch (@object)
            {
                case ObjectCollection.IDepartmentDataProcessor:
                    return new DEPARTMENTPROCESSOR();
                case ObjectCollection.IEmployeeDataProcessor:
                    return new EMPLOYEEDATAPROCESSOR();
                default:
                    return null;
            }
        }
    }
}