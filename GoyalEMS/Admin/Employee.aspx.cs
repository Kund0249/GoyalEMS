using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using EMS.DataProcessor.DepartmentDataProcessor;
using EMS.DataProcessor.EmployeeDataProcessor;

namespace GoyalEMS.Admin
{
    public partial class Employee : System.Web.UI.Page
    {
        private readonly IDEPARTMENTPROCESSOR _Processor = new DEPARTMENTPROCESSOR();
        private readonly IEMPLOYEEDATAPROCESSOR _EmpProcessor = new EMPLOYEEDATAPROCESSOR();


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ddlDepartment.DataSource = _Processor.GetDepartments;
                ddlDepartment.DataTextField = "DepartmentName";
                ddlDepartment.DataValueField = "DeptId";
                ddlDepartment.DataBind();
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            EMS.DataProcessor.EmployeeDataProcessor.Employee employee = new EMS.DataProcessor.EmployeeDataProcessor.Employee()
            {
                EmpName = txtName.Text,
                Gender = (rdbMale.Checked ? "male" : "female"),
                DepartmentId = Convert.ToInt32(ddlDepartment.SelectedValue),
                DOB = Convert.ToDateTime(txtDOB.Text),
                DOJ = Convert.ToDateTime(txtDOJ.Text),
                EmailId = txtEmail.Text,
                Salary = Convert.ToInt32(txtSalary.Text),
                ProfileImage = null
            };
            
            string Message = _EmpProcessor.Save(employee, out int Status);

        }
    }
}