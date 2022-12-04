using AdventOfCode2022.Days;

namespace AdventOfCode2022
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var day = "1";
            if (args.Length != 0)
            {
                day = args[0];
            }

            var executorFactory = new ExecutorFactory();
            var dayImplementation = executorFactory.Create(day);
            var result = dayImplementation.Execute(day);
            Console.WriteLine("Result: " + result);
        }
    }
}