using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FirstPro.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Country",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Country", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "City",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CountryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_City", x => x.Id);
                    table.ForeignKey(
                        name: "FK_City_Country_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Country",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Person",
                columns: table => new
                {
                    PersonId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CityId = table.Column<int>(type: "int", nullable: false),
                    LangId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person", x => x.PersonId);
                    table.ForeignKey(
                        name: "FK_Person_City_CityId",
                        column: x => x.CityId,
                        principalTable: "City",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Language",
                columns: table => new
                {
                    LangId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PersonId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Language", x => x.LangId);
                    table.ForeignKey(
                        name: "FK_Language_Person_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Person",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Country",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Italy" });

            migrationBuilder.InsertData(
                table: "Country",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "Spain" });

            migrationBuilder.InsertData(
                table: "Country",
                columns: new[] { "Id", "Name" },
                values: new object[] { 3, "Sweden" });

            migrationBuilder.InsertData(
                table: "City",
                columns: new[] { "Id", "CountryId", "Name" },
                values: new object[] { 1, 1, "Milano" });

            migrationBuilder.InsertData(
                table: "City",
                columns: new[] { "Id", "CountryId", "Name" },
                values: new object[] { 2, 2, "Barcalona" });

            migrationBuilder.InsertData(
                table: "City",
                columns: new[] { "Id", "CountryId", "Name" },
                values: new object[] { 3, 3, "Stockholm" });

            migrationBuilder.InsertData(
                table: "Person",
                columns: new[] { "PersonId", "CityId", "LangId", "Name", "PhoneNumber" },
                values: new object[] { 1, 1, 1, "Laras", "07000000 " });

            migrationBuilder.InsertData(
                table: "Person",
                columns: new[] { "PersonId", "CityId", "LangId", "Name", "PhoneNumber" },
                values: new object[] { 2, 2, 2, "Roben", "07000000" });

            migrationBuilder.InsertData(
                table: "Person",
                columns: new[] { "PersonId", "CityId", "LangId", "Name", "PhoneNumber" },
                values: new object[] { 3, 3, 3, "Matilda", "07000000" });

            migrationBuilder.InsertData(
                table: "Language",
                columns: new[] { "LangId", "Name", "PersonId" },
                values: new object[] { 1, "Italian", 1 });

            migrationBuilder.InsertData(
                table: "Language",
                columns: new[] { "LangId", "Name", "PersonId" },
                values: new object[] { 2, "Spanish", 2 });

            migrationBuilder.InsertData(
                table: "Language",
                columns: new[] { "LangId", "Name", "PersonId" },
                values: new object[] { 3, "Svenska", 3 });

            migrationBuilder.CreateIndex(
                name: "IX_City_CountryId",
                table: "City",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Language_PersonId",
                table: "Language",
                column: "PersonId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Person_CityId",
                table: "Person",
                column: "CityId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Language");

            migrationBuilder.DropTable(
                name: "Person");

            migrationBuilder.DropTable(
                name: "City");

            migrationBuilder.DropTable(
                name: "Country");
        }
    }
}
