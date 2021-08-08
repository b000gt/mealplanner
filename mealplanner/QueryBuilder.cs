using System.Collections.Generic;
using System.Linq;

namespace mealplanner
{
    public class QueryBuilder : IQueryBuilder
    {
        public string Query
        {
            get
            {
                return "?" + string.Join("&",Arguments.Select(a => $"{a.Item1}={a.Item2}"));
            }
        }

        private IEnumerable<(string, string)> Arguments { get; set; } = new List<(string, string)>();

        public void AddArguments(params (string, string)[] arguments)
        {
            foreach (var (key, value) in arguments)
            {
                Arguments = Arguments.Append((key, value));
            }
        }

        public void AddArguments(string name, string[] arguments)
        {
            foreach (var argument in arguments)
            {
                Arguments = Arguments.Append((name, argument));
            }
        }
    }
}