using Microsoft.EntityFrameworkCore.Migrations;

namespace Poznavacka.Migrations
{
    public partial class Learnin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LearningSets",
                columns: table => new
                {
                    LearningSetID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Description = table.Column<string>(maxLength: 1000, nullable: true),
                    NumberOfItems = table.Column<int>(nullable: false),
                    Class = table.Column<short>(nullable: false),
                    OccurenceCR = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LearningSets", x => x.LearningSetID);
                });

            migrationBuilder.CreateTable(
                name: "LearningSetItem",
                columns: table => new
                {
                    LearningSetItemID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LearningSetID = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Description = table.Column<string>(maxLength: 1000, nullable: true),
                    Classification = table.Column<string>(maxLength: 1000, nullable: true),
                    Size = table.Column<string>(maxLength: 200, nullable: true),
                    Use = table.Column<string>(maxLength: 500, nullable: true),
                    OccurencesWorld = table.Column<string>(maxLength: 1000, nullable: true),
                    Ecosystems = table.Column<string>(maxLength: 1000, nullable: true),
                    OccurenceCR = table.Column<int>(nullable: false),
                    Protection = table.Column<string>(maxLength: 50, nullable: true),
                    EcoFunction = table.Column<string>(maxLength: 50, nullable: true),
                    ImgPath = table.Column<string>(maxLength: 500, nullable: true),
                    ImgDescription = table.Column<string>(maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LearningSetItem", x => x.LearningSetItemID);
                    table.ForeignKey(
                        name: "FK_LearningSetItem_LearningSets_LearningSetID",
                        column: x => x.LearningSetID,
                        principalTable: "LearningSets",
                        principalColumn: "LearningSetID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LearningSetItem_LearningSetID",
                table: "LearningSetItem",
                column: "LearningSetID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LearningSetItem");

            migrationBuilder.DropTable(
                name: "LearningSets");
        }
    }
}
