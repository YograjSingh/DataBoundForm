using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataBoundForm.Migrations
{
    public partial class BlogMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Author",
                columns: table => new
                {
                    Email = table.Column<string>(nullable: false),
                    Given_name = table.Column<string>(maxLength: 50, nullable: false),
                    Last_name = table.Column<string>(maxLength: 50, nullable: false),
                    Birth_date = table.Column<DateTime>(nullable: false),
                    Website = table.Column<string>(maxLength: 100, nullable: true),
                    Phone = table.Column<string>(maxLength: 20, nullable: true),
                    Country = table.Column<string>(maxLength: 60, nullable: true),
                    Province = table.Column<string>(maxLength: 60, nullable: true),
                    Postal_code = table.Column<string>(maxLength: 15, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Author", x => x.Email);
                });

            migrationBuilder.CreateTable(
                name: "Blog",
                columns: table => new
                {
                    Title = table.Column<string>(maxLength: 500, nullable: false),
                    Content = table.Column<string>(maxLength: 5000, nullable: true),
                    AuthorEmail = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Blog", x => x.Title);
                    table.ForeignKey(
                        name: "FK_Blog_Author_AuthorEmail",
                        column: x => x.AuthorEmail,
                        principalTable: "Author",
                        principalColumn: "Email",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Blog_AuthorEmail",
                table: "Blog",
                column: "AuthorEmail");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Blog");

            migrationBuilder.DropTable(
                name: "Author");
        }
    }
}
