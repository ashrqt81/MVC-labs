using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace lab3.Migrations
{
    public partial class init4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Departmentcourse_course_deptCoursecourseId",
                table: "Departmentcourse");

            migrationBuilder.DropForeignKey(
                name: "FK_studentsCourse_course_crsId",
                table: "studentsCourse");

            migrationBuilder.DropPrimaryKey(
                name: "PK_course",
                table: "course");

            migrationBuilder.RenameTable(
                name: "course",
                newName: "Courses");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "students",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "students",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "students",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Courses",
                table: "Courses",
                column: "courseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Departmentcourse_Courses_deptCoursecourseId",
                table: "Departmentcourse",
                column: "deptCoursecourseId",
                principalTable: "Courses",
                principalColumn: "courseId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_studentsCourse_Courses_crsId",
                table: "studentsCourse",
                column: "crsId",
                principalTable: "Courses",
                principalColumn: "courseId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Departmentcourse_Courses_deptCoursecourseId",
                table: "Departmentcourse");

            migrationBuilder.DropForeignKey(
                name: "FK_studentsCourse_Courses_crsId",
                table: "studentsCourse");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Courses",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "students");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "students");

            migrationBuilder.RenameTable(
                name: "Courses",
                newName: "course");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "students",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10);

            migrationBuilder.AddPrimaryKey(
                name: "PK_course",
                table: "course",
                column: "courseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Departmentcourse_course_deptCoursecourseId",
                table: "Departmentcourse",
                column: "deptCoursecourseId",
                principalTable: "course",
                principalColumn: "courseId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_studentsCourse_course_crsId",
                table: "studentsCourse",
                column: "crsId",
                principalTable: "course",
                principalColumn: "courseId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
