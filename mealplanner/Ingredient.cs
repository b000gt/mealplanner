using System;
using Newtonsoft.Json;

namespace mealplanner
{
    [Serializable]
    public class Ingredient
    {
        [JsonProperty("text")]
        public string Text { get; set; }
    }
}