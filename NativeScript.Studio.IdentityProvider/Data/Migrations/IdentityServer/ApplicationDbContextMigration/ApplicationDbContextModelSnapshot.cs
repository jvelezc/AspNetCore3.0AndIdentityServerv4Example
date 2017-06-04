using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using NativeScriptStudio.EfCore;

namespace NativeScript.Studio.IdentityProvider.Data.Migrations.IdentityServer.ApplicationDbContextMigration
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("NativeScript.Studio.IdentityProvider.Entities.ApplicationRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("AspNetRoleId");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex");

                    b.ToTable("ApplicationRole","Security");
                });

            modelBuilder.Entity("NativeScript.Studio.IdentityProvider.Entities.ApplicationRoleClaim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("AspNetRoleClaimId");

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<int>("RoleId")
                        .HasColumnName("AspNetRoleId");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("ApplicationRoleClaim","Security");
                });

            modelBuilder.Entity("NativeScript.Studio.IdentityProvider.Entities.ApplicationUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("AspNetUserId");

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex");

                    b.ToTable("ApplicationUser","Security");
                });

            modelBuilder.Entity("NativeScript.Studio.IdentityProvider.Entities.ApplicationUserClaim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("AspNetUserClaimId");

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<int>("UserId")
                        .HasColumnName("AspNetUserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("ApplicationUserClaim","Security");
                });

            modelBuilder.Entity("NativeScript.Studio.IdentityProvider.Entities.ApplicationUserLogin", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<int>("UserId")
                        .HasColumnName("AspNetUserId");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("ApplicationUserLogin","Security");
                });

            modelBuilder.Entity("NativeScript.Studio.IdentityProvider.Entities.ApplicationUserRole", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnName("AspNetUserId");

                    b.Property<int>("RoleId")
                        .HasColumnName("AspNetRoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("ApplicationUserRole","Security");
                });

            modelBuilder.Entity("NativeScript.Studio.IdentityProvider.Entities.ApplicationUserToken", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnName("AspNetUserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("ApplicationUserToken","Security");
                });

            modelBuilder.Entity("NativeScript.Studio.IdentityProvider.Entities.ApplicationRoleClaim", b =>
                {
                    b.HasOne("NativeScript.Studio.IdentityProvider.Entities.ApplicationRole")
                        .WithMany("Claims")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("NativeScript.Studio.IdentityProvider.Entities.ApplicationUserClaim", b =>
                {
                    b.HasOne("NativeScript.Studio.IdentityProvider.Entities.ApplicationUser")
                        .WithMany("Claims")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("NativeScript.Studio.IdentityProvider.Entities.ApplicationUserLogin", b =>
                {
                    b.HasOne("NativeScript.Studio.IdentityProvider.Entities.ApplicationUser")
                        .WithMany("Logins")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("NativeScript.Studio.IdentityProvider.Entities.ApplicationUserRole", b =>
                {
                    b.HasOne("NativeScript.Studio.IdentityProvider.Entities.ApplicationRole")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("NativeScript.Studio.IdentityProvider.Entities.ApplicationUser")
                        .WithMany("Roles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
