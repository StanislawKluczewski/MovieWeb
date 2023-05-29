using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MoviesWeb.WebApi.Migrations
{
    public partial class UpdateMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Actors",
                columns: table => new
                {
                    ActorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Surname = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Sex = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Wiek = table.Column<int>(type: "int", nullable: false),
                    Nationality = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ActorMark = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Actors", x => x.ActorId);
                });

            migrationBuilder.CreateTable(
                name: "Directors",
                columns: table => new
                {
                    DirectorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Surname = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Sex = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Wiek = table.Column<int>(type: "int", nullable: false),
                    Nationality = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DirectorMark = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Directors", x => x.DirectorId);
                });

            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    MovieId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    DateOfProduction = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    MovieLength = table.Column<int>(type: "int", nullable: false),
                    BoxOffice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MovieMark = table.Column<double>(type: "float", nullable: false),
                    ProductionCountry = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.MovieId);
                });

            migrationBuilder.CreateTable(
                name: "ActorMovie",
                columns: table => new
                {
                    ActorMoviesMovieId = table.Column<int>(type: "int", nullable: false),
                    ActorsActorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActorMovie", x => new { x.ActorMoviesMovieId, x.ActorsActorId });
                    table.ForeignKey(
                        name: "FK_ActorMovie_Actors_ActorsActorId",
                        column: x => x.ActorsActorId,
                        principalTable: "Actors",
                        principalColumn: "ActorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ActorMovie_Movies_ActorMoviesMovieId",
                        column: x => x.ActorMoviesMovieId,
                        principalTable: "Movies",
                        principalColumn: "MovieId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ActorMovie_ActorsActorId",
                table: "ActorMovie",
                column: "ActorsActorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActorMovie");

            migrationBuilder.DropTable(
                name: "Directors");

            migrationBuilder.DropTable(
                name: "Actors");

            migrationBuilder.DropTable(
                name: "Movies");
        }
    }
}
