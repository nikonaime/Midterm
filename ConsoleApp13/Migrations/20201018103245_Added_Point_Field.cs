using Microsoft.EntityFrameworkCore.Migrations;

namespace ConsoleApp13.Migrations
{
    public partial class Added_Point_Field : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Point",
                table: "StudentSubjects",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Point",
                table: "StudentSubjects");
        }
    }
}
