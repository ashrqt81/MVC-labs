using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace lab3.Migrations
{
    public partial class dept9 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "studentsCourse",
                columns: table => new
                {
                    stdId = table.Column<int>(type: "int", nullable: false),
                    crsId = table.Column<int>(type: "int", nullable: false),
                    degree = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_studentsCourse", x => new { x.stdId, x.crsId });
                    table.ForeignKey(
                        name: "FK_studentsCourse_course_crsId",
                        column: x => x.crsId,
                        principalTable: "course",
                        principalColumn: "courseId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_studentsCourse_students_stdId",
                        column: x => x.stdId,
                        principalTable: "students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_studentsCourse_crsId",
                table: "studentsCourse",
                column: "crsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "studentsCourse");
        }
    }
}
