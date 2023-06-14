using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Exercise7.Migrations
{
    /// <inheritdoc />
    public partial class Init_db : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Project_Status",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Project_Status", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Team",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Team", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Developer",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TeamID = table.Column<int>(type: "int", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Developer", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Developer_Team_TeamID",
                        column: x => x.TeamID,
                        principalTable: "Team",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Project",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Deadline = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProjectStatusID = table.Column<int>(type: "int", nullable: false),
                    DeveloperID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Project", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Project_Developer_DeveloperID",
                        column: x => x.DeveloperID,
                        principalTable: "Developer",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Project_Project_Status_ProjectStatusID",
                        column: x => x.ProjectStatusID,
                        principalTable: "Project_Status",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Project_Team",
                columns: table => new
                {
                    TeamID = table.Column<int>(type: "int", nullable: false),
                    ProjectID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Project_Team", x => new { x.ProjectID, x.TeamID });
                    table.ForeignKey(
                        name: "FK_Project_Team_Project_ProjectID",
                        column: x => x.ProjectID,
                        principalTable: "Project",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Project_Team_Team_TeamID",
                        column: x => x.TeamID,
                        principalTable: "Team",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Project_Status",
                columns: new[] { "ID", "Name" },
                values: new object[,]
                {
                    { 1, "Started" },
                    { 2, "Finished" }
                });

            migrationBuilder.InsertData(
                table: "Team",
                columns: new[] { "ID", "Name" },
                values: new object[,]
                {
                    { 1, "Team 1" },
                    { 2, "Team 2" },
                    { 3, "Team 3" }
                });

            migrationBuilder.InsertData(
                table: "Developer",
                columns: new[] { "ID", "FirstName", "LastName", "TeamID" },
                values: new object[,]
                {
                    { 1, "Jan", "Piarski", 1 },
                    { 2, "Anna", "Jenkinsowa", 1 },
                    { 3, "Piotr", "Bambik", 1 },
                    { 4, "Magda", "Logowaczenko", 2 },
                    { 5, "Robert", "Bugowski", 2 },
                    { 6, "Katarzyna", "Testonaprodna", 3 }
                });

            migrationBuilder.InsertData(
                table: "Project",
                columns: new[] { "ID", "Deadline", "DeveloperID", "Name", "ProjectStatusID" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 5, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Project 1", 2 },
                    { 2, new DateTime(2023, 5, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Project 2", 1 },
                    { 3, new DateTime(2023, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Project 3", 1 }
                });

            migrationBuilder.InsertData(
                table: "Project_Team",
                columns: new[] { "ProjectID", "TeamID" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 3 },
                    { 2, 1 },
                    { 2, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Developer_TeamID",
                table: "Developer",
                column: "TeamID");

            migrationBuilder.CreateIndex(
                name: "IX_Project_DeveloperID",
                table: "Project",
                column: "DeveloperID");

            migrationBuilder.CreateIndex(
                name: "IX_Project_ProjectStatusID",
                table: "Project",
                column: "ProjectStatusID");

            migrationBuilder.CreateIndex(
                name: "IX_Project_Team_TeamID",
                table: "Project_Team",
                column: "TeamID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Project_Team");

            migrationBuilder.DropTable(
                name: "Project");

            migrationBuilder.DropTable(
                name: "Developer");

            migrationBuilder.DropTable(
                name: "Project_Status");

            migrationBuilder.DropTable(
                name: "Team");
        }
    }
}
