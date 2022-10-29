using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace TrenRezervasyon.Infrastructure.Migrations
{
    public partial class mig_1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Trenler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Ad = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trenler", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vagonlar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TrenId = table.Column<int>(type: "integer", nullable: false),
                    Ad = table.Column<string>(type: "text", nullable: false),
                    Kapasite = table.Column<int>(type: "integer", nullable: false),
                    DoluKoltukAdet = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vagonlar", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vagonlar_Trenler_TrenId",
                        column: x => x.TrenId,
                        principalTable: "Trenler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Trenler",
                columns: new[] { "Id", "Ad" },
                values: new object[] { 1, "Başkent Ekspres" });

            migrationBuilder.InsertData(
                table: "Vagonlar",
                columns: new[] { "Id", "Ad", "DoluKoltukAdet", "Kapasite", "TrenId" },
                values: new object[,]
                {
                    { 1, "Vagon 1", 68, 100, 1 },
                    { 2, "Vagon 2", 50, 90, 1 },
                    { 3, "Vagon 3", 80, 80, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Vagonlar_TrenId",
                table: "Vagonlar",
                column: "TrenId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Vagonlar");

            migrationBuilder.DropTable(
                name: "Trenler");
        }
    }
}
