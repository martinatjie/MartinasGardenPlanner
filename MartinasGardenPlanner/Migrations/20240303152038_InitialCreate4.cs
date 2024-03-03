using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MartinasGardenPlanner.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Plants",
                columns: table => new
                {
                    PlantId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CommonName = table.Column<string>(type: "TEXT", nullable: true),
                    ScientificName = table.Column<string>(type: "TEXT", nullable: true),
                    SunRequirement = table.Column<string>(type: "TEXT", nullable: true),
                    IsWaterSmart = table.Column<bool>(type: "INTEGER", nullable: false),
                    HasAggressiveRootSystem = table.Column<bool>(type: "INTEGER", nullable: false),
                    MaxHeight = table.Column<double>(type: "REAL", nullable: false),
                    GrowthRate = table.Column<string>(type: "TEXT", nullable: true),
                    IsDeciduous = table.Column<bool>(type: "INTEGER", nullable: false),
                    BirdsAttract = table.Column<string>(type: "TEXT", nullable: true),
                    PestsProne = table.Column<string>(type: "TEXT", nullable: true),
                    CareInstructions = table.Column<string>(type: "TEXT", nullable: true),
                    SoilType = table.Column<string>(type: "TEXT", nullable: true),
                    IsIndigenous = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsClimber = table.Column<bool>(type: "INTEGER", nullable: false),
                    Color = table.Column<string>(type: "TEXT", nullable: true),
                    IsFlowering = table.Column<bool>(type: "INTEGER", nullable: false),
                    PlantType = table.Column<string>(type: "TEXT", nullable: true),
                    IsPoisonous = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plants", x => x.PlantId);
                });

            migrationBuilder.CreateTable(
                name: "PlantCompanions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CompanionPlantId = table.Column<int>(type: "INTEGER", nullable: false),
                    PlantId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlantCompanions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlantCompanions_Plants_CompanionPlantId",
                        column: x => x.CompanionPlantId,
                        principalTable: "Plants",
                        principalColumn: "PlantId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlantCompanions_Plants_PlantId",
                        column: x => x.PlantId,
                        principalTable: "Plants",
                        principalColumn: "PlantId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PlantCompanions_CompanionPlantId",
                table: "PlantCompanions",
                column: "CompanionPlantId");

            migrationBuilder.CreateIndex(
                name: "IX_PlantCompanions_PlantId",
                table: "PlantCompanions",
                column: "PlantId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlantCompanions");

            migrationBuilder.DropTable(
                name: "Plants");
        }
    }
}
