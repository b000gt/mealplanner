using System.Collections.Generic;
using System.Threading.Tasks;

namespace mealplanner
{
    public interface IEdamamService
    {
        public Task<IEnumerable<Recipe>> GetRecipes();
    }
}