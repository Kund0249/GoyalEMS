using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Data.OleDb;

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

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            string Message;
            string AlertMessage;
            string FolderPath = "~/AppFiles/";
            
            if (!deptFile.HasFile)
            {
                 Message = "Please Select a File.";
                 AlertMessage = "toastr.error('" + Message + "'" + ",'Server Error'," + "{'positionClass' : 'toast-top-center'}" + ")";
                ClientScript.RegisterClientScriptBlock(this.GetType(), "MSG01", AlertMessage, true);
            }

            string Extension = System.IO.Path.GetExtension(deptFile.PostedFile.FileName);

            if (!(Extension.ToLower() == ".xlsx"))
            {
                 Message = "Please Select a Excel file (e.g Sample.xlsx).";
                 AlertMessage = "toastr.error('" + Message + "'" + ",'Server Error'," + "{'positionClass' : 'toast-top-center'}" + ")";
                ClientScript.RegisterClientScriptBlock(this.GetType(), "MSG01", AlertMessage, true);
            }

            //int bytes = deptFile.PostedFile.ContentLength;
            //float Mb = (bytes / 1024*1024);


            string FileName = deptFile.PostedFile.FileName;

            Guid guid = Guid.NewGuid();
            string guidvalue =    guid.ToString();
            FileName = guidvalue + FileName;

            deptFile.PostedFile.SaveAs(Server.MapPath(FolderPath) + FileName);

            string ExcelFilepath = Server.MapPath(FolderPath) + FileName;
            //Message = "File Save.";
            //AlertMessage = "toastr.success('" + Message + "'" + ",'Server Error'," + "{'positionClass' : 'toast-top-center'}" + ")";
            //ClientScript.RegisterClientScriptBlock(this.GetType(), "MSG01", AlertMessage, true);

            string CS = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source="
            + ExcelFilepath + ";Extended Properties=\"Excel 12.0;HDR=Yes;IMEX=2\"";
        
            using(OleDbConnection con = new OleDbConnection(CS))
            {
                OleDbCommand cmd = new OleDbCommand("select * from [sheet1$]", con);
                OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
                if (DepartmentTable == null)
                    DepartmentTable = new DataTable();
                adapter.Fill(DepartmentTable);

                if(DepartmentTable != null)
                {
                    if(DepartmentTable.Rows.Count > 0)
                    {
                        DeptGrid.DataSource = DepartmentTable;
                        DeptGrid.DataBind();
                        ViewState["tblDepartment"] = DepartmentTable;
                    }
                }


            }
        }
    }
}