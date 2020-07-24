using Microsoft.EntityFrameworkCore.Migrations;

namespace Brokerage.Data.Migrations
{
    public partial class seedDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Makes (Name) VALUES ('Abay')");
            migrationBuilder.Sql("INSERT INTO Makes (Name) VALUES ('Audi')");
            migrationBuilder.Sql("INSERT INTO Makes (Name) VALUES ('BMW')");
            migrationBuilder.Sql("INSERT INTO Makes (Name) VALUES ('Ford')");
            migrationBuilder.Sql("INSERT INTO Makes (Name) VALUES ('Honda')");
            migrationBuilder.Sql("INSERT INTO Makes (Name) VALUES ('Hyundai')");
            migrationBuilder.Sql("INSERT INTO Makes (Name) VALUES ('Kia')");
            migrationBuilder.Sql("INSERT INTO Makes (Name) VALUES ('Mazda')");
            migrationBuilder.Sql("INSERT INTO Makes (Name) VALUES ('Mercedes - Benz')");
            migrationBuilder.Sql("INSERT INTO Makes (Name) VALUES ('Mitsubishi')");
            migrationBuilder.Sql("INSERT INTO Makes (Name) VALUES ('Nissan')");
            migrationBuilder.Sql("INSERT INTO Makes (Name) VALUES ('Suzuki')");
            migrationBuilder.Sql("INSERT INTO Makes (Name) VALUES ('Toyota')");
            migrationBuilder.Sql("INSERT INTO Makes (Name) VALUES ('Volkswagen')");
            migrationBuilder.Sql("INSERT INTO Makes (Name) VALUES ('Volvo')");
            migrationBuilder.Sql("INSERT INTO Models (Name, MakeId) VALUES ('Abay Excutive', (SELECT ID FROM Makes WHERE Name = 'Abay'))");
            migrationBuilder.Sql("INSERT INTO Models (Name, MakeId) VALUES ('Audi Q2', (SELECT ID FROM Makes WHERE Name = 'Audi'))");
            migrationBuilder.Sql("INSERT INTO Models (Name, MakeId) VALUES ('BMW 2 Series', (SELECT ID FROM Makes WHERE Name = 'BMW'))");
            migrationBuilder.Sql("INSERT INTO Models (Name, MakeId) VALUES ('BMW 3 Series', (SELECT ID FROM Makes WHERE Name = 'BMW'))");
            migrationBuilder.Sql("INSERT INTO Models (Name, MakeId) VALUES ('F-150', (SELECT ID FROM Makes WHERE Name = 'Ford'))");
            migrationBuilder.Sql("INSERT INTO Models (Name, MakeId) VALUES ('Fiesta', (SELECT ID FROM Makes WHERE Name = 'Ford'))");
            migrationBuilder.Sql("INSERT INTO Models (Name, MakeId) VALUES ('Accord', (SELECT ID FROM Makes WHERE Name = 'Honda'))");
            migrationBuilder.Sql("INSERT INTO Models (Name, MakeId) VALUES ('Civic', (SELECT ID FROM Makes WHERE Name = 'Honda'))");
            migrationBuilder.Sql("INSERT INTO Models (Name, MakeId) VALUES ('Accent', (SELECT ID FROM Makes WHERE Name = 'Hyundai'))");
            migrationBuilder.Sql("INSERT INTO Models (Name, MakeId) VALUES ('Elantra', (SELECT ID FROM Makes WHERE Name = 'Hyundai'))");
            migrationBuilder.Sql("INSERT INTO Models (Name, MakeId) VALUES ('Tucson', (SELECT ID FROM Makes WHERE Name = 'Hyundai'))");
            migrationBuilder.Sql("INSERT INTO Models (Name, MakeId) VALUES ('Optima', (SELECT ID FROM Makes WHERE Name = 'Kia'))");
            migrationBuilder.Sql("INSERT INTO Models (Name, MakeId) VALUES ('Sportage',(SELECT ID FROM Makes WHERE Name = 'Kia'))");
            migrationBuilder.Sql("INSERT INTO Models (Name, MakeId) VALUES ('CX-3',(SELECT ID FROM Makes WHERE Name = 'Mazda'))");
            migrationBuilder.Sql("INSERT INTO Models (Name, MakeId) VALUES ('CX-30',(SELECT ID FROM Makes WHERE Name = 'Mazda'))");
            migrationBuilder.Sql("INSERT INTO Models (Name, MakeId) VALUES ('AMG GT',(SELECT ID FROM Makes WHERE Name = 'Mercedes - Benz'))");
            migrationBuilder.Sql("INSERT INTO Models (Name, MakeId) VALUES ('C-Class',(SELECT ID FROM Makes WHERE Name = 'Mercedes - Benz'))");
            migrationBuilder.Sql("INSERT INTO Models (Name, MakeId) VALUES ('CLA',(SELECT ID FROM Makes WHERE Name = 'Mercedes - Benz'))");
            migrationBuilder.Sql("INSERT INTO Models (Name, MakeId) VALUES ('E-Class', (SELECT ID FROM Makes WHERE Name = 'Mercedes - Benz'))");
            migrationBuilder.Sql("INSERT INTO Models (Name, MakeId) VALUES ('Mirage', (SELECT ID FROM Makes WHERE Name = 'Mitsubishi'))");
            migrationBuilder.Sql("INSERT INTO Models (Name, MakeId) VALUES ('Outlander', (SELECT ID FROM Makes WHERE Name = 'Mitsubishi'))");
            migrationBuilder.Sql("INSERT INTO Models (Name, MakeId) VALUES ('Altima',(SELECT ID FROM Makes WHERE Name = 'Nissan'))");
            migrationBuilder.Sql("INSERT INTO Models (Name, MakeId) VALUES ('Maxima',(SELECT ID FROM Makes WHERE Name = 'Nissan'))");
            migrationBuilder.Sql("INSERT INTO Models (Name, MakeId) VALUES ('Murano',(SELECT ID FROM Makes WHERE Name = 'Nissan'))");
            migrationBuilder.Sql("INSERT INTO Models (Name, MakeId) VALUES ('Titan',(SELECT ID FROM Makes WHERE Name = 'Nissan'))");
            migrationBuilder.Sql("INSERT INTO Models (Name, MakeId) VALUES ('Swift',(SELECT ID FROM Makes WHERE Name = 'Suzuki'))");
            migrationBuilder.Sql("INSERT INTO Models (Name, MakeId) VALUES ('Vitara',(SELECT ID FROM Makes WHERE Name = 'Suzuki'))");
            migrationBuilder.Sql("INSERT INTO Models (Name, MakeId) VALUES ('Land Cruiser',(SELECT ID FROM Makes WHERE Name = 'Toyota'))");
            migrationBuilder.Sql("INSERT INTO Models (Name, MakeId) VALUES ('Highlander',(SELECT ID FROM Makes WHERE Name = 'Toyota'))");
            migrationBuilder.Sql("INSERT INTO Models (Name, MakeId) VALUES ('Avalon',(SELECT ID FROM Makes WHERE Name = 'Toyota'))");
            migrationBuilder.Sql("INSERT INTO Models (Name, MakeId) VALUES ('Camry',(SELECT ID FROM Makes WHERE Name = 'Toyota'))");
            migrationBuilder.Sql("INSERT INTO Models (Name, MakeId) VALUES ('Corolla',(SELECT ID FROM Makes WHERE Name = 'Toyota'))");
            migrationBuilder.Sql("INSERT INTO Models (Name, MakeId) VALUES ('Yaris',(SELECT ID FROM Makes WHERE Name = 'Toyota'))");
            migrationBuilder.Sql("INSERT INTO Models (Name, MakeId) VALUES ('Beetle',(SELECT ID FROM Makes WHERE Name = 'Volkswagen'))");
            migrationBuilder.Sql("INSERT INTO Models (Name, MakeId) VALUES ('Golf',(SELECT ID FROM Makes WHERE Name = 'Volkswagen'))");
            migrationBuilder.Sql("INSERT INTO Models (Name, MakeId) VALUES ('Passat',(SELECT ID FROM Makes WHERE Name = 'Volkswagen'))");
            migrationBuilder.Sql("INSERT INTO Models (Name, MakeId) VALUES ('V90',(SELECT ID FROM Makes WHERE Name = 'Volvo'))");
            migrationBuilder.Sql("INSERT INTO Models (Name, MakeId) VALUES ('XC90',(SELECT ID FROM Makes WHERE Name = 'Volvo'))");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE From Makes");
        }
    }
}
