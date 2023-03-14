using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations.Library
{
    public partial class InitialCreateLibrary : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PageCount = table.Column<int>(type: "int", nullable: false),
                    Count = table.Column<int>(type: "int", nullable: false),
                    AuthorName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserActionsOnTheBooks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BookId = table.Column<int>(type: "int", nullable: false),
                    StatusOfTheBook = table.Column<int>(type: "int", nullable: false),
                    ReserveDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeliveryDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ReturnDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserActionsOnTheBooks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserActionsOnTheBooks_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "AuthorName", "Count", "Name", "PageCount" },
                values: new object[] { 1, "Esra ARAÇ", 3, "Yazılım Öğreniyorum", 350 });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "AuthorName", "Count", "Name", "PageCount" },
                values: new object[] { 2, "Esra ARAÇ", 5, "Yazılım Öğreniyorum2", 300 });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "AuthorName", "Count", "Name", "PageCount" },
                values: new object[] { 3, "Esra ARAÇ", 2, "Yazılım Öğreniyorum 3", 200 });

            migrationBuilder.CreateIndex(
                name: "IX_UserActionsOnTheBooks_BookId",
                table: "UserActionsOnTheBooks",
                column: "BookId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserActionsOnTheBooks");

            migrationBuilder.DropTable(
                name: "Books");
        }
    }
}
