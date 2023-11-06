namespace AP.Common
{
    public static class GenerateOtp
    {
        public static string GenerateRandomOtp()
        {
            int nLength = 6;
            string[] sAllowedCharacters = new string[]{ "1", "2", "3", "4", "5", "6", "7", "8", "9", "0" }; 
            string sOtp = string.Empty;
            string sTempChar = string.Empty;
            Random rand = new Random();
            for(int i=0; i<nLength; i++)
            {
                int p = rand.Next(0, sAllowedCharacters.Length);
                sTempChar = sAllowedCharacters[p];
                sOtp += sTempChar; 
            }
            return sOtp;
        }
    }
}
