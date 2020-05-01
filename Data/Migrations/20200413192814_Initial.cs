using Microsoft.EntityFrameworkCore.Migrations;

namespace Poznavacka.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Kingdoms",
                columns: table => new
                {
                    KingdomTID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kingdoms", x => x.KingdomTID);
                });

            migrationBuilder.CreateTable(
                name: "PhylumT",
                columns: table => new
                {
                    PhylumTID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    KingdomTID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhylumT", x => x.PhylumTID);
                    table.ForeignKey(
                        name: "FK_PhylumT_Kingdoms_KingdomTID",
                        column: x => x.KingdomTID,
                        principalTable: "Kingdoms",
                        principalColumn: "KingdomTID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClassT",
                columns: table => new
                {
                    ClassTID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    PhylumTID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassT", x => x.ClassTID);
                    table.ForeignKey(
                        name: "FK_ClassT_PhylumT_PhylumTID",
                        column: x => x.PhylumTID,
                        principalTable: "PhylumT",
                        principalColumn: "PhylumTID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderT",
                columns: table => new
                {
                    OrderTID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    ClassTID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderT", x => x.OrderTID);
                    table.ForeignKey(
                        name: "FK_OrderT_ClassT_ClassTID",
                        column: x => x.ClassTID,
                        principalTable: "ClassT",
                        principalColumn: "ClassTID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FamilyT",
                columns: table => new
                {
                    FamilyTID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    OrderTID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FamilyT", x => x.FamilyTID);
                    table.ForeignKey(
                        name: "FK_FamilyT_OrderT_OrderTID",
                        column: x => x.OrderTID,
                        principalTable: "OrderT",
                        principalColumn: "OrderTID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GenusT",
                columns: table => new
                {
                    GenusTID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    FamilyTID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GenusT", x => x.GenusTID);
                    table.ForeignKey(
                        name: "FK_GenusT_FamilyT_FamilyTID",
                        column: x => x.FamilyTID,
                        principalTable: "FamilyT",
                        principalColumn: "FamilyTID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SpeciesT",
                columns: table => new
                {
                    SpeciesTID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GenusTID = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Description = table.Column<string>(maxLength: 1000, nullable: true),
                    Size = table.Column<string>(maxLength: 200, nullable: true),
                    ImgPath = table.Column<string>(maxLength: 1000, nullable: true),
                    Use = table.Column<string>(maxLength: 500, nullable: true),
                    OccurenceCR = table.Column<int>(nullable: false),
                    Protection = table.Column<int>(nullable: false),
                    EcoFunction = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpeciesT", x => x.SpeciesTID);
                    table.ForeignKey(
                        name: "FK_SpeciesT_GenusT_GenusTID",
                        column: x => x.GenusTID,
                        principalTable: "GenusT",
                        principalColumn: "GenusTID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EcosystemEnumClass",
                columns: table => new
                {
                    EcosystemID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ecosystem = table.Column<int>(nullable: false),
                    SpeciesTID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EcosystemEnumClass", x => x.EcosystemID);
                    table.ForeignKey(
                        name: "FK_EcosystemEnumClass_SpeciesT_SpeciesTID",
                        column: x => x.SpeciesTID,
                        principalTable: "SpeciesT",
                        principalColumn: "SpeciesTID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OccurenceWorldEnumClass",
                columns: table => new
                {
                    OccurenceWID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OccurenceWorld = table.Column<int>(nullable: false),
                    SpeciesTID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OccurenceWorldEnumClass", x => x.OccurenceWID);
                    table.ForeignKey(
                        name: "FK_OccurenceWorldEnumClass_SpeciesT_SpeciesTID",
                        column: x => x.SpeciesTID,
                        principalTable: "SpeciesT",
                        principalColumn: "SpeciesTID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClassT_PhylumTID",
                table: "ClassT",
                column: "PhylumTID");

            migrationBuilder.CreateIndex(
                name: "IX_EcosystemEnumClass_SpeciesTID",
                table: "EcosystemEnumClass",
                column: "SpeciesTID");

            migrationBuilder.CreateIndex(
                name: "IX_FamilyT_OrderTID",
                table: "FamilyT",
                column: "OrderTID");

            migrationBuilder.CreateIndex(
                name: "IX_GenusT_FamilyTID",
                table: "GenusT",
                column: "FamilyTID");

            migrationBuilder.CreateIndex(
                name: "IX_OccurenceWorldEnumClass_SpeciesTID",
                table: "OccurenceWorldEnumClass",
                column: "SpeciesTID");

            migrationBuilder.CreateIndex(
                name: "IX_OrderT_ClassTID",
                table: "OrderT",
                column: "ClassTID");

            migrationBuilder.CreateIndex(
                name: "IX_PhylumT_KingdomTID",
                table: "PhylumT",
                column: "KingdomTID");

            migrationBuilder.CreateIndex(
                name: "IX_SpeciesT_GenusTID",
                table: "SpeciesT",
                column: "GenusTID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EcosystemEnumClass");

            migrationBuilder.DropTable(
                name: "OccurenceWorldEnumClass");

            migrationBuilder.DropTable(
                name: "SpeciesT");

            migrationBuilder.DropTable(
                name: "GenusT");

            migrationBuilder.DropTable(
                name: "FamilyT");

            migrationBuilder.DropTable(
                name: "OrderT");

            migrationBuilder.DropTable(
                name: "ClassT");

            migrationBuilder.DropTable(
                name: "PhylumT");

            migrationBuilder.DropTable(
                name: "Kingdoms");
        }
    }
}
