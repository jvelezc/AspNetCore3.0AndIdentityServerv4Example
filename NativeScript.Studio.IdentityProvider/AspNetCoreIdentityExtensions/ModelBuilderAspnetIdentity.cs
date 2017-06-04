using Microsoft.EntityFrameworkCore;
using NativeScript.Studio.IdentityProvider.Entities;

namespace NativeScript.Studio.IdentityProvider.AspNetCoreIdentityExtensions
{
    public class ModelBuilderAspnetIdentity
    {
        public virtual void AspNetIdentity(ModelBuilder builder)
        {
            builder.Entity<ApplicationUser>(entity =>
            {
                entity.ToTable(name: "AspNetUser", schema: "Security");
                entity.Property(e => e.Id).HasColumnName("AspNetUserId");

            });

            builder.Entity<ApplicationRole>(entity =>
            {
                entity.ToTable(name: "AspNetRole", schema: "Security");
                entity.Property(e => e.Id).HasColumnName("AspNetRoleId");

            });

            builder.Entity<ApplicationUserClaim>(entity =>
            {
                entity.ToTable("AspNetUserClaim", "Security");
                entity.Property(e => e.UserId).HasColumnName("AspNetUserId");
                entity.Property(e => e.Id).HasColumnName("AspNetUserClaimId");

            });

            builder.Entity<ApplicationUserLogin>(entity =>
            {
                entity.ToTable("AspNetUserLogin", "Security");
                entity.Property(e => e.UserId).HasColumnName("AspNetUserId");

            });

            builder.Entity<ApplicationRoleClaim>(entity =>
            {
                entity.ToTable("AspNetRoleClaim", "Security");
                entity.Property(e => e.Id).HasColumnName("AspNetRoleClaimId");
                entity.Property(e => e.RoleId).HasColumnName("AspNetRoleId");
            });

            builder.Entity<ApplicationUserRole>(entity =>
            {
                entity.ToTable("AspNetUserRole", "Security");
                entity.Property(e => e.UserId).HasColumnName("AspNetUserId");
                entity.Property(e => e.RoleId).HasColumnName("AspNetRoleId");

            });


            builder.Entity<ApplicationUserToken>(entity =>
            {
                entity.ToTable("AspNetUserToken", "Security");
                entity.Property(e => e.UserId).HasColumnName("AspNetUserId");

            });
        }
    }
}
