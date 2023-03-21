using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieMVC.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    MovieId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MovieName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    About = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReleaseDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.MovieId);
                    table.ForeignKey(
                        name: "FK_Movies_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryName", "Description" },
                values: new object[] { 1, "Science Fiction", "Science fiction (or sci-fi) is a film genre that uses speculative, fictional science-based depictions of phenomena that are not fully accepted by mainstream science, such as extraterrestrial lifeforms, spacecraft, robots, cyborgs, dinosaurs, mutants, interstellar travel, time travel, or other technologies." });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryName", "Description" },
                values: new object[] { 2, "Comedy", "A favorite genre of film audiences young and old since the very beginning of cinema, the comedy genre has been a fun-loving, sophisticated, and innovative genre that’s delighted viewers. Some of the biggest names in the history of filmmaking include comedy genre pioneers—like Buster Keaton, Charlie Chaplin, and Lucille Ball—who made successful careers out of finding new and unique ways to make audiences laugh." });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryName", "Description" },
                values: new object[] { 3, "Action", "One of the earliest film genres, the action genre, has close ties to classic strife and struggle narratives that you find across all manner of art and literature. With some of the earliest examples dating back to everything from historical war epics to some basic portrayals of dastardly train robberies, action films have been popular with cinema audiences since the very beginning." });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "MovieId", "About", "CategoryId", "MovieName", "ReleaseDate" },
                values: new object[] { 1, "Set in a dystopian future where humanity is struggling to survive, the film follows a group of astronauts who travel through a wormhole near Saturn in search of a new home for mankind.", 1, "Interstellar", new DateTime(2014, 11, 7, 19, 32, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "MovieId", "About", "CategoryId", "MovieName", "ReleaseDate" },
                values: new object[] { 2, "Bank clerk Stanley Ipkiss is transformed into a manic superhero when he wears a mysterious mask.", 2, "The Mask", new DateTime(1994, 6, 10, 18, 24, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "MovieId", "About", "CategoryId", "MovieName", "ReleaseDate" },
                values: new object[] { 3, "With the help of a German bounty-hunter, a freed slave sets out to rescue his wife from a brutal plantation owner in Mississippi.", 3, "Django Unchained", new DateTime(2012, 2, 19, 23, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.CreateIndex(
                name: "IX_Movies_CategoryId",
                table: "Movies",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Movies");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
