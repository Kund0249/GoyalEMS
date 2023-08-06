using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Web.Security;

namespace GoyalEMS.Account
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
           string ConnectionString = "data source=.;database=EmployeeDB;trusted_connection=true";

          using(SqlConnection con = new SqlConnection(ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("spValidateUser", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@p_UserADID", txtADID.Text.Trim());
                cmd.Parameters.AddWithValue("@p_UserPassword", txtPassword.Text);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable table = new DataTable();
                adapter.Fill(table);

                if(table != null)
                {
                    if(table.Rows.Count > 0)
                    {
                        bool IsValid = Convert.ToBoolean(table.Rows[0]["IsValid"]);

                        if (IsValid)
                        {
                            string UserName = Convert.ToString(table.Rows[0]["UserName"]);
                            string ADID = Convert.ToString(table.Rows[0]["ADID"]);

                            //Step 1 => Ticket Created for User
                            FormsAuthenticationTicket ticket = new 
                                FormsAuthenticationTicket(1,
                                                        ADID,
                                                        DateTime.Now,
                                                        DateTime.Now.AddMinutes(20),
                                                        false, 
                                                        UserName);
                            //Step 2 => Encrypt Ticket
                            string EncryptedTicket = FormsAuthentication.Encrypt(ticket);

                            //Step 3 =>Create Cookie
                            HttpCookie AuthCookie = new HttpCookie(FormsAuthentication.FormsCookieName, EncryptedTicket);

                            //Step 4 => Add this cookie in User Browser
                            Response.Cookies.Add(AuthCookie);

                            //Step 5 => Allow user to login
                            Response.Redirect("~/Admin/Department.aspx");

                            //FormsAuthentication.RedirectFromLoginPage(ADID, false);
                        }
                        else
                        {
                            lblMessage.Text = "Invalid User ADID or Password!";
                            lblMessage.ForeColor = System.Drawing.Color.Red;
                        }
                    }
                }
            }
        }
    }
}