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

                SqlConnection con = new SqlConnection(ConnectionString);
                SqlCommand cmd = new SqlCommand("select * from tblDepartment", con);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                adapter.Fill(dt);

                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dt.Rows)
                        {
                            departments.Add(new Department()
                            { DeptId = Convert.ToInt32(dr["DeptId"]), DepartmentName = dr["DepartmentName"].ToString() });
                        }
                        //departments.Add(new Department() { DeptId = 1,DepartmentName="A"})
                    }
                }

                return departments;
            }
        }

        public Department GetDepartment(int DepartmentId)
        {
            Department departments = null;

            SqlConnection con = new SqlConnection(ConnectionString);
            SqlCommand cmd = new SqlCommand("select * from tblDepartment where DeptId = " + DepartmentId, con);

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            adapter.Fill(dt);

            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    departments = new Department()
                    {
                        DeptId = Convert.ToInt32(dt.Rows[0]["DeptId"]),
                        DepartmentName = dt.Rows[0]["DepartmentName"].ToString()
                    };
                    return departments;
                }
            }

            return departments;
        }

        public bool Remove(int DepartmentID)
        {
            SqlConnection con = new SqlConnection(ConnectionString);
            SqlCommand cmd = new SqlCommand("delete from tblDepartment where DeptId = " + DepartmentID, con);

            con.Open();
            int row = cmd.ExecuteNonQuery();
            con.Close();

            if (row > 0)
                return true;
            else
                return false;

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

        public string Update(Department department, out int StatusCode)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("spUpdatetDepartment", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@DepartmentName", department.DepartmentName);
                cmd.Parameters.AddWithValue("@DepartmentId", department.DeptId);

                DataTable table = new DataTable();
                SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                dataAdapter.Fill(table);


                string Message = string.Empty;
                if (table.Rows.Count > 0)
                {
                    StatusCode = Convert.ToInt32(table.Rows[0]["StatusCode"]);
                    Message = table.Rows[0]["Message"].ToString();
                }
                else
                {
                    StatusCode = 500;
                    Message = "There is some proble while processing this Request!";
                }
                return Message;
            }
        }
    }
}
