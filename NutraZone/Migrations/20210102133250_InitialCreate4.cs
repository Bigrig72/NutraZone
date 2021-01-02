using Microsoft.EntityFrameworkCore.Migrations;

namespace NutraZone.Migrations
{
    public partial class InitialCreate4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Weight",
                table: "CaloriesCalculated",
                type: "decimal(5,3)",
                nullable: false,
                oldClrType: typeof(decimal));

            migrationBuilder.AlterColumn<decimal>(
                name: "ActivityLevel",
                table: "CaloriesCalculated",
                type: "decimal(5,3)",
                nullable: false,
                oldClrType: typeof(decimal));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Weight",
                table: "CaloriesCalculated",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(5,3)");

            migrationBuilder.AlterColumn<decimal>(
                name: "ActivityLevel",
                table: "CaloriesCalculated",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(5,3)");
        }
    }
}
