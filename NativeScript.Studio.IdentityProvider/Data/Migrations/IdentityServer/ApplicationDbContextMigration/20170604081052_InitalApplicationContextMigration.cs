using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace NativeScript.Studio.IdentityProvider.Data.Migrations.IdentityServer.ApplicationDbContextMigration
{
    public partial class InitalApplicationContextMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Security");

            migrationBuilder.CreateTable(
                name: "ApplicationRole",
                schema: "Security",
                columns: table => new
                {
                    AspNetRoleId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationRole", x => x.AspNetRoleId);
                });

            migrationBuilder.CreateTable(
                name: "ApplicationUser",
                schema: "Security",
                columns: table => new
                {
                    AspNetUserId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    PasswordHash = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    SecurityStamp = table.Column<string>(nullable: true),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationUser", x => x.AspNetUserId);
                });

            migrationBuilder.CreateTable(
                name: "ApplicationUserToken",
                schema: "Security",
                columns: table => new
                {
                    AspNetUserId = table.Column<int>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationUserToken", x => new { x.AspNetUserId, x.LoginProvider, x.Name });
                });

            migrationBuilder.CreateTable(
                name: "ApplicationRoleClaim",
                schema: "Security",
                columns: table => new
                {
                    AspNetRoleClaimId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true),
                    AspNetRoleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationRoleClaim", x => x.AspNetRoleClaimId);
                    table.ForeignKey(
                        name: "FK_ApplicationRoleClaim_ApplicationRole_AspNetRoleId",
                        column: x => x.AspNetRoleId,
                        principalSchema: "Security",
                        principalTable: "ApplicationRole",
                        principalColumn: "AspNetRoleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ApplicationUserClaim",
                schema: "Security",
                columns: table => new
                {
                    AspNetUserClaimId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true),
                    AspNetUserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationUserClaim", x => x.AspNetUserClaimId);
                    table.ForeignKey(
                        name: "FK_ApplicationUserClaim_ApplicationUser_AspNetUserId",
                        column: x => x.AspNetUserId,
                        principalSchema: "Security",
                        principalTable: "ApplicationUser",
                        principalColumn: "AspNetUserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ApplicationUserLogin",
                schema: "Security",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    AspNetUserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationUserLogin", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_ApplicationUserLogin_ApplicationUser_AspNetUserId",
                        column: x => x.AspNetUserId,
                        principalSchema: "Security",
                        principalTable: "ApplicationUser",
                        principalColumn: "AspNetUserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ApplicationUserRole",
                schema: "Security",
                columns: table => new
                {
                    AspNetUserId = table.Column<int>(nullable: false),
                    AspNetRoleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationUserRole", x => new { x.AspNetUserId, x.AspNetRoleId });
                    table.ForeignKey(
                        name: "FK_ApplicationUserRole_ApplicationRole_AspNetRoleId",
                        column: x => x.AspNetRoleId,
                        principalSchema: "Security",
                        principalTable: "ApplicationRole",
                        principalColumn: "AspNetRoleId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApplicationUserRole_ApplicationUser_AspNetUserId",
                        column: x => x.AspNetUserId,
                        principalSchema: "Security",
                        principalTable: "ApplicationUser",
                        principalColumn: "AspNetUserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                schema: "Security",
                table: "ApplicationRole",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationRoleClaim_AspNetRoleId",
                schema: "Security",
                table: "ApplicationRoleClaim",
                column: "AspNetRoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                schema: "Security",
                table: "ApplicationUser",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                schema: "Security",
                table: "ApplicationUser",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUserClaim_AspNetUserId",
                schema: "Security",
                table: "ApplicationUserClaim",
                column: "AspNetUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUserLogin_AspNetUserId",
                schema: "Security",
                table: "ApplicationUserLogin",
                column: "AspNetUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUserRole_AspNetRoleId",
                schema: "Security",
                table: "ApplicationUserRole",
                column: "AspNetRoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApplicationRoleClaim",
                schema: "Security");

            migrationBuilder.DropTable(
                name: "ApplicationUserClaim",
                schema: "Security");

            migrationBuilder.DropTable(
                name: "ApplicationUserLogin",
                schema: "Security");

            migrationBuilder.DropTable(
                name: "ApplicationUserRole",
                schema: "Security");

            migrationBuilder.DropTable(
                name: "ApplicationUserToken",
                schema: "Security");

            migrationBuilder.DropTable(
                name: "ApplicationRole",
                schema: "Security");

            migrationBuilder.DropTable(
                name: "ApplicationUser",
                schema: "Security");
        }
    }
}
