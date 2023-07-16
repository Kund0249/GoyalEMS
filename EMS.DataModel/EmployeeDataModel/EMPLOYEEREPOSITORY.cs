using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.DataModel.EmployeeDataModel
{
    public class EMPLOYEEREPOSITORY : IEMPLOYEEREPOSITORY
    {
        public string Save(Employee employee, out int StatusCode)
        {
            string Message = string.Empty;
            try
            {
                using (SqlConnection con = new SqlConnection("data source=.;database=EmployeeDB;trusted_connection=true"))
                {
                    SqlCommand cmd = new SqlCommand("spInsertEmployee", con);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@EmpName", employee.EmpName);
                    cmd.Parameters.AddWithValue("@Gender", employee.Gender);
                    cmd.Parameters.AddWithValue("@Email", employee.EmailId);
                    cmd.Parameters.AddWithValue("@Salary", employee.Salary);
                    cmd.Parameters.AddWithValue("@DOB", employee.DOB);
                    cmd.Parameters.AddWithValue("@DOJ", employee.DOJ);
                    cmd.Parameters.AddWithValue("@DepartmentId", employee.DepartmentId);

                    //con.Open();
                    //cmd.ExecuteNonQuery();
                    //con.Close();

                    DataTable table = new DataTable();
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);

                    dataAdapter.Fill(table);

                    StatusCode = 500;
                    
                    if (table.Rows.Count > 0)
                    {
                        StatusCode = Convert.ToInt32(table.Rows[0]["StatusCode"]);
                        Message = table.Rows[0]["Message"].ToString();
                    }
                    return Message;

                }

            }
            catch (Exception ex)
            {
                StatusCode = 500;
                Message = ex.Message;
            }
            return Message;
        }
    }
}
