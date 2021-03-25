using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PhoneBook.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Statuses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StatusType = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PhoneNumbers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Number = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Added = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StatusId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhoneNumbers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PhoneNumbers_Statuses_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Statuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PhoneNumbers_Users_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Statuses",
                columns: new[] { "Id", "StatusType" },
                values: new object[] { new Guid("20d91fe7-2433-4611-bcf7-9e6479477f37"), "Relevant" });

            migrationBuilder.InsertData(
                table: "Statuses",
                columns: new[] { "Id", "StatusType" },
                values: new object[] { new Guid("b4b4f0f1-b3b3-443e-aa23-882a8602b7b4"), "Irrelevant" });

            migrationBuilder.InsertData(
                table: "Statuses",
                columns: new[] { "Id", "StatusType" },
                values: new object[] { new Guid("2f59ab8f-48ea-44ed-93df-0389873a7ab2"), "Requires clarification" });

            migrationBuilder.CreateIndex(
                name: "IX_PhoneNumbers_CreatorId",
                table: "PhoneNumbers",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_PhoneNumbers_StatusId",
                table: "PhoneNumbers",
                column: "StatusId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PhoneNumbers");

            migrationBuilder.DropTable(
                name: "Statuses");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
