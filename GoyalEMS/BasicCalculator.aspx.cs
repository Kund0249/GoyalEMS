using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GoyalEMS
{
    public partial class BasicCalculator : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSum_Click(object sender, EventArgs e)
        {
            lblResult.Text = "Result : " + (Convert.ToInt32(txtNum1.Text) + Convert.ToInt32(txtNum2.Text)).ToString();
        }
    }
}