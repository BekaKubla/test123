using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication5.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Scrapper",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WebSiteName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HouseId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SquareMeter = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PriceOneSquareMeter = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PriceInUsd = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Scrapper", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Scrapper");
        }
    }
}
