using System;

namespace NativeScript.Studio.IdentityProvider.DatabaseFactory
{
    public class EnviromentInformation
    {
        public virtual string GetEnviromentName()
        {
            return Environment.GetEnvironmentVariable("Hosting:Environment"); ;
        }
        public virtual string GetBasePath()
        {
            return AppContext.BaseDirectory;
        }
    }
}
