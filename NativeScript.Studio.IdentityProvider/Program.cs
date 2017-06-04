using Microsoft.AspNetCore.Hosting;

namespace NativeScript.Studio.IdentityProvider
{
    public class Program
    {
        public static void Main()
        {
            var host = new WebHostBuilder()
                .UseStartup<Startup>()
                .Build();
            host.Run();
        }
    }

}
