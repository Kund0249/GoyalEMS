using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.Security;

namespace GoyalEMS
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

            HttpCookie httpCookie = Request.Cookies[FormsAuthentication.FormsCookieName];

            if(httpCookie != null)
            {
                string EncryptedTicket = httpCookie.Value;
                try
                {
                    FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(EncryptedTicket);

                    if(ticket != null)
                    {
                        string ADID = ticket.Name;
                        var Identity = new GenericIdentity(ADID);
                        var Pricple = new GenericPrincipal(Identity,null);
                        HttpContext.Current.User = Pricple;
                    }
                }
                catch (Exception)
                {

                }
            }
            //var identity = new GenericIdentity("abaj");
            //var Princple = new GenericPrincipal(identity, null);
            //HttpContext.Current.User = null;
        }
    }
}