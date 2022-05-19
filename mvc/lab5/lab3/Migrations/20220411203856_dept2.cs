using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace lab3.Migrations
{
    public partial class dept2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "StdImg",
                table: "students",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "deptno",
                table: "students",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Capacity",
                table: "department",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "department",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_students_deptno",
                table: "students",
                column: "deptno");

            migrationBuilder.AddForeignKey(
                name: "FK_students_department_deptno",
                table: "students",
                column: "deptno",
                principalTable: "department",
                principalColumn: "DeptId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_students_department_deptno",
                table: "students");

            migrationBuilder.DropIndex(
                name: "IX_students_deptno",
                table: "students");

            migrationBuilder.DropColumn(
                name: "StdImg",
                table: "students");

            migrationBuilder.DropColumn(
                name: "deptno",
                table: "students");

            migrationBuilder.DropColumn(
                name: "Capacity",
                table: "department");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "department");
        }
    }
}
