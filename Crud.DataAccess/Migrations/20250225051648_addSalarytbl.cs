using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Crud.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class addSalarytbl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "sal",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    salary = table.Column<int>(type: "int", nullable: false),
                    Department = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sal", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "sal",
                columns: new[] { "Id", "Department", "salary" },
                values: new object[] { 1, "Accounting", 18000 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "sal");
        }
    }
}
