using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class UpdateEstateAgentApi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PhotoUrl",
                table: "EstateAgents");

            migrationBuilder.AddColumn<int>(
                name: "EstateAgentId",
                table: "Photos",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Photos_EstateAgentId",
                table: "Photos",
                column: "EstateAgentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Photos_EstateAgents_EstateAgentId",
                table: "Photos",
                column: "EstateAgentId",
                principalTable: "EstateAgents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Photos_EstateAgents_EstateAgentId",
                table: "Photos");

            migrationBuilder.DropIndex(
                name: "IX_Photos_EstateAgentId",
                table: "Photos");

            migrationBuilder.DropColumn(
                name: "EstateAgentId",
                table: "Photos");

            migrationBuilder.AddColumn<string>(
                name: "PhotoUrl",
                table: "EstateAgents",
                nullable: true);
        }
    }
}
