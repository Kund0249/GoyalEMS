using System;
using System.Data;
using System.Data.SqlClient;
using EMS.DataModel.DepartmentDataModel;
using EMS.DataProcessor;
using EMS.DataProcessor.DepartmentDataProcessor;

namespace GoyalEMS.Admin
{
    public partial class Department : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetAllDepartments();
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            EMS.DataProcessor.DepartmentDataProcessor.Department department = new EMS.DataProcessor.DepartmentDataProcessor.Department()
            {
                DepartmentName = txtDepartmentName.Text.Trim()
            };

            IDEPARTMENTPROCESSOR Processor = new DEPARTMENTPROCESSOR();

            string Message = Processor.Save(department, out int status);
            string AlertMessage = string.Empty;
            AlertMessage = "toastr.error('" + Message + "'" + ",'Server Error'," + "{'positionClass' : 'toast-top-center'}" + ")";

            switch (status)
            {
                case 500:
                    Message = "Server can not process your resuest";
                    // AlertMessage = string.Format($"toastr.error('{Message}', '{"Server Error"}')");
                    AlertMessage = "toastr.error('" + Message + "'" + ",'Server Error'," + "{'positionClass' : 'toast-top-center'}" + ")";
                    break;
                case 403:
                    //AlertMessage = string.Format($"toastr.warning('{Message}', '{"Already Exists"}')");
                    AlertMessage = "toastr.warning('" + Message + "'" + ",'Already Exists'," + "{'positionClass' : 'toast-top-center'}" + ")";
                    break;
                case 200:
                    txtDepartmentName.Text = string.Empty;
                    // AlertMessage = string.Format($"toastr.success('{Message}', '{"Success"}')");
                    AlertMessage = "toastr.success('" + Message + "'" + ",'Success'," + "{'positionClass' : 'toast-top-center'}" + ")";
                    GetAllDepartments();
                    break;
                default:
                    break;
            }

            //lblMessage.Text = Message;
            //toastr.success('Message!', 'Title', {'positionClass' : 'toast-top-left'})
            //string AlertMessage = string.Format("alert('{0}')", Message);

            ClientScript.RegisterClientScriptBlock(this.GetType(), "MSG01", AlertMessage, true);


        }

        private void GetAllDepartments()
        {
            //IDEPARTMENTREPOSITORY _Repo = new DEPARTMENTREPOSITORY();
            //DepartmentGrid.DataSource = _Repo.GetDepartments;
            //DepartmentGrid.DataBind();

            IDEPARTMENTPROCESSOR _Processor = new DEPARTMENTPROCESSOR();
            DepartmentGrid.DataSource = _Processor.GetDepartments;
            DepartmentGrid.DataBind();

            //string ConnectionString = "data source=.;database=EmployeeDB;trusted_connection=true";
            //using (SqlConnection con = new SqlConnection(ConnectionString))
            //{
            //    SqlCommand cmd = new SqlCommand("Select * from tblDepartment", con);
            //    cmd.CommandType = System.Data.CommandType.Text;

            //    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            //    DataTable depttable = new DataTable();
            //    adapter.Fill(depttable);

            //    if (depttable.Rows.Count > 0)
            //    {
            //        DataColumn column = new DataColumn("Amount");
            //        depttable.Columns.Add(column);
            //        depttable.AcceptChanges();
            //        foreach (DataRow row in depttable.Rows)
            //        {
            //            row["Amount"] = (Convert.ToInt32(row[0]) * 5).ToString();
            //        }
            //        depttable.AcceptChanges();
            //        //DataRow dr = depttable.NewRow();
            //        //dr[0] = 500;
            //        //dr[1] = "Total";
            //        //depttable.Rows.Add(dr);
            //        //depttable.AcceptChanges();

            //        DepartmentGrid.DataSource = depttable;
            //        DepartmentGrid.DataBind();
            //    }
            //}
        }
    }
}