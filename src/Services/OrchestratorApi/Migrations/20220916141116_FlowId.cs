using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OrchestratorApi.Migrations
{
    public partial class FlowId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "TenantId",
                table: "Flow",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "TenantÍd",
                table: "Flow",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_Flow_TenantId",
                table: "Flow",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_EventEntity_FlowId",
                table: "EventEntity",
                column: "FlowId");

            migrationBuilder.AddForeignKey(
                name: "FK_EventEntity_Flow_FlowId",
                table: "EventEntity",
                column: "FlowId",
                principalTable: "Flow",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Flow_Tenant_TenantId",
                table: "Flow",
                column: "TenantId",
                principalTable: "Tenant",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EventEntity_Flow_FlowId",
                table: "EventEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_Flow_Tenant_TenantId",
                table: "Flow");

            migrationBuilder.DropIndex(
                name: "IX_Flow_TenantId",
                table: "Flow");

            migrationBuilder.DropIndex(
                name: "IX_EventEntity_FlowId",
                table: "EventEntity");

            migrationBuilder.DropColumn(
                name: "TenantId",
                table: "Flow");

            migrationBuilder.DropColumn(
                name: "TenantÍd",
                table: "Flow");
        }
    }
}
