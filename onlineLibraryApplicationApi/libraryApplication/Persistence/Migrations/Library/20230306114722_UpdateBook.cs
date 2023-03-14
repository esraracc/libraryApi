using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations.Library
{
    public partial class UpdateBook : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_UserActionsOnTheBooks_BookId",
                table: "UserActionsOnTheBooks");

            migrationBuilder.CreateIndex(
                name: "IX_UserActionsOnTheBooks_BookId",
                table: "UserActionsOnTheBooks",
                column: "BookId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_UserActionsOnTheBooks_BookId",
                table: "UserActionsOnTheBooks");

            migrationBuilder.CreateIndex(
                name: "IX_UserActionsOnTheBooks_BookId",
                table: "UserActionsOnTheBooks",
                column: "BookId",
                unique: true);
        }
    }
}
