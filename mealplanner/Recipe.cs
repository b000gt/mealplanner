using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace mealplanner
{
    [Serializable]
    public class Recipe
    {
        [JsonProperty("label")]
        public string Name { get; set; }

        [JsonProperty("url")]
        public string Link { get; set; }

        [JsonProperty("yield")]
        public double Portions { get; set; }

        [JsonProperty("ingredients")]
        public IList<Ingredient> Ingredients { get; set; }
    }
}