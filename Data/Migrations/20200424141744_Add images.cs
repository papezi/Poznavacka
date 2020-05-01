using Microsoft.EntityFrameworkCore.Migrations;

namespace Poznavacka.Migrations
{
    public partial class Addimages : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ImgPathClass");

            migrationBuilder.CreateTable(
                name: "ImgDb",
                columns: table => new
                {
                    ImgID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImgPath = table.Column<string>(maxLength: 1000, nullable: false),
                    ImgDescription = table.Column<string>(maxLength: 1000, nullable: true),
                    ImgType = table.Column<string>(maxLength: 1000, nullable: true),
                    SpeciesTID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImgDb", x => x.ImgID);
                    table.ForeignKey(
                        name: "FK_ImgDb_SpeciesT_SpeciesTID",
                        column: x => x.SpeciesTID,
                        principalTable: "SpeciesT",
                        principalColumn: "SpeciesTID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ImgDb_SpeciesTID",
                table: "ImgDb",
                column: "SpeciesTID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ImgDb");

            migrationBuilder.CreateTable(
                name: "ImgPathClass",
                columns: table => new
                {
                    ImgPathID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImgPath = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    SpeciesTID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImgPathClass", x => x.ImgPathID);
                    table.ForeignKey(
                        name: "FK_ImgPathClass_SpeciesT_SpeciesTID",
                        column: x => x.SpeciesTID,
                        principalTable: "SpeciesT",
                        principalColumn: "SpeciesTID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ImgPathClass_SpeciesTID",
                table: "ImgPathClass",
                column: "SpeciesTID");
        }
    }
}
