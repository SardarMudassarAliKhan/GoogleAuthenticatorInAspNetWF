using GoogleAuthenticatorInAspNetWF.Entity;
using GoogleAuthenticatorInAspNetWF.Helper;
using System;
using System.Linq;

namespace GoogleAuthenticatorInAspNetWF.Views
{
    public partial class TwoFactor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["2FA_UserId"] == null)
            {
                Response.Redirect("/Views/Login.aspx");
            }
        }

        protected void btnVerify_Click(object sender, EventArgs e)
        {
            int userId = (int)Session["2FA_UserId"];
            string code = txtCode.Text.Trim();

            using (var db = new GoogleAuthEntities())
            {
                var user = db.Users.FirstOrDefault(u => u.Id == userId);
                if (user != null && TwoFactorAuthHelper.VerifyCode(user.SecretKey, code))
                {
                    Session.Remove("2FA_UserId");
                    Session["LoggedInUser"] = user.Id;
                    Response.Redirect("/Default.aspx");
                }
                else
                {
                    lblResult.Text = "Invalid 2FA code.";
                }
            }
        }
    }
}