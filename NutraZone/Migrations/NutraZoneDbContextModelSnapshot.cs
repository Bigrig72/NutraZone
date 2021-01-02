﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NutraZone.Data;

namespace NutraZone.Migrations
{
    [DbContext(typeof(NutraZoneDbContext))]
    partial class NutraZoneDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("NutraZone.Models.BuildPlan", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Age");

                    b.Property<string>("BodyType");

                    b.Property<int>("Calories");

                    b.Property<string>("Gender");

                    b.Property<int>("Healthgoals");

                    b.Property<int>("LivingStyle");

                    b.Property<int>("MealsPerDayPrefrence");

                    b.Property<string>("MedicalHistory");

                    b.Property<string>("RegisterUserID");

                    b.Property<int?>("UserRegisterUserId");

                    b.Property<int>("WorkoutStyle");

                    b.HasKey("ID");

                    b.HasIndex("UserRegisterUserId");

                    b.ToTable("Plan");
                });

            modelBuilder.Entity("NutraZone.Models.GroceryItems", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Quantity");

                    b.HasKey("ID");

                    b.ToTable("GroceryBag");
                });

            modelBuilder.Entity("NutraZone.Models.Ingredient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Aisle");

                    b.Property<int>("Amount");

                    b.Property<int?>("GroceryItemsID");

                    b.Property<string>("Name");

                    b.Property<string>("Original");

                    b.Property<int>("RecipeId");

                    b.Property<string>("Unit");

                    b.HasKey("Id");

                    b.HasIndex("GroceryItemsID");

                    b.HasIndex("RecipeId");

                    b.ToTable("Ingredient");
                });

            modelBuilder.Entity("NutraZone.Models.Recipe", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("BuildPlanID");

                    b.Property<int>("Calories");

                    b.Property<int>("Carbs");

                    b.Property<int>("CookingMinutes");

                    b.Property<int>("Diet");

                    b.Property<int>("Fats");

                    b.Property<string>("Instructions");

                    b.Property<int>("PreparationMinutes");

                    b.Property<int>("Protein");

                    b.Property<int>("ReadyInMinutes");

                    b.Property<string>("Title");

                    b.HasKey("ID");

                    b.HasIndex("BuildPlanID");

                    b.ToTable("Recipe");
                });

            modelBuilder.Entity("NutraZone.Models.RegisterUser", b =>
                {
                    b.Property<int>("RegisterUserId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Birthday");

                    b.Property<string>("ConfirmPassword")
                        .IsRequired();

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<string>("FirstName")
                        .IsRequired();

                    b.Property<int>("GroceryBagId");

                    b.Property<string>("LastName")
                        .IsRequired();

                    b.Property<string>("Password")
                        .IsRequired();

                    b.Property<string>("UserName");

                    b.HasKey("RegisterUserId");

                    b.ToTable("User");
                });

            modelBuilder.Entity("NutraZone.Models.UsersCaloriesCalculated", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("ActivityLevel")
                        .HasColumnType("decimal(5,3)");

                    b.Property<int>("Age");

                    b.Property<string>("DietType");

                    b.Property<string>("Gender");

                    b.Property<int>("HeightInCentimeters");

                    b.Property<string>("TotalCalories");

                    b.Property<int>("UserId");

                    b.Property<int?>("UsersInfoRegisterUserId");

                    b.Property<decimal>("Weight")
                        .HasColumnType("decimal(5,3)");

                    b.HasKey("Id");

                    b.HasIndex("UsersInfoRegisterUserId");

                    b.ToTable("CaloriesCalculated");
                });

            modelBuilder.Entity("NutraZone.Models.BuildPlan", b =>
                {
                    b.HasOne("NutraZone.Models.RegisterUser", "User")
                        .WithMany()
                        .HasForeignKey("UserRegisterUserId");
                });

            modelBuilder.Entity("NutraZone.Models.Ingredient", b =>
                {
                    b.HasOne("NutraZone.Models.GroceryItems")
                        .WithMany("Ingredients")
                        .HasForeignKey("GroceryItemsID");

                    b.HasOne("NutraZone.Models.Recipe", "RecipeInfo")
                        .WithMany("ListOfIngredients")
                        .HasForeignKey("RecipeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("NutraZone.Models.Recipe", b =>
                {
                    b.HasOne("NutraZone.Models.BuildPlan")
                        .WithMany("Recipies")
                        .HasForeignKey("BuildPlanID");
                });

            modelBuilder.Entity("NutraZone.Models.UsersCaloriesCalculated", b =>
                {
                    b.HasOne("NutraZone.Models.RegisterUser", "UsersInfo")
                        .WithMany()
                        .HasForeignKey("UsersInfoRegisterUserId");
                });
#pragma warning restore 612, 618
        }
    }
}
