namespace AdventOfCode2022.Days
{
    internal class Day1 : IExecutor
    {
        public int ExecutePartOne(string day)
        {
            var sumOfIndividual = 0;
            var max = 0;

            foreach (var line in File.ReadLines($@".\Items\Input{day}.txt"))
            {
                if (string.IsNullOrWhiteSpace(line))
                {
                    if (sumOfIndividual > max)
                    {
                        max = sumOfIndividual;
                    }
                    sumOfIndividual = 0;
                    continue;
                }
                sumOfIndividual += int.Parse(line);
            }

            return max;
        }

        public int Execute(string day)
        {
            var sumOfIndividual = 0;
            var maxThree = new[] { 0, 0, 0};

            foreach (var line in File.ReadLines($@".\Items\Input{day}.txt"))
            {
                if (string.IsNullOrWhiteSpace(line))
                {
                    var minInThree = maxThree.Min();
                    if (sumOfIndividual > minInThree)
                    {
                        maxThree[Array.IndexOf(maxThree, minInThree)] = sumOfIndividual;
                    }
                    sumOfIndividual = 0;
                    continue;
                }
                sumOfIndividual += int.Parse(line);
            }

            return maxThree.Sum();
        }
    }
}
