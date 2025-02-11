using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaDeRecarga.Migrations
{
    /// <inheritdoc />
    public partial class AjusteChaveUnica : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Course_Name",
                table: "Course",
                column: "Name",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Course_Name",
                table: "Course");
        }
    }
}
