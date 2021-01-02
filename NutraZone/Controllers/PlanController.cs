using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using NutraZone.Models;

namespace NutraZone.Controllers
{
    public class PlanController : Controller
    {
        public IActionResult Build()
        {
            UsersCaloriesCalculated buildBasicInfo = new UsersCaloriesCalculated();
            return View(buildBasicInfo);
        }

        public object GetRecipeByUrl(string recipeUrl)
        {
            string apiUrl = "https://api.spoonacular.com/recipes/extract?apiKey=c0490ba90c754e748f3ee9838e0f9ea9&url=" + recipeUrl;

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = client.GetAsync(apiUrl).Result;
                if (response.IsSuccessStatusCode)
                {
                    var data = response.Content.ReadAsStringAsync().Result;
                    dynamic recipe = Newtonsoft.Json.JsonConvert.DeserializeObject(data);
                    string overallInstruction = recipe.instructions;
                    int id = recipe.id;
                    int readyInMinutes = recipe.readyInMinutes;
                    int prepInMinutes = recipe.preparationMinutes;
                    int cookMinutes = recipe.cookingMinutes;
                    string title = recipe.title;

                    List<string> steps = new List<string>();
                    List<Ingredient> ingredientList = new List<Ingredient>();
                    List<string> diets = new List<string>();

                    Recipe recipeObject = new Recipe();
                    recipeObject.ID = id;
                    recipeObject.Title = title;
                    recipeObject.ReadyInMinutes = readyInMinutes;
                    recipeObject.CookingMinutes = cookMinutes;
                    recipeObject.PreparationMinutes = prepInMinutes;
                    recipeObject.Instructions = overallInstruction;
                    // gets all the ingredients from the recipe and sets the object ingredient 
                    foreach (JObject config in recipe["extendedIngredients"])
                    {
                        Ingredient ingredientADD = new Ingredient();
                        string aisle = (string)config["aisle"];
                        ingredientADD.Aisle = aisle;
                        string titelOfRecip = (string)config["name"];
                        ingredientADD.Name = titelOfRecip;
                        int amount = (int)config["amount"];
                        ingredientADD.Amount = amount;
                        string original = (string)config["original"];
                        ingredientADD.Original = original;
                        string unit = (string)config["unit"];
                        ingredientADD.Unit = unit;
                        ingredientList.Add(ingredientADD);
                    }

                    recipeObject.ListOfIngredients = ingredientList;

                    // gets a list of steps from recipe api
                    foreach (JObject item in recipe["analyzedInstructions"])
                    {
                        foreach (JObject r in item["steps"])
                        {
                            steps.Add((string)r["step"]);
                        }
                    }
                    // adds the steps of the recipe to a list
                    recipeObject.Steps = steps;

                    foreach (string item in recipe["diets"])
                    {
                        diets.Add(item);
                    }
                    recipeObject.Diets = diets;
                    return recipeObject;
                }
            }
            return null;
        }


        public IActionResult CalculateCalories(UsersCaloriesCalculated userInfo)
        {
            //        Men: 10 x weight(kg) +6.25 x height(cm) – 5 x age(y) +5
            //Women: calories / day = 10 x weight(kg) +6.25 x height(cm) – 5 x age(y) – 161
            //Then, multiply your result by an activity factor — a number that represents different levels of activity(7):
            if (userInfo.Gender == "Male")
            {
                var weightCalc = 10 * userInfo.Weight;
                var heightCalc = 6.25 * Convert.ToDouble(userInfo.HeightInCentimeters);
                var ageCalc = 5 * userInfo.Age;
                var uniqueNumberForMen = 5;

                var total = weightCalc + Convert.ToDecimal(heightCalc) - ageCalc + uniqueNumberForMen;
                userInfo.TotalCalories = total.ToString();
            }
           
            return View("Build" ,userInfo);
        }

        [HttpGet]
        public IActionResult RecipeListView(string recipeUrl)
        {
            Recipe recipe = new Recipe();
            Recipe recipeObject = (Recipe)GetRecipeByUrl(recipeUrl);

            return View("Display", recipeObject);
        }      
    }
}