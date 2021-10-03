using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class Init : Migration
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
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Category", "Name" },
                values: new object[] { 1, "JKL", "Abc" });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Category", "Name" },
                values: new object[] { 2, "MNO", "DEF" });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Category", "Name" },
                values: new object[] { 3, "PQR", "GHI" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books");
        }
    }
}
