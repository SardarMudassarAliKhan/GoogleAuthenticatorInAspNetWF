using GoogleAuthenticatorInAspNetWF.Entity;
using GoogleAuthenticatorInAspNetWF.Helper;
using System;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace GoogleAuthenticatorInAspNetWF.Views
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
          
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim();
            string password = txtPassword.Text.Trim();

            string passwordHash = ComputeSha256Hash(password);

            string secret = TwoFactorAuthHelper.GenerateSecretKey();

            using (var db = new GoogleAuthEntities())
            {
                var user = new User
                {
                    Email = email,
                    PasswordHash = passwordHash,
                    SecretKey = secret
                };
                db.Users.Add(user);
                db.SaveChanges();
            }

            // Generate otpauth:// string
            string qrUrl = TwoFactorAuthHelper.GenerateQrCodeUrl(email, secret);
            string encoded = HttpUtility.UrlEncode(qrUrl);

            imgQrCode.ImageUrl = "https://quickchart.io/qr?text=" + encoded + "&size=250";

            lblSecret.Text = "Scan this QR code with Google Authenticator";
        }


        private string ComputeSha256Hash(string password)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder builder = new StringBuilder();
                foreach (var b in bytes)
                {
                    builder.Append(b.ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }
}