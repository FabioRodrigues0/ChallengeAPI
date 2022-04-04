using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChallengeAPI.Migrations
{
	public partial class UpdateNameTable : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropPrimaryKey(
					name: "PK_VeryBigSum",
					table: "VeryBigSum");

			migrationBuilder.DropPrimaryKey(
					name: "PK_RatioSum",
					table: "RatioSum");

			migrationBuilder.DropPrimaryKey(
					name: "PK_DiagonalSum",
					table: "DiagonalSum");

			migrationBuilder.RenameTable(
					name: "VeryBigSum",
					newName: "VeryBigs");

			migrationBuilder.RenameTable(
					name: "RatioSum",
					newName: "Ratios");

			migrationBuilder.RenameTable(
					name: "DiagonalSum",
					newName: "Diagonals");

			migrationBuilder.AddPrimaryKey(
					name: "PK_VeryBigs",
					table: "VeryBigs",
					column: "Id");

			migrationBuilder.AddPrimaryKey(
					name: "PK_Ratios",
					table: "Ratios",
					column: "Id");

			migrationBuilder.AddPrimaryKey(
					name: "PK_Diagonals",
					table: "Diagonals",
					column: "Id");
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropPrimaryKey(
					name: "PK_VeryBigs",
					table: "VeryBigs");

			migrationBuilder.DropPrimaryKey(
					name: "PK_Ratios",
					table: "Ratios");

			migrationBuilder.DropPrimaryKey(
					name: "PK_Diagonals",
					table: "Diagonals");

			migrationBuilder.RenameTable(
					name: "VeryBigs",
					newName: "VeryBigSum");

			migrationBuilder.RenameTable(
					name: "Ratios",
					newName: "RatioSum");

			migrationBuilder.RenameTable(
					name: "Diagonals",
					newName: "DiagonalSum");

			migrationBuilder.AddPrimaryKey(
					name: "PK_VeryBigSum",
					table: "VeryBigSum",
					column: "Id");

			migrationBuilder.AddPrimaryKey(
					name: "PK_RatioSum",
					table: "RatioSum",
					column: "Id");

			migrationBuilder.AddPrimaryKey(
					name: "PK_DiagonalSum",
					table: "DiagonalSum",
					column: "Id");
		}
	}
}