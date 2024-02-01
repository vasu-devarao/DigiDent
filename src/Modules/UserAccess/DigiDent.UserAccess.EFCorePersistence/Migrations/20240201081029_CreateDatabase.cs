﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DigiDent.UserAccess.EFCorePersistence.Migrations
{
    /// <inheritdoc />
    public partial class CreateDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "user_access");

            migrationBuilder.CreateTable(
                name: "Users",
                schema: "user_access",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FullName = table.Column<string>(name: "Full Name", type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RefreshTokens",
                schema: "user_access",
                columns: table => new
                {
                    Token = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    JwtId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExpiryDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefreshTokens", x => x.Token);
                    table.ForeignKey(
                        name: "FK_RefreshTokens_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "user_access",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "user_access",
                table: "Users",
                columns: new[] { "Id", "Email", "Full Name", "Password", "PhoneNumber", "Role" },
                values: new object[] { new Guid("d957ca94-cadf-4839-ae89-03f69860b95d"), "temp@admin.tmp", "Temporary Administrator", "+wzjCz+nimOSx2XoMx5FzO12Ef1AOm5pICVaOLEE/b8=:DcQvWttBYHzICe3u9ZfbG9zxAN3ZYfAd8vxrBJErzl8=", "+380000000000", "Administrator" });

            migrationBuilder.CreateIndex(
                name: "IX_RefreshTokens_UserId",
                schema: "user_access",
                table: "RefreshTokens",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                schema: "user_access",
                table: "Users",
                column: "Email",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RefreshTokens",
                schema: "user_access");

            migrationBuilder.DropTable(
                name: "Users",
                schema: "user_access");
        }
    }
}
