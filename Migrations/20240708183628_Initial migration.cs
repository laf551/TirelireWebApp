using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TirelireWebApp.Migrations
{
    /// <inheritdoc />
    public partial class Initialmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DetailTireliresSet",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Hauteur = table.Column<double>(type: "float", nullable: false),
                    Largeur = table.Column<double>(type: "float", nullable: false),
                    Longeur = table.Column<double>(type: "float", nullable: false),
                    Poids = table.Column<double>(type: "float", nullable: false),
                    Capacité = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CouleurPrincipale = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Fabricant = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetailTireliresSet", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TirelireSet",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameTirelire = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PriceTirelire = table.Column<double>(type: "float", nullable: false),
                    ImageUrlTirelire = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TirelireSet", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DescriptionSet",
                columns: table => new
                {
                    IdTirelire = table.Column<int>(type: "int", nullable: false),
                    IdDetail = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DescriptionSet", x => new { x.IdTirelire, x.IdDetail });
                    table.ForeignKey(
                        name: "FK_DescriptionSet_DetailTireliresSet_IdDetail",
                        column: x => x.IdDetail,
                        principalTable: "DetailTireliresSet",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DescriptionSet_TirelireSet_IdTirelire",
                        column: x => x.IdTirelire,
                        principalTable: "TirelireSet",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "DetailTireliresSet",
                columns: new[] { "Id", "Capacité", "CouleurPrincipale", "Fabricant", "Hauteur", "Largeur", "Longeur", "Poids" },
                values: new object[,]
                {
                    { 1, "petit format", "vert pomme", "Robert", 5.0, 5.0, 5.0, 0.5 },
                    { 2, "moyen format", "vert pomme", "Robert", 10.0, 10.0, 10.0, 1.0 },
                    { 3, "grand format", "vert pomme", "Robert", 15.0, 15.0, 15.0, 1.5 }
                });

            migrationBuilder.InsertData(
                table: "TirelireSet",
                columns: new[] { "Id", "ImageUrlTirelire", "NameTirelire", "PriceTirelire" },
                values: new object[] { 1, "https://www.allbranded.fr/out/shop-fr/pictures/generated/product/1/480_480_80/mo8132-48.jpg", "Tirelire Cochon", 19.989999999999998 });

            migrationBuilder.InsertData(
                table: "DescriptionSet",
                columns: new[] { "IdDetail", "IdTirelire" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_DescriptionSet_IdDetail",
                table: "DescriptionSet",
                column: "IdDetail");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DescriptionSet");

            migrationBuilder.DropTable(
                name: "DetailTireliresSet");

            migrationBuilder.DropTable(
                name: "TirelireSet");
        }
    }
}
