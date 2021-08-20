using Microsoft.EntityFrameworkCore.Migrations;

namespace Solution.EntityFrameworkCore.Migrations
{
    public partial class InsertColumnDisplayNameTableUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DisplayName",
                table: "ApplicationUsers",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DisplayName",
                table: "ApplicationUsers");
        }
    }
}
