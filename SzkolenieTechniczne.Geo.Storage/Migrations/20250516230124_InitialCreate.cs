using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SzkolenieTechniczne.Geo.Storage.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Geo");

            migrationBuilder.CreateTable(
                name: "Countries",
                schema: "Geo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Alpha3Code = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                schema: "Geo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CountryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cities_Countries_CountryId",
                        column: x => x.CountryId,
                        principalSchema: "Geo",
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CountryTranslations",
                schema: "Geo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CountryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    LanguageCode = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CountryTranslations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CountryTranslations_Countries_CountryId",
                        column: x => x.CountryId,
                        principalSchema: "Geo",
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CityTranslactions",
                schema: "Geo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Cityid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    LanguageCode = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CityTranslactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CityTranslactions_Cities_Cityid",
                        column: x => x.Cityid,
                        principalSchema: "Geo",
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cities_CountryId",
                schema: "Geo",
                table: "Cities",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_CityTranslactions_Cityid",
                schema: "Geo",
                table: "CityTranslactions",
                column: "Cityid");

            migrationBuilder.CreateIndex(
                name: "IX_CityTranslactions_LanguageCode",
                schema: "Geo",
                table: "CityTranslactions",
                column: "LanguageCode");

            migrationBuilder.CreateIndex(
                name: "IX_CityTranslactions_Name",
                schema: "Geo",
                table: "CityTranslactions",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_Countries_Alpha3Code",
                schema: "Geo",
                table: "Countries",
                column: "Alpha3Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CountryTranslations_CountryId",
                schema: "Geo",
                table: "CountryTranslations",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_CountryTranslations_LanguageCode",
                schema: "Geo",
                table: "CountryTranslations",
                column: "LanguageCode");

            migrationBuilder.CreateIndex(
                name: "IX_CountryTranslations_Name",
                schema: "Geo",
                table: "CountryTranslations",
                column: "Name");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CityTranslactions",
                schema: "Geo");

            migrationBuilder.DropTable(
                name: "CountryTranslations",
                schema: "Geo");

            migrationBuilder.DropTable(
                name: "Cities",
                schema: "Geo");

            migrationBuilder.DropTable(
                name: "Countries",
                schema: "Geo");
        }
    }
}
