using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaDeRecarga.Migrations
{
    /// <inheritdoc />
    public partial class chaveestrangeira : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_User_IdCourse",
                table: "User",
                column: "IdCourse");

            migrationBuilder.AddForeignKey(
                name: "FK_User_Course_IdCourse",
                table: "User",
                column: "IdCourse",
                principalTable: "Course",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_Course_IdCourse",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_User_IdCourse",
                table: "User");
        }
    }
}
