using Microsoft.EntityFrameworkCore.Migrations;

namespace api.Migrations
{
    public class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_users", x => x.Id);
                }
            );

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: true),
                    UserName = table.Column<string>(nullable: true),
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_students", x => x.Id);
                }
            );

            migrationBuilder.CreateTable(
                name: "Workouts",
                columns: table => new 
                { 
                    Id = table.Column<int>(),

                }
            );

        }
    }
}
