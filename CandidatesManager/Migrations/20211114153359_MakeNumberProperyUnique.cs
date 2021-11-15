using Microsoft.EntityFrameworkCore.Migrations;

namespace CandidatesManager.Migrations
{
    public partial class MakeNumberProperyUnique : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Candidates_Number",
                table: "Candidates",
                column: "Number",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Candidates_Number",
                table: "Candidates");
        }
    }
}
