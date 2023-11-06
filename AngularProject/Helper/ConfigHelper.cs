namespace AngularProject.Helper
{
    public static class ConfigHelper
    {
        public static string GetConfig(string sKeyName)
        {
            var objConfiguration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            return objConfiguration.GetValue<string>(sKeyName);
        }
    }
}
