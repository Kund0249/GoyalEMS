using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace GoyalEMS.Admin
{
    public partial class BulkDepartmentInsert : System.Web.UI.Page
    {
        DataTable DepartmentTable;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {

            // AlertMessage = "toastr.error('" + Message + "'" + ",'Server Error'," + "{'positionClass' : 'toast-top-center'}" + ")";
            string AlertMessage = string.Empty;
            string Message = string.Empty;

            if (ViewState["tblDepartment"] != null)
                DepartmentTable = (DataTable)ViewState["tblDepartment"];
            else
                Message = "There is no record to insert into table!";

            if (DepartmentTable != null)
            {
                if (DepartmentTable.Rows.Count > 0)
                {
                    using (SqlConnection con = new SqlConnection("data source=.;database=EmployeeDB;trusted_connection=true"))
                    {
                        using (SqlBulkCopy bulkCopy = new SqlBulkCopy(con))
                        {
                            bulkCopy.DestinationTableName = "tblDepartment";
                            bulkCopy.ColumnMappings.Add("DepartmentName", "DepartmentName");

                            con.Open();

                            bulkCopy.WriteToServer(DepartmentTable);
                            Message = "Data inserted successfully!";
                        }
                    }
                }
                else
                {
                    Message = "There is no record to insert into table!";
                }
            }
            else
            {
                Message = "There is no record to insert into table!";
            }


            if (Message != string.Empty)
            {
                AlertMessage = "toastr.success('" + Message + "'" + ",'Server Error'," + "{'positionClass' : 'toast-top-center'}" + ")";
                ClientScript.RegisterClientScriptBlock(this.GetType(), "MSG01", AlertMessage, true);
            }

        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if (ViewState["tblDepartment"] == null)
            {
                DepartmentTable = new DataTable();
                DepartmentTable.Columns.Add("DepartmentName", typeof(string));
                ViewState["tblDepartment"] = DepartmentTable;
            }

            if (ViewState["tblDepartment"] != null)
            {
                DepartmentTable = (DataTable)ViewState["tblDepartment"];

                DataRow row = DepartmentTable.NewRow();
                row["DepartmentName"] = txtDepartmentName.Text;
                DepartmentTable.Rows.Add(row);
                DepartmentTable.AcceptChanges();

                ViewState["tblDepartment"] = DepartmentTable;

                DeptGrid.DataSource = null;

                DeptGrid.DataSource = DepartmentTable;
                DeptGrid.DataBind();
            }
        }
    }
}