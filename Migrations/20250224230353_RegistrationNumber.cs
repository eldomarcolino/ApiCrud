using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaDeRecarga.Migrations
{
    /// <inheritdoc />
    public partial class RegistrationNumber : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RegistrationNumber",
                table: "User",
                type: "varchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_User_RegistrationNumber",
                table: "User",
                column: "RegistrationNumber",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_User_RegistrationNumber",
                table: "User");

            migrationBuilder.DropColumn(
                name: "RegistrationNumber",
                table: "User");
        }
    }
}
