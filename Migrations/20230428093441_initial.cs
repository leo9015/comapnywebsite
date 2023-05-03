using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Taskcomapny.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // cretaing table
            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ComapnyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompanyReview = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    companyAvgSalary = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Companies");
        }
    }
}
