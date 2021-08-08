using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace mealplanner
{
    public class EdamamService : IEdamamService
    {
        public async Task<IEnumerable<Recipe>> GetRecipes()
        {
            var recipes = new List<RecipeLink>();

            const string url = "https://api.edamam.com/api/recipes/v2";
            var parameters = GetQueryParameters();

            var client = new HttpClient {BaseAddress = new Uri(url)};
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = await client.GetAsync(parameters).ConfigureAwait(false);
            
            if (response.IsSuccessStatusCode)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                var recipeList = JsonConvert.DeserializeObject<RecipeLinkList>(jsonString);

                if (recipeList != null)
                {
                    recipes.AddRange(recipeList.Recipes);
                }
            }

            return recipes.Select(r=>r.Recipe);
        }

        public string GetQueryParameters()
        {
            var queryBuilder = new QueryBuilder();
            queryBuilder.AddArguments(
                ("app_key", Consts.APP_KEY), 
                ("app_id", Consts.APP_ID),
                ("type", "public"),
                ("random", "true"),
                ("dishType", "Main%20course"));
            queryBuilder.AddArguments("health", new string[]{ "vegan", "vegetarian", "tree-nut-free" });
            return queryBuilder.Query;
        }
    }
}