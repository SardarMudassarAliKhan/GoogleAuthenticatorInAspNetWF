using GoogleAuthenticatorInAspNetWF.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GoogleAuthenticatorInAspNetWF.Views
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim();
            string password = txtPassword.Text.Trim();
            string passwordHash = ComputeSha256Hash(password);

            using (var db = new GoogleAuthEntities())
            {
                var user = db.Users.FirstOrDefault(u => u.Email == email && u.PasswordHash == passwordHash);
                if (user != null)
                {
                    Session["2FA_UserId"] = user.Id;
                    Response.Redirect("/Views/TwoFactor.aspx");
                }
                else
                {
                    lblResult.Text = "Invalid email or password.";
                }
            }
        }

        private string ComputeSha256Hash(string password)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                StringBuilder builder = new StringBuilder();
                foreach (var b in bytes)
                    builder.Append(b.ToString("x2"));
                return builder.ToString();
            }
        }
    }
}