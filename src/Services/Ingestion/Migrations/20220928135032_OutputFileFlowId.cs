using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ingestion.Migrations
{
    public partial class OutputFileFlowId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "FlowId",
                table: "OutputFiles",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FlowId",
                table: "OutputFiles");
        }
    }
}
