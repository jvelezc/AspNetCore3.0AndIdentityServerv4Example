using Microsoft.Extensions.Configuration;

namespace NativeScript.Studio.IdentityProvider.DatabaseFactory
{
   public  class ConnectionStringBuilder
    {
        public virtual string CreateConnectiongString(string basePath, string environmentName)
        {
            // SetBasePath depended on Microsoft.Extensions.Configuration.Json and it was not obvious.
            // http://stackoverflow.com/questions/36001695/setting-base-path-using-configurationbuilder
            var databaseConnectionString = new ConfigurationBuilder()
               .SetBasePath(basePath)
               .AddJsonFile("appsettings.json")
               .AddJsonFile($"appsettings.{environmentName}.json", true)
               .AddEnvironmentVariables()
               .Build()
               .GetConnectionString("DefaultConnection");
            return databaseConnectionString;
        }
    }
}
