using Microsoft.EntityFrameworkCore.Migrations;

namespace Vega.Migrations
{
    public partial class SeedDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Makes (Name) VALUES ('Make1')");
            migrationBuilder.Sql("INSERT INTO Makes (Name) VALUES ('Make2')");
            migrationBuilder.Sql("INSERT INTO Makes (Name) VALUES ('Make3')");

            migrationBuilder.Sql("INSERT INTO Models (Name, MakeId) VALUES ('Model1-ModelA', 1)");
            migrationBuilder.Sql("INSERT INTO Models (Name, MakeId) VALUES ('Model1-ModelB', 1)");
            migrationBuilder.Sql("INSERT INTO Models (Name, MakeId) VALUES ('Model1-ModelC', 1)");

            migrationBuilder.Sql("INSERT INTO Models (Name, MakeId) VALUES ('Model2-ModelA', 2)");
            migrationBuilder.Sql("INSERT INTO Models (Name, MakeId) VALUES ('Model2-ModelB', 2)");
            migrationBuilder.Sql("INSERT INTO Models (Name, MakeId) VALUES ('Model2-ModelC', 2)");

            migrationBuilder.Sql("INSERT INTO Models (Name, MakeId) VALUES ('Model3-ModelA', 3)");
            migrationBuilder.Sql("INSERT INTO Models (Name, MakeId) VALUES ('Model3-ModelB', 3)");
            migrationBuilder.Sql("INSERT INTO Models (Name, MakeId) VALUES ('Model3-ModelC', 3)");


        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Makes");
            migrationBuilder.Sql("DELETE FROM Models");
        }
    }
}
