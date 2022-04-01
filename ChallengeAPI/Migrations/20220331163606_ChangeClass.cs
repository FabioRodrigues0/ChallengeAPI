using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChallengeAPI.Migrations
{
    public partial class ChangeClass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Inputs");

            migrationBuilder.AlterColumn<string>(
                name: "Output",
                table: "Sums",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddColumn<string>(
                name: "Input",
                table: "Sums",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Input",
                table: "Sums");

            migrationBuilder.AlterColumn<long>(
                name: "Output",
                table: "Sums",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "Inputs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Number = table.Column<int>(type: "int", nullable: false),
                    VeryBigSumId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inputs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Inputs_Sums_VeryBigSumId",
                        column: x => x.VeryBigSumId,
                        principalTable: "Sums",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Inputs_VeryBigSumId",
                table: "Inputs",
                column: "VeryBigSumId");
        }
    }
}
