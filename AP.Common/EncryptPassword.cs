namespace AP.Common
{
    public static class EncryptPassword
    {
        public static string EncryptPass(string sPassword)
        {
            return BCrypt.Net.BCrypt.HashPassword(sPassword);
        }

        public static bool VerifyPass(string sPassword, string sHashPassword)
        {
            return BCrypt.Net.BCrypt.Verify(sPassword, sHashPassword);
        }
    }
}
