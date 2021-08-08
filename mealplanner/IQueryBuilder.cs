namespace mealplanner
{
    public interface IQueryBuilder
    {
        public string Query { get; }
        public void AddArguments(params (string, string)[] arguments);

        public void AddArguments(string name, string[] arguments);
    }
}