namespace AdventOfCode2022
{
    internal class ExecutorFactory
    {
        private static readonly Dictionary<string, Type> TypeLookup;
        static ExecutorFactory()
        {
            TypeLookup = typeof(ExecutorFactory).Assembly.GetTypes()
                .Where(t => t.IsClass && !t.IsAbstract && typeof(IExecutor).IsAssignableFrom(t))
                .ToDictionary(t => t.Name, t => t, StringComparer.OrdinalIgnoreCase);
        }

        internal IExecutor Create(string day)
        {
            var className = $"Day{day}";
            if (TypeLookup.TryGetValue(className, out var t))
            {
                return (IExecutor)Activator.CreateInstance(t)!;
            }
            throw new ArgumentException("Could not find type " + className);
        }
    }
}
