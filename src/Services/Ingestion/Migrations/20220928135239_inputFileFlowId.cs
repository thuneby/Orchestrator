using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ingestion.Migrations
{
    public partial class inputFileFlowId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "FlowId",
                table: "InputFiles",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FlowId",
                table: "InputFiles");
        }
    }
}
