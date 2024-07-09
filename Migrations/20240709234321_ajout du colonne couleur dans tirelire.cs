using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TirelireWebApp.Migrations
{
    /// <inheritdoc />
    public partial class ajoutducolonnecouleurdanstirelire : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CouleurPrincipale",
                table: "DetailTireliresSet");

            migrationBuilder.AddColumn<string>(
                name: "Couleur",
                table: "TirelireSet",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "TirelireSet",
                keyColumn: "Id",
                keyValue: 1,
                column: "Couleur",
                value: "Vert pomme");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Couleur",
                table: "TirelireSet");

            migrationBuilder.AddColumn<string>(
                name: "CouleurPrincipale",
                table: "DetailTireliresSet",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "DetailTireliresSet",
                keyColumn: "Id",
                keyValue: 1,
                column: "CouleurPrincipale",
                value: "vert pomme");

            migrationBuilder.UpdateData(
                table: "DetailTireliresSet",
                keyColumn: "Id",
                keyValue: 2,
                column: "CouleurPrincipale",
                value: "vert pomme");

            migrationBuilder.UpdateData(
                table: "DetailTireliresSet",
                keyColumn: "Id",
                keyValue: 3,
                column: "CouleurPrincipale",
                value: "vert pomme");
        }
    }
}
