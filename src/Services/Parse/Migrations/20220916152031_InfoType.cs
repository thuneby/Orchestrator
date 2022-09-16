using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Parse.Migrations
{
    public partial class InfoType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "INFOTYPE",
                table: "OsSectionStart",
                type: "nvarchar(3)",
                maxLength: 3,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "INFOTYPE",
                table: "OsSectionStart");
        }
    }
}
