using Microsoft.EntityFrameworkCore.Migrations;

namespace Poznavacka.Migrations
{
    public partial class Pathupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImgPath",
                table: "SpeciesT");

            migrationBuilder.CreateTable(
                name: "ImgPathClass",
                columns: table => new
                {
                    ImgPathID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImgPath = table.Column<string>(maxLength: 1000, nullable: true),
                    SpeciesTID = table.Column<int>(nullable: true)
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ImgPathClass");

            migrationBuilder.AddColumn<string>(
                name: "ImgPath",
                table: "SpeciesT",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: true);
        }
    }
}
