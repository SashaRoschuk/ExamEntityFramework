using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExamEntityFramework.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Publishers",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Publishers", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CountryID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Authors_Countries_CountryID",
                        column: x => x.CountryID,
                        principalTable: "Countries",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    ID = table.Column<decimal>(type: "decimal(20,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Istrilogy = table.Column<bool>(type: "bit", nullable: false),
                    PublicationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    AuthorID = table.Column<int>(type: "int", nullable: false),
                    PublisherID = table.Column<int>(type: "int", nullable: false),
                    GenreID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Books_Authors_AuthorID",
                        column: x => x.AuthorID,
                        principalTable: "Authors",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Books_Genres_GenreID",
                        column: x => x.GenreID,
                        principalTable: "Genres",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Books_Publishers_PublisherID",
                        column: x => x.PublisherID,
                        principalTable: "Publishers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "ID", "Name" },
                values: new object[,]
                {
                    { 1, "Ukraine" },
                    { 2, "United States" }
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "ID", "Name" },
                values: new object[,]
                {
                    { 1, "Fiction" },
                    { 2, "Non-Fiction" }
                });

            migrationBuilder.InsertData(
                table: "Publishers",
                columns: new[] { "ID", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "A major publishing company.", "Penguin Random House" },
                    { 2, "A leading global publisher.", "HarperCollins" }
                });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "ID", "CountryID", "Email", "FirstName", "LastName", "Phone" },
                values: new object[] { 1, 1, "andrey.shevchenko@example.com", "Andrey", "Shevchenko", "123-456-7890" });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "ID", "CountryID", "Email", "FirstName", "LastName", "Phone" },
                values: new object[] { 2, 2, "john.doe@example.com", "John", "Doe", "098-765-4321" });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "ID", "AuthorID", "Description", "GenreID", "Istrilogy", "Name", "PublicationDate", "PublisherID", "Rating" },
                values: new object[] { 1m, 1, "A thrilling adventure story.", 1, true, "The Great Adventure", new DateTime(2023, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 5 });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "ID", "AuthorID", "Description", "GenreID", "Istrilogy", "Name", "PublicationDate", "PublisherID", "Rating" },
                values: new object[] { 2m, 2, "An exploration of modern scientific concepts.", 2, false, "Science Unveiled", new DateTime(2024, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 4 });

            migrationBuilder.CreateIndex(
                name: "IX_Authors_CountryID",
                table: "Authors",
                column: "CountryID");

            migrationBuilder.CreateIndex(
                name: "IX_Books_AuthorID",
                table: "Books",
                column: "AuthorID");

            migrationBuilder.CreateIndex(
                name: "IX_Books_GenreID",
                table: "Books",
                column: "GenreID");

            migrationBuilder.CreateIndex(
                name: "IX_Books_PublisherID",
                table: "Books",
                column: "PublisherID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Authors");

            migrationBuilder.DropTable(
                name: "Genres");

            migrationBuilder.DropTable(
                name: "Publishers");

            migrationBuilder.DropTable(
                name: "Countries");
        }
    }
}
