using Microsoft.EntityFrameworkCore.Migrations;

namespace Brokerage.Data.Migrations
{
    public partial class SeedLocations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Cities (Name) VALUES ('Adama(Nazret)')");
            migrationBuilder.Sql("INSERT INTO Cities (Name) VALUES ('Addis Ababa')");
            migrationBuilder.Sql("INSERT INTO Cities (Name) VALUES ('Bahir Dar')");
            migrationBuilder.Sql("INSERT INTO Cities (Name) VALUES ('Bishoftu(Debre Zeit)')");
            migrationBuilder.Sql("INSERT INTO Cities (Name) VALUES ('Dessie')");
            migrationBuilder.Sql("INSERT INTO Cities (Name) VALUES ('Dire Dawa')");
            migrationBuilder.Sql("INSERT INTO Cities (Name) VALUES ('Gonder')");
            migrationBuilder.Sql("INSERT INTO Cities (Name) VALUES ('Hawassa')");
            migrationBuilder.Sql("INSERT INTO Cities (Name) VALUES ('Jimma')");
            migrationBuilder.Sql("INSERT INTO Cities (Name) VALUES ('Mekelle')");
            migrationBuilder.Sql("INSERT INTO Locations (Name, CityId) VALUES ('22 Mazoria', (SELECT ID FROM Cities WHERE Name = 'Addis Ababa'))");
            migrationBuilder.Sql("INSERT INTO Locations (Name, CityId) VALUES ('4 Kilo', (SELECT ID FROM Cities WHERE Name = 'Addis Ababa'))");
            migrationBuilder.Sql("INSERT INTO Locations (Name, CityId) VALUES ('5 kilo', (SELECT ID FROM Cities WHERE Name = 'Addis Ababa'))");
            migrationBuilder.Sql("INSERT INTO Locations (Name, CityId) VALUES ('6 kilo', (SELECT ID FROM Cities WHERE Name = 'Addis Ababa'))");
            migrationBuilder.Sql("INSERT INTO Locations (Name, CityId) VALUES ('Addisu Gebeya', (SELECT ID FROM Cities WHERE Name = 'Addis Ababa'))");
            migrationBuilder.Sql("INSERT INTO Locations (Name, CityId) VALUES ('Akaki', (SELECT ID FROM Cities WHERE Name = 'Addis Ababa'))");
            migrationBuilder.Sql("INSERT INTO Locations (Name, CityId) VALUES ('Alem Gena', (SELECT ID FROM Cities WHERE Name = 'Addis Ababa'))");
            migrationBuilder.Sql("INSERT INTO Locations (Name, CityId) VALUES ('Aware', (SELECT ID FROM Cities WHERE Name = 'Addis Ababa'))");
            migrationBuilder.Sql("INSERT INTO Locations (Name, CityId) VALUES ('Ayat', (SELECT ID FROM Cities WHERE Name = 'Addis Ababa'))");
            migrationBuilder.Sql("INSERT INTO Locations (Name, CityId) VALUES ('Ayer Tena', (SELECT ID FROM Cities WHERE Name = 'Addis Ababa'))");
            migrationBuilder.Sql("INSERT INTO Locations (Name, CityId) VALUES ('Bethel', (SELECT ID FROM Cities WHERE Name = 'Addis Ababa'))");
            migrationBuilder.Sql("INSERT INTO Locations (Name, CityId) VALUES ('Bole', (SELECT ID FROM Cities WHERE Name = 'Addis Ababa'))");
            migrationBuilder.Sql("INSERT INTO Locations (Name, CityId) VALUES ('Bole Bulbula', (SELECT ID FROM Cities WHERE Name = 'Addis Ababa'))");
            migrationBuilder.Sql("INSERT INTO Locations (Name, CityId) VALUES ('Bole Michael', (SELECT ID FROM Cities WHERE Name = 'Addis Ababa'))");
            migrationBuilder.Sql("INSERT INTO Locations (Name, CityId) VALUES ('CMC', (SELECT ID FROM Cities WHERE Name = 'Addis Ababa'))");
            migrationBuilder.Sql("INSERT INTO Locations (Name, CityId) VALUES ('Gerji', (SELECT ID FROM Cities WHERE Name = 'Addis Ababa'))");
            migrationBuilder.Sql("INSERT INTO Locations (Name, CityId) VALUES ('Gullele', (SELECT ID FROM Cities WHERE Name = 'Addis Ababa'))");
            migrationBuilder.Sql("INSERT INTO Locations (Name, CityId) VALUES ('Gurd Shola', (SELECT ID FROM Cities WHERE Name = 'Addis Ababa'))");
            migrationBuilder.Sql("INSERT INTO Locations (Name, CityId) VALUES ('Haya Hulet', (SELECT ID FROM Cities WHERE Name = 'Addis Ababa'))");
            migrationBuilder.Sql("INSERT INTO Locations (Name, CityId) VALUES ('Jemo', (SELECT ID FROM Cities WHERE Name = 'Addis Ababa'))");
            migrationBuilder.Sql("INSERT INTO Locations (Name, CityId) VALUES ('Kality', (SELECT ID FROM Cities WHERE Name = 'Addis Ababa'))");
            migrationBuilder.Sql("INSERT INTO Locations (Name, CityId) VALUES ('Kazanchis', (SELECT ID FROM Cities WHERE Name = 'Addis Ababa'))");
            migrationBuilder.Sql("INSERT INTO Locations (Name, CityId) VALUES ('Kebena', (SELECT ID FROM Cities WHERE Name = 'Addis Ababa'))");
            migrationBuilder.Sql("INSERT INTO Locations (Name, CityId) VALUES ('Kera', (SELECT ID FROM Cities WHERE Name = 'Addis Ababa'))");
            migrationBuilder.Sql("INSERT INTO Locations (Name, CityId) VALUES ('Kore', (SELECT ID FROM Cities WHERE Name = 'Addis Ababa'))");
            migrationBuilder.Sql("INSERT INTO Locations (Name, CityId) VALUES ('Kotebe', (SELECT ID FROM Cities WHERE Name = 'Addis Ababa'))");
            migrationBuilder.Sql("INSERT INTO Locations (Name, CityId) VALUES ('Lafto', (SELECT ID FROM Cities WHERE Name = 'Addis Ababa'))");
            migrationBuilder.Sql("INSERT INTO Locations (Name, CityId) VALUES ('Lanchia', (SELECT ID FROM Cities WHERE Name = 'Addis Ababa'))");
            migrationBuilder.Sql("INSERT INTO Locations (Name, CityId) VALUES ('Lebu', (SELECT ID FROM Cities WHERE Name = 'Addis Ababa'))");
            migrationBuilder.Sql("INSERT INTO Locations (Name, CityId) VALUES ('Legetafo', (SELECT ID FROM Cities WHERE Name = 'Addis Ababa'))");
            migrationBuilder.Sql("INSERT INTO Locations (Name, CityId) VALUES ('Lideta', (SELECT ID FROM Cities WHERE Name = 'Addis Ababa'))");
            migrationBuilder.Sql("INSERT INTO Locations (Name, CityId) VALUES ('Megenagna', (SELECT ID FROM Cities WHERE Name = 'Addis Ababa'))");
            migrationBuilder.Sql("INSERT INTO Locations (Name, CityId) VALUES ('Mekanisa', (SELECT ID FROM Cities WHERE Name = 'Addis Ababa'))");
            migrationBuilder.Sql("INSERT INTO Locations (Name, CityId) VALUES ('Merkato', (SELECT ID FROM Cities WHERE Name = 'Addis Ababa'))");
            migrationBuilder.Sql("INSERT INTO Locations (Name, CityId) VALUES ('Meskel Flower', (SELECT ID FROM Cities WHERE Name = 'Addis Ababa'))");
            migrationBuilder.Sql("INSERT INTO Locations (Name, CityId) VALUES ('Mexico', (SELECT ID FROM Cities WHERE Name = 'Addis Ababa'))");
            migrationBuilder.Sql("INSERT INTO Locations (Name, CityId) VALUES ('Old Air Port', (SELECT ID FROM Cities WHERE Name = 'Addis Ababa'))");
            migrationBuilder.Sql("INSERT INTO Locations (Name, CityId) VALUES ('Olympia', (SELECT ID FROM Cities WHERE Name = 'Addis Ababa'))");
            migrationBuilder.Sql("INSERT INTO Locations (Name, CityId) VALUES ('Piassa', (SELECT ID FROM Cities WHERE Name = 'Addis Ababa'))");
            migrationBuilder.Sql("INSERT INTO Locations (Name, CityId) VALUES ('Sar Bet', (SELECT ID FROM Cities WHERE Name = 'Addis Ababa'))");
            migrationBuilder.Sql("INSERT INTO Locations (Name, CityId) VALUES ('Saris', (SELECT ID FROM Cities WHERE Name = 'Addis Ababa'))");
            migrationBuilder.Sql("INSERT INTO Locations (Name, CityId) VALUES ('Summit', (SELECT ID FROM Cities WHERE Name = 'Addis Ababa'))");
            migrationBuilder.Sql("INSERT INTO Locations (Name, CityId) VALUES ('Tor Hailoch', (SELECT ID FROM Cities WHERE Name = 'Addis Ababa'))");
            migrationBuilder.Sql("INSERT INTO Locations (Name, CityId) VALUES ('Wollo Sefer', (SELECT ID FROM Cities WHERE Name = 'Addis Ababa'))");
            migrationBuilder.Sql("INSERT INTO Locations (Name, CityId) VALUES ('Wossen', (SELECT ID FROM Cities WHERE Name = 'Addis Ababa'))");
            migrationBuilder.Sql("INSERT INTO Locations (Name, CityId) VALUES ('Yeka', (SELECT ID FROM Cities WHERE Name = 'Addis Ababa'))");
            migrationBuilder.Sql("INSERT INTO Locations (Name, CityId) VALUES ('Yeka Abado', (SELECT ID FROM Cities WHERE Name = 'Addis Ababa'))");
            migrationBuilder.Sql("INSERT INTO Locations (Name, CityId) VALUES ('- Any -', (SELECT ID FROM Cities WHERE Name = 'Addis Ababa'))");
            migrationBuilder.Sql("INSERT INTO Locations (Name, CityId) VALUES ('- Any -', (SELECT ID FROM Cities WHERE Name = 'Adama(Nazret)'))");
            migrationBuilder.Sql("INSERT INTO Locations (Name, CityId) VALUES ('- Any -', (SELECT ID FROM Cities WHERE Name = 'Bahir Dar'))");
            migrationBuilder.Sql("INSERT INTO Locations (Name, CityId) VALUES ('- Any -', (SELECT ID FROM Cities WHERE Name = 'Bishoftu(Debre Zeit)'))");
            migrationBuilder.Sql("INSERT INTO Locations (Name, CityId) VALUES ('- Any -', (SELECT ID FROM Cities WHERE Name = 'Dessie'))");
            migrationBuilder.Sql("INSERT INTO Locations (Name, CityId) VALUES ('- Any -', (SELECT ID FROM Cities WHERE Name = 'Dire Dawa'))");
            migrationBuilder.Sql("INSERT INTO Locations (Name, CityId) VALUES ('- Any -', (SELECT ID FROM Cities WHERE Name = 'Gonder'))");
            migrationBuilder.Sql("INSERT INTO Locations (Name, CityId) VALUES ('- Any -', (SELECT ID FROM Cities WHERE Name = 'Hawassa'))");
            migrationBuilder.Sql("INSERT INTO Locations (Name, CityId) VALUES ('- Any -', (SELECT ID FROM Cities WHERE Name = 'Jimma'))");
            migrationBuilder.Sql("INSERT INTO Locations (Name, CityId) VALUES ('- Any -', (SELECT ID FROM Cities WHERE Name = 'Mekelle'))");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
