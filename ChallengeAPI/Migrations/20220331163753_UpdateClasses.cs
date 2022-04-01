using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChallengeAPI.Migrations
{
    public partial class UpdateClasses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Sums",
                table: "Sums");

            migrationBuilder.RenameTable(
                name: "Sums",
                newName: "VeryBigSum");

            migrationBuilder.AddPrimaryKey(
                name: "PK_VeryBigSum",
                table: "VeryBigSum",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "DiagonalSum",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Input = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Output = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiagonalSum", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RatioSum",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Input = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Output = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RatioSum", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DiagonalSum");

            migrationBuilder.DropTable(
                name: "RatioSum");

            migrationBuilder.DropPrimaryKey(
                name: "PK_VeryBigSum",
                table: "VeryBigSum");

            migrationBuilder.RenameTable(
                name: "VeryBigSum",
                newName: "Sums");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Sums",
                table: "Sums",
                column: "Id");
        }
    }
}
