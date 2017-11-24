using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Ukeess.Migrations
{
    public partial class AddDepartments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Department",
                table: "Employees");

            migrationBuilder.AddColumn<int>(
                name: "emp_dpID",
                table: "Employees",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    dpID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    dpName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.dpID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_emp_dpID",
                table: "Employees",
                column: "emp_dpID");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Departments_emp_dpID",
                table: "Employees",
                column: "emp_dpID",
                principalTable: "Departments",
                principalColumn: "dpID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Departments_emp_dpID",
                table: "Employees");

            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropIndex(
                name: "IX_Employees_emp_dpID",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "emp_dpID",
                table: "Employees");

            migrationBuilder.AddColumn<string>(
                name: "Department",
                table: "Employees",
                nullable: true);
        }
    }
}
