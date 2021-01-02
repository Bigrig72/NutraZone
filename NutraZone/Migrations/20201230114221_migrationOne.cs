using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NutraZone.Migrations
{
    public partial class migrationOne : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GroceryBag",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Quantity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroceryBag", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    RegisterUserId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    GroceryBagId = table.Column<int>(nullable: false),
                    FirstName = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: false),
                    Birthday = table.Column<DateTime>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: false),
                    ConfirmPassword = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.RegisterUserId);
                });

            migrationBuilder.CreateTable(
                name: "Plan",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RegisterUserID = table.Column<string>(nullable: true),
                    BodyType = table.Column<string>(nullable: true),
                    Age = table.Column<int>(nullable: false),
                    Gender = table.Column<string>(nullable: true),
                    WorkoutStyle = table.Column<int>(nullable: false),
                    LivingStyle = table.Column<int>(nullable: false),
                    Healthgoals = table.Column<int>(nullable: false),
                    Calories = table.Column<int>(nullable: false),
                    MedicalHistory = table.Column<string>(nullable: true),
                    MealsPerDayPrefrence = table.Column<int>(nullable: false),
                    UserRegisterUserId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plan", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Plan_User_UserRegisterUserId",
                        column: x => x.UserRegisterUserId,
                        principalTable: "User",
                        principalColumn: "RegisterUserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Recipe",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(nullable: true),
                    Diet = table.Column<int>(nullable: false),
                    ReadyInMinutes = table.Column<int>(nullable: false),
                    CookingMinutes = table.Column<int>(nullable: false),
                    PreparationMinutes = table.Column<int>(nullable: false),
                    Calories = table.Column<int>(nullable: false),
                    Protein = table.Column<int>(nullable: false),
                    Carbs = table.Column<int>(nullable: false),
                    Fats = table.Column<int>(nullable: false),
                    Instructions = table.Column<string>(nullable: true),
                    BuildPlanID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recipe", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Recipe_Plan_BuildPlanID",
                        column: x => x.BuildPlanID,
                        principalTable: "Plan",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Ingredient",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RecipeId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Unit = table.Column<string>(nullable: true),
                    Aisle = table.Column<string>(nullable: true),
                    Original = table.Column<string>(nullable: true),
                    Amount = table.Column<int>(nullable: false),
                    GroceryItemsID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingredient", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ingredient_GroceryBag_GroceryItemsID",
                        column: x => x.GroceryItemsID,
                        principalTable: "GroceryBag",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Ingredient_Recipe_RecipeId",
                        column: x => x.RecipeId,
                        principalTable: "Recipe",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ingredient_GroceryItemsID",
                table: "Ingredient",
                column: "GroceryItemsID");

            migrationBuilder.CreateIndex(
                name: "IX_Ingredient_RecipeId",
                table: "Ingredient",
                column: "RecipeId");

            migrationBuilder.CreateIndex(
                name: "IX_Plan_UserRegisterUserId",
                table: "Plan",
                column: "UserRegisterUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Recipe_BuildPlanID",
                table: "Recipe",
                column: "BuildPlanID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ingredient");

            migrationBuilder.DropTable(
                name: "GroceryBag");

            migrationBuilder.DropTable(
                name: "Recipe");

            migrationBuilder.DropTable(
                name: "Plan");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
