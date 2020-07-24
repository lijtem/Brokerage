using Microsoft.EntityFrameworkCore.Migrations;

namespace Brokerage.Data.Migrations
{
    public partial class SeedFeatures : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Features (Name) VALUES ('ABS')");
            migrationBuilder.Sql("INSERT INTO Features (Name) VALUES ('Air Bags')");
            migrationBuilder.Sql("INSERT INTO Features (Name) VALUES ('Air Conditioning')");
            migrationBuilder.Sql("INSERT INTO Features (Name) VALUES ('Alarm System')");
            migrationBuilder.Sql("INSERT INTO Features (Name) VALUES ('Aluminium Rims')");
            migrationBuilder.Sql("INSERT INTO Features (Name) VALUES ('AM/FM Radio')");
            migrationBuilder.Sql("INSERT INTO Features (Name) VALUES ('Cassette Player')");
            migrationBuilder.Sql("INSERT INTO Features (Name) VALUES ('CD Player')");
            migrationBuilder.Sql("INSERT INTO Features (Name) VALUES ('Central Lock')");
            migrationBuilder.Sql("INSERT INTO Features (Name) VALUES ('Cool Box')");
            migrationBuilder.Sql("INSERT INTO Features (Name) VALUES ('Cruise Control')");
            migrationBuilder.Sql("INSERT INTO Features (Name) VALUES ('DVD Player')");
            migrationBuilder.Sql("INSERT INTO Features (Name) VALUES ('Power Locks')");
            migrationBuilder.Sql("INSERT INTO Features (Name) VALUES ('Power Mirrors')");
            migrationBuilder.Sql("INSERT INTO Features (Name) VALUES ('Power Steering')");
            migrationBuilder.Sql("INSERT INTO Features (Name) VALUES ('Power Windows')");
            migrationBuilder.Sql("INSERT INTO Features (Name) VALUES ('Reversing Camera')");
            migrationBuilder.Sql("INSERT INTO Features (Name) VALUES ('Turbo Charger')");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Features WHERE Name IN ('ABS','Air Bags','Air Conditioning','Alarm System','Aluminium Rims','AM/FM Radio','Cassette Player','CD Player','Central Lock','Cool Box','Cruise Control','DVD Player','Power Locks','Power Mirrors','Power Steering','Power Window', 'Turbo Charger')");
        }
    }
}
