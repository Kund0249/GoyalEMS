using System;
using System.Data.SqlClient;
using System.Data;
using System.Collections.Generic;

namespace EMS.DataModel.DepartmentDataModel
{
    public class DEPARTMENTREPOSITORY : IDEPARTMENTREPOSITORY
    {
        private string ConnectionString;
        public DEPARTMENTREPOSITORY()
        {
            ConnectionString = "data source=.;database=EmployeeDB;trusted_connection=true";
        }

        public List<Department> GetDepartments
        {
            get
            {
                List<Department> departments = new List<Department>();
                using (SqlConnection con = new SqlConnection(ConnectionString))
                {
                    SqlCommand cmd = new SqlCommand("Select * from tblDepartment", con);
                    cmd.CommandType = System.Data.CommandType.Text;
                    DataTable table = new DataTable();
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                    dataAdapter.Fill(table);
                    string Message = string.Empty;
                    if (table.Rows.Count > 0)
                    {
                        foreach (DataRow row in table.Rows)
                        {
                            departments.Add(
                                new Department()
                                {
                                    DeptId = Convert.ToInt32(row["DeptId"]),
                                    DepartmentName = row["DepartmentName"].ToString()
                                });
                        }
                    }
                }
                return departments;
            }
        }

        public string Save(Department department, out int StatusCode)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("spInsertDepartment", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@DepartmentName", department.DepartmentName);
                //con.Open();
                //string Message = cmd.ExecuteScalar().ToString();
                //con.Close();
                //return Message;
                DataTable table = new DataTable();
                SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                dataAdapter.Fill(table);
                StatusCode = 500;
                string Message = string.Empty;
                if (table.Rows.Count > 0)
                {
                    StatusCode = Convert.ToInt32(table.Rows[0]["StatusCode"]);
                    Message = table.Rows[0]["Message"].ToString();
                }
                return Message;
            }
        }
    }
}
