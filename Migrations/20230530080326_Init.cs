using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace project_demo_1.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EpicsS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    ProjectCode = table.Column<int>(type: "int", nullable: false),
                    SprintId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CompletedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EpicsS", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserStoriesS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    UserStoriesDetails = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    AcceptanceCriteria = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    Priority = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DoneOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AssignedToDeveloperId = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    StoryPoints = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    EpicsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserStoriesS", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserStoriesS_EpicsS_EpicsId",
                        column: x => x.EpicsId,
                        principalTable: "EpicsS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "EpicsS",
                columns: new[] { "Id", "CompletedOn", "CreatedOn", "Name", "ProjectCode", "SprintId", "Status" },
                values: new object[] { 10, new DateTime(2023, 5, 2, 11, 22, 51, 383, DateTimeKind.Local), new DateTime(2023, 5, 2, 11, 22, 51, 383, DateTimeKind.Local), "stig0", 20, 30, "InProgress" });

            migrationBuilder.InsertData(
                table: "EpicsS",
                columns: new[] { "Id", "CompletedOn", "CreatedOn", "Name", "ProjectCode", "SprintId", "Status" },
                values: new object[] { 11, new DateTime(2023, 5, 2, 11, 22, 51, 383, DateTimeKind.Local), new DateTime(2023, 5, 2, 11, 22, 51, 383, DateTimeKind.Local), "stig1", 21, 31, "InProgress" });

            migrationBuilder.InsertData(
                table: "EpicsS",
                columns: new[] { "Id", "CompletedOn", "CreatedOn", "Name", "ProjectCode", "SprintId", "Status" },
                values: new object[] { 12, new DateTime(2023, 5, 2, 11, 22, 51, 383, DateTimeKind.Local), new DateTime(2023, 5, 2, 11, 22, 51, 383, DateTimeKind.Local), "stig2", 22, 32, "InProgress" });

            migrationBuilder.InsertData(
                table: "UserStoriesS",
                columns: new[] { "Id", "AcceptanceCriteria", "AssignedToDeveloperId", "CreatedOn", "DoneOn", "EpicsId", "Priority", "Status", "StoryPoints", "Title", "UserStoriesDetails" },
                values: new object[,]
                {
                    { 100, "rand", "dev0", new DateTime(2023, 5, 2, 11, 22, 51, 383, DateTimeKind.Local), new DateTime(2023, 5, 2, 11, 22, 51, 383, DateTimeKind.Local), 10, "1", "New", 3, "us100", "us00details" },
                    { 101, "rand", "dev3", new DateTime(2023, 5, 2, 11, 22, 51, 383, DateTimeKind.Local), new DateTime(2023, 5, 2, 11, 22, 51, 383, DateTimeKind.Local), 10, "1", "Planning", 3, "us101", "us00details" },
                    { 110, "rand", "dev2", new DateTime(2023, 5, 2, 11, 22, 51, 383, DateTimeKind.Local), new DateTime(2023, 5, 2, 11, 22, 51, 383, DateTimeKind.Local), 11, "3", "New", 3, "us111", "us00details" },
                    { 111, "rand", "dev2", new DateTime(2023, 5, 2, 11, 22, 51, 383, DateTimeKind.Local), new DateTime(2023, 5, 2, 11, 22, 51, 383, DateTimeKind.Local), 11, "3", "Planning", 3, "us111", "us00details" },
                    { 112, "rand", "dev4", new DateTime(2023, 5, 2, 11, 22, 51, 383, DateTimeKind.Local), new DateTime(2023, 5, 2, 11, 22, 51, 383, DateTimeKind.Local), 11, "2", "Coding", 3, "us110", "us00details" },
                    { 113, "rand", "dev2", new DateTime(2023, 5, 2, 11, 22, 51, 383, DateTimeKind.Local), new DateTime(2023, 5, 2, 11, 22, 51, 383, DateTimeKind.Local), 11, "3", "Testing", 3, "us111", "us00details" },
                    { 114, "rand", "dev2", new DateTime(2023, 5, 2, 11, 22, 51, 383, DateTimeKind.Local), new DateTime(2023, 5, 2, 11, 22, 51, 383, DateTimeKind.Local), 11, "3", "Done", 3, "us111", "us00details" },
                    { 115, "rand", "dev4", new DateTime(2023, 5, 2, 11, 22, 51, 383, DateTimeKind.Local), new DateTime(2023, 5, 2, 11, 22, 51, 383, DateTimeKind.Local), 11, "3", "Done", 3, "us111", "us00details" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserStoriesS_EpicsId",
                table: "UserStoriesS",
                column: "EpicsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserStoriesS");

            migrationBuilder.DropTable(
                name: "EpicsS");
        }
    }
}
