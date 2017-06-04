using System;
using Microsoft.EntityFrameworkCore.Infrastructure;
using NativeScriptStudio.EfCore;
using Microsoft.EntityFrameworkCore;

namespace NativeScript.Studio.IdentityProvider.DatabaseFactory
{
    public class ApplicationDbContextFactory : IDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext Create(DbContextFactoryOptions options)
        {

            var builder = new DbContextOptionsBuilder<ApplicationDbContext>();
            var variables = new EnviromentInformation();
            var connectionString =
             new ConnectionStringBuilder()
             .CreateConnectiongString(
                                      basePath: variables.GetBasePath(),
                                      environmentName: variables.GetEnviromentName()
                                     );
            builder.UseSqlServer(connectionString);
            return new ApplicationDbContext(builder.Options);
        }
    }
}