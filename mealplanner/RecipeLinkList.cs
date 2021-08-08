using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace mealplanner
{
    [Serializable]
    public class RecipeLink
    {
        [JsonProperty("recipe")]
        public Recipe Recipe { get; set; }
    }
    [Serializable]
    public class RecipeLinkList
    {
        [JsonProperty("hits")]
        public IEnumerable<RecipeLink> Recipes { get; set; }
    }
}