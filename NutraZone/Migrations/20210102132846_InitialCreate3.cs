using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NutraZone.Migrations
{
    public partial class InitialCreate3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CaloriesCalculated",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(nullable: false),
                    Age = table.Column<int>(nullable: false),
                    Weight = table.Column<decimal>(nullable: false),
                    HeightInCentimeters = table.Column<int>(nullable: false),
                    Gender = table.Column<string>(nullable: true),
                    DietType = table.Column<string>(nullable: true),
                    ActivityLevel = table.Column<decimal>(nullable: false),
                    TotalCalories = table.Column<string>(nullable: true),
                    UsersInfoRegisterUserId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CaloriesCalculated", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CaloriesCalculated_User_UsersInfoRegisterUserId",
                        column: x => x.UsersInfoRegisterUserId,
                        principalTable: "User",
                        principalColumn: "RegisterUserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CaloriesCalculated_UsersInfoRegisterUserId",
                table: "CaloriesCalculated",
                column: "UsersInfoRegisterUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CaloriesCalculated");
        }
    }
}
