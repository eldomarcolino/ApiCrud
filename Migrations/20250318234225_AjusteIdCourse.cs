using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaDeRecarga.Migrations
{
    /// <inheritdoc />
    public partial class AjusteIdCourse : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_Course_IdCourse",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_User_IdCourse",
                table: "User");

            migrationBuilder.AddColumn<int>(
                name: "CursoId",
                table: "User",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_User_CursoId",
                table: "User",
                column: "CursoId");

            migrationBuilder.AddForeignKey(
                name: "FK_User_Course_CursoId",
                table: "User",
                column: "CursoId",
                principalTable: "Course",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_Course_CursoId",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_User_CursoId",
                table: "User");

            migrationBuilder.DropColumn(
                name: "CursoId",
                table: "User");

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
    }
}
