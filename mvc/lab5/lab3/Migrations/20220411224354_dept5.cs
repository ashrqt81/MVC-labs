using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace lab3.Migrations
{
    public partial class dept5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departmentcourse",
                columns: table => new
                {
                    departmentsDeptId = table.Column<int>(type: "int", nullable: false),
                    deptCoursecourseId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departmentcourse", x => new { x.departmentsDeptId, x.deptCoursecourseId });
                    table.ForeignKey(
                        name: "FK_Departmentcourse_course_deptCoursecourseId",
                        column: x => x.deptCoursecourseId,
                        principalTable: "course",
                        principalColumn: "courseId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Departmentcourse_department_departmentsDeptId",
                        column: x => x.departmentsDeptId,
                        principalTable: "department",
                        principalColumn: "DeptId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Departmentcourse_deptCoursecourseId",
                table: "Departmentcourse",
                column: "deptCoursecourseId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Departmentcourse");
        }
    }
}
