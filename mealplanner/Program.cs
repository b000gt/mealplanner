using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mealplanner
{
    class Program
    {
        static void Main(string[] args)
        {
            var userInput = "";
            var recipeList = new RecipeList();
            while (!(userInput is "q"))
            {
                var recipe = recipeList.Take(1).Single();
                ShowRecipe(recipe);
                userInput = Console.ReadLine();
                if (userInput is "y")
                {
                    ShowRecipeDetail(recipe);
                    userInput = Console.ReadLine();
                }
            }
        }

        private static void ShowRecipeDetail(Recipe recipe)
        {
            Console.WriteLine($"Portions: {recipe.Portions}" +
                              $"\n\t{string.Join("\n\t",recipe.Ingredients.Select(i=>i.Text))}" +
                              $"\n{recipe.Link}");
        }

        private static void ShowRecipe(Recipe recipe)
        {
            Console.WriteLine(recipe.Name);
        }
    }
}
