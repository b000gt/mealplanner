using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace mealplanner
{
    public class RecipeList : IEnumerable<Recipe>
    {
        private int _max = 500;
        private Stack<Recipe> Recipes { get; set; } = new Stack<Recipe>();
        private readonly IEdamamService _service = new EdamamService();

        public IEnumerator<Recipe> GetEnumerator()
        {
            while (_max > 0)
            {
                if (Recipes.Count == 0)
                {
                    Recipes = new Stack<Recipe>(_service.GetRecipes().GetAwaiter().GetResult());
                }

                _max --;
                yield return Recipes.Pop();
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}