using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ITI_MVC.Migrations
{
    /// <inheritdoc />
    public partial class m1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_employees_departments_Office_Id",
                table: "employees");

            migrationBuilder.DropPrimaryKey(
                name: "PK_departments",
                table: "departments");

            migrationBuilder.RenameTable(
                name: "departments",
                newName: "office");

            migrationBuilder.AddPrimaryKey(
                name: "PK_office",
                table: "office",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_employees_office_Office_Id",
                table: "employees",
                column: "Office_Id",
                principalTable: "office",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_employees_office_Office_Id",
                table: "employees");

            migrationBuilder.DropPrimaryKey(
                name: "PK_office",
                table: "office");

            migrationBuilder.RenameTable(
                name: "office",
                newName: "departments");

            migrationBuilder.AddPrimaryKey(
                name: "PK_departments",
                table: "departments",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_employees_departments_Office_Id",
                table: "employees",
                column: "Office_Id",
                principalTable: "departments",
                principalColumn: "Id");
        }
    }
}
