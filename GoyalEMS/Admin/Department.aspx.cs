using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using EMS.DataModel.DepartmentDataModel;
using EMS.DataProcessor;
using EMS.DataProcessor.DepartmentDataProcessor;
using GoyalEMS.Models;

namespace GoyalEMS.Admin
{
    public partial class Department : System.Web.UI.Page
    {
        IDEPARTMENTPROCESSOR Processor = new DEPARTMENTPROCESSOR();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["pno"] != null)
                {
                    if (int.TryParse(Request.QueryString["pno"].ToString(), out int PageNo))
                    {
                        GetAllDepartments(PageNo);
                    }
                    else
                    {
                        GetAllDepartments();
                    }
                }
                else
                {
                    GetAllDepartments();
                }

            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            DepartmentModel department = new DepartmentModel()
            {
                DepartmentName = txtDepartmentName.Text.Trim(),
                DeptId = 0
            };

            if (!(string.IsNullOrEmpty(HdfDepartmentId.Value) && string.IsNullOrWhiteSpace(HdfDepartmentId.Value)))
                department.DeptId = Convert.ToInt32(HdfDepartmentId.Value);

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
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            string Messag = "Record Inserted";

            string AlertMessage = "toastr.success('" + Messag + "'" + ",'Success'," + "{'positionClass' : 'toast-top-center'}" + ")";
            ClientScript.RegisterClientScriptBlock(this.GetType(), "MS012", AlertMessage, true);
        }

        #region GridviewEevnt
        public void GetAllDepartments(int pageNo = 1)
        {
            if (ViewState["Pager"] != null)
                pageNo = Convert.ToInt32(ViewState["Pager"]);

            List<DepartmentModel> departmentModels = Processor.GetDepartmentsByPageNumber(pageNo);
            Pager pager = new Pager(departmentModels[0].TotalItem,CurrentPage:pageNo);
           

            btnlkNext.Enabled = pager.IsNext;
            btnlinkPrev.Enabled = pager.IsPrevious;

            btnlkFirst.Enabled = pager.IsFirst;
            btnlkLast.Enabled = pager.IsLast;

            ViewState["Pager"] = pageNo;
            ViewState["lastpageno"] = pager.TotalPage;

            rptPageNumber.DataSource = pager.Pages;
            rptPageNumber.DataBind();

            DeptGrid.DataSource = departmentModels;
            DeptGrid.DataBind();
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
        }

        protected void DeptGrid_RowDeleting(object sender, System.Web.UI.WebControls.GridViewDeleteEventArgs e)
        {
            int DepartmentId = Convert.ToInt32(DeptGrid.DataKeys[e.RowIndex].Value);

            bool isDeleted = Processor.Remove(DepartmentId);
            string Messag = string.Empty;
            string AlertMessage = string.Empty;
            if (isDeleted)
            {
                Messag = "Records deleted permanen from the System, Deleted Id - " + DepartmentId;
                AlertMessage = "toastr.success('" + Messag + "'" + ",'success'," + "{'positionClass' : 'toast-top-center'}" + ")";
                GetAllDepartments();
            }
            else
            {
                Messag = "System not able to process this request";
                AlertMessage = "toastr.error('" + Messag + "'" + ",'Error'," + "{'positionClass' : 'toast-top-center'}" + ")";

            }

            //string Messag = DepartmentId.ToString();
            ClientScript.RegisterClientScriptBlock(this.GetType(), "MS012", AlertMessage, true);

        }
        #endregion

        #region Pagination
        protected void btnlkNext_Click(object sender, EventArgs e)
        {
            if (ViewState["Pager"] != null)
            {
                int currentpage = Convert.ToInt32(ViewState["Pager"]);
                currentpage++;
                Response.Redirect("~/Admin/Department.aspx?pno=" + currentpage.ToString());
            }
        }

        protected void btnlinkPrev_Click(object sender, EventArgs e)
        {
            if (ViewState["Pager"] != null)
            {
                int currentpage = Convert.ToInt32(ViewState["Pager"]);
                if (currentpage > 0)
                    currentpage--;

                Response.Redirect("~/Admin/Department.aspx?pno=" + currentpage.ToString());
            }
        }

        protected void btnlkFirst_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Admin/Department.aspx?pno=1");
        }

        protected void btnlkLast_Click(object sender, EventArgs e)
        {
            if(ViewState["lastpageno"] != null)
            {
                Response.Redirect("~/Admin/Department.aspx?pno=" + Convert.ToInt32(ViewState["lastpageno"]).ToString());
               
            }
        }
        #endregion
    }
}