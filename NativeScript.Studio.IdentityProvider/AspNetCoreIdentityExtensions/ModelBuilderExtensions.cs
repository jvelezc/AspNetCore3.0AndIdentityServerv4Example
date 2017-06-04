
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace NativeScript.Studio.IdentityProvider.AspNetCoreIdentityExtensions
{
    public static class ModelBuilderExtensions
    {

        public static void RemovePluralizingTableNameConvention(this ModelBuilder modelBuilder)
        {
            foreach (IMutableEntityType entity in modelBuilder.Model.GetEntityTypes())
            {
                entity.Relational().TableName = entity.DisplayName();
            }
        }
        public static void AspNetIdentityTableConfig(this ModelBuilder builder)
        {
            new ModelBuilderAspnetIdentity().AspNetIdentity(builder);
        }

        public static void IdentityV4TableConfigs(this ModelBuilder builder)
        {
            new ModelBuilderIdentityV4().IdentityV4(builder);
        }
    }
}
