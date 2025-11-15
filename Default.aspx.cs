using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GoogleAuthenticatorInAspNetWF
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["LoggedInUser"] == null)
            {
                Response.Redirect("/Views/Login.aspx");
            }
            lblWelcome.Text = "Welcome! You have logged in with 2FA.";
        }
    }
}