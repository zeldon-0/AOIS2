using Microsoft.EntityFrameworkCore.Migrations;

namespace AOIS2.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "KanjisWithReading",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Kanji = table.Column<string>(maxLength: 1, nullable: false),
                    Reading = table.Column<string>(nullable: true),
                    JLPTLevel = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KanjisWithReading", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "KanjisWithReadingAndWords",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Kanji = table.Column<string>(maxLength: 1, nullable: false),
                    Reading = table.Column<string>(nullable: false),
                    Strokes = table.Column<int>(nullable: false),
                    Words = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KanjisWithReadingAndWords", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "KanjisWithWords",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Kanji = table.Column<string>(maxLength: 1, nullable: false),
                    TaughtInGrade = table.Column<int>(nullable: false),
                    Strokes = table.Column<int>(nullable: false),
                    Words = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KanjisWithWords", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Radicals",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Character = table.Column<string>(maxLength: 1, nullable: false),
                    Strokes = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Radicals", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "KanjiWithReadingAndWordsRadical",
                columns: table => new
                {
                    RadicalId = table.Column<int>(nullable: false),
                    KanjiWithReadingAndWordsId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KanjiWithReadingAndWordsRadical", x => new { x.KanjiWithReadingAndWordsId, x.RadicalId });
                    table.ForeignKey(
                        name: "FK_KanjiWithReadingAndWordsRadical_KanjisWithReadingAndWords_KanjiWithReadingAndWordsId",
                        column: x => x.KanjiWithReadingAndWordsId,
                        principalTable: "KanjisWithReadingAndWords",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KanjiWithReadingAndWordsRadical_Radicals_RadicalId",
                        column: x => x.RadicalId,
                        principalTable: "Radicals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "KanjiWithReadingRadical",
                columns: table => new
                {
                    RadicalId = table.Column<int>(nullable: false),
                    KanjiWithReadingId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KanjiWithReadingRadical", x => new { x.KanjiWithReadingId, x.RadicalId });
                    table.ForeignKey(
                        name: "FK_KanjiWithReadingRadical_KanjisWithReading_KanjiWithReadingId",
                        column: x => x.KanjiWithReadingId,
                        principalTable: "KanjisWithReading",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KanjiWithReadingRadical_Radicals_RadicalId",
                        column: x => x.RadicalId,
                        principalTable: "Radicals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "KanjiWithWordsRadical",
                columns: table => new
                {
                    RadicalId = table.Column<int>(nullable: false),
                    KanjiWithWordsId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KanjiWithWordsRadical", x => new { x.KanjiWithWordsId, x.RadicalId });
                    table.ForeignKey(
                        name: "FK_KanjiWithWordsRadical_KanjisWithWords_KanjiWithWordsId",
                        column: x => x.KanjiWithWordsId,
                        principalTable: "KanjisWithWords",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KanjiWithWordsRadical_Radicals_RadicalId",
                        column: x => x.RadicalId,
                        principalTable: "Radicals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_KanjiWithReadingAndWordsRadical_RadicalId",
                table: "KanjiWithReadingAndWordsRadical",
                column: "RadicalId");

            migrationBuilder.CreateIndex(
                name: "IX_KanjiWithReadingRadical_RadicalId",
                table: "KanjiWithReadingRadical",
                column: "RadicalId");

            migrationBuilder.CreateIndex(
                name: "IX_KanjiWithWordsRadical_RadicalId",
                table: "KanjiWithWordsRadical",
                column: "RadicalId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "KanjiWithReadingAndWordsRadical");

            migrationBuilder.DropTable(
                name: "KanjiWithReadingRadical");

            migrationBuilder.DropTable(
                name: "KanjiWithWordsRadical");

            migrationBuilder.DropTable(
                name: "KanjisWithReadingAndWords");

            migrationBuilder.DropTable(
                name: "KanjisWithReading");

            migrationBuilder.DropTable(
                name: "KanjisWithWords");

            migrationBuilder.DropTable(
                name: "Radicals");
        }
    }
}
