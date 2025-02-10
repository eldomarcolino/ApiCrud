using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiCrud.Migrations
{
    /// <inheritdoc />
    public partial class Relacionamento1PraMuitos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "students_curso");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Students");

            migrationBuilder.AlterColumn<decimal>(
                name: "Balance",
                table: "Students",
                type: "decimal(65,30)",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(10,2)");

            migrationBuilder.AddColumn<int>(
                name: "CursoId",
                table: "Students",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Students_CursoId",
                table: "Students",
                column: "CursoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Course_CursoId",
                table: "Students",
                column: "CursoId",
                principalTable: "Course",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Course_CursoId",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_CursoId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "CursoId",
                table: "Students");

            migrationBuilder.AlterColumn<decimal>(
                name: "Balance",
                table: "Students",
                type: "decimal(10,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(65,30)",
                oldMaxLength: 255);

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Students",
                type: "varchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "students_curso",
                columns: table => new
                {
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    CourseId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_students_curso", x => new { x.StudentId, x.CourseId });
                    table.ForeignKey(
                        name: "FK_students_curso_Course_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Course",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_students_curso_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_students_curso_CourseId",
                table: "students_curso",
                column: "CourseId");
        }
    }
}
