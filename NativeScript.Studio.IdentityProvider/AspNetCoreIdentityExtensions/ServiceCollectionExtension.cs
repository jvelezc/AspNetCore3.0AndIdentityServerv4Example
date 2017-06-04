using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NativeScript.Studio.IdentityProvider.Entities;
using NativeScript.Studio.IdentityProvider.Stores;

namespace NativeScript.Studio.IdentityProvider.AspNetCoreIdentityExtensions
{
    public static class ServiceCollectionExtension
    {

        public static void AddIdentityServer4Custom(this IServiceCollection services, string connectionString, string migrationAssembly)
        {

            //When using dotnet ef migrations an assembly is neccesary.
            services.AddIdentityServer()
                           .AddConfigurationStore(builder =>
                               builder.UseSqlServer(connectionString,
                               options => options.MigrationsAssembly(migrationAssembly)))
                                .AddOperationalStore(builder =>
                                      builder.UseSqlServer(connectionString, options =>
                                      options.MigrationsAssembly(migrationAssembly)))
                     .AddAspNetIdentity<ApplicationUser>()
                     .AddTemporarySigningCredential();

        }
        public static void AddEntityFrameWorkIdentityCustom(this IServiceCollection services)
        {
            services.AddIdentity<ApplicationUser, ApplicationRole>(identityOptions => {
              
            }).AddUserStore<ApplicationUserStore>()
            .AddUserManager<ApplicationUserManager>()
            .AddRoleStore<ApplicationRoleStore>()
            .AddRoleManager<ApplicationRoleManager>()
            .AddSignInManager<ApplicationSignInManager>()
            ;   
        }
    }


}
