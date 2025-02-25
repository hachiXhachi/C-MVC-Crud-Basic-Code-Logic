using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Crud.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class forkeytbls : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EmployeeID",
                table: "sal",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EmployeeID",
                table: "Emp",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Emp",
                keyColumn: "Id",
                keyValue: 1,
                column: "EmployeeID",
                value: 1);

            migrationBuilder.UpdateData(
                table: "sal",
                keyColumn: "Id",
                keyValue: 1,
                column: "EmployeeID",
                value: 1);

            migrationBuilder.CreateIndex(
                name: "IX_sal_EmployeeID",
                table: "sal",
                column: "EmployeeID");

            migrationBuilder.AddForeignKey(
                name: "FK_sal_Emp_EmployeeID",
                table: "sal",
                column: "EmployeeID",
                principalTable: "Emp",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_sal_Emp_EmployeeID",
                table: "sal");

            migrationBuilder.DropIndex(
                name: "IX_sal_EmployeeID",
                table: "sal");

            migrationBuilder.DropColumn(
                name: "EmployeeID",
                table: "sal");

            migrationBuilder.DropColumn(
                name: "EmployeeID",
                table: "Emp");
        }
    }
}
