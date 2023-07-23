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
        IDEPARTMENTPROCESSOR Processor = new DEPARTMENTPROCESSOR();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetAllDepartments();
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            DepartmentModel department = new DepartmentModel()
            {
                DepartmentName = txtDepartmentName.Text.Trim(),
                DeptId = Convert.ToInt32(HdfDepartmentId.Value)
            };

            string Message = Processor.Save(department, out int status);

            string AlertMessage = string.Empty;

            switch (status)
            {
                case 500:
                    AlertMessage = "toastr.error('" + Message + "'" + ",'Server Error'," + "{'positionClass' : 'toast-top-center'}" + ")";
                    break;
                case 403:
                    AlertMessage = "toastr.warning('" + Message + "'" + ",'Already Exists'," + "{'positionClass' : 'toast-top-center'}" + ")";
                    break;
                case 200:
                    txtDepartmentName.Text = string.Empty;
                    HdfDepartmentId.Value = string.Empty;
                    GetAllDepartments();
                    AlertMessage = "toastr.success('" + Message + "'" + ",'Success'," + "{'positionClass' : 'toast-top-center'}" + ")";
                    break;
                default:
                    break;
            }

            ClientScript.RegisterClientScriptBlock(this.GetType(), "MSG01", AlertMessage, true);

        }

        public void GetAllDepartments()
        {
            DeptGrid.DataSource = Processor.GetDepartments;
            DeptGrid.DataBind();
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            string Messag = "Record Inserted";

            string AlertMessage = "toastr.success('" + Messag + "'" + ",'Success'," + "{'positionClass' : 'toast-top-center'}" + ")";
            ClientScript.RegisterClientScriptBlock(this.GetType(), "MS012", AlertMessage, true);
        }

        protected void DeptGrid_SelectedIndexChanged(object sender, EventArgs e)
        {
            int DepartmentId = Convert.ToInt32(DeptGrid.DataKeys[DeptGrid.SelectedIndex].Value);

            DepartmentModel model = Processor.GetDepartment(DepartmentId);

            if (model == null)
            {
                string Messag = "Resource not fount with the id - " + DepartmentId;
                string AlertMessage = "toastr.error('" + Messag + "'" + ",'Error'," + "{'positionClass' : 'toast-top-center'}" + ")";
                ClientScript.RegisterClientScriptBlock(this.GetType(), "MS012", AlertMessage, true);
            }
            else
            {
                txtDepartmentName.Text = model.DepartmentName;
                HdfDepartmentId.Value = model.DeptId.ToString();
            }


            //int rowindex = DeptGrid.SelectedIndex;

            //var id = DeptGrid.DataKeys[rowindex].Value;

            //Messag = id.ToString();


            //string AlertMessage = "toastr.success('" + Messag + "'" + ",'Success'," + "{'positionClass' : 'toast-top-center'}" + ")";
            //ClientScript.RegisterClientScriptBlock(this.GetType(), "MS012", AlertMessage, true);
        }
    }
}