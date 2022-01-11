using Microsoft.EntityFrameworkCore.Migrations;

namespace ContentAPI.Migrations.Book
{
    public partial class BookTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Title = table.Column<string>(type: "varchar(767)", nullable: false),
                    Gender = table.Column<string>(type: "text", nullable: false),
                    Writer = table.Column<string>(type: "text", nullable: false),
                    Pages = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Title);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books");
        }
    }
}
