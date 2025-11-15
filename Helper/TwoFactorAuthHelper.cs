using OtpNet;

namespace GoogleAuthenticatorInAspNetWF.Helper
{
    public class TwoFactorAuthHelper
    {
        public static string GenerateSecretKey()
        {
            var key = KeyGeneration.GenerateRandomKey(20);
            return Base32Encoding.ToString(key);
        }

        public static string GenerateQrCodeUrl(string userEmail, string secret, string issuer = "WebForms2FA")
        {
            return $"otpauth://totp/{issuer}:{userEmail}?secret={secret}&issuer={issuer}&digits=6";
        }

        public static string GenerateQrCodeUrl(string email, string secret)
        {
            string issuer = "MyWebFormsApp";
            string otpauth = $"otpauth://totp/{issuer}:{email}?secret={secret}&issuer={issuer}&digits=6";
            return otpauth;
        }

        public static bool VerifyCode(string secret, string code)
        {
            var totp = new Totp(Base32Encoding.ToBytes(secret));
            return totp.VerifyTotp(code, out long timeStepMatched, new VerificationWindow(2, 2));
        }
    }
}