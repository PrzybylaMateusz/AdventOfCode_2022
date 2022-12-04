namespace AdventOfCode2022.Days
{
    internal class Day4 : IExecutor
    {
        public int ExecutePartOne(string day)
        {
            var assignmentsPairs = 0;
            foreach (var line in File.ReadLines($@".\Items\Input{day}.txt"))
            {
                var (rangesOne, rangesTwo) = GetRanges(line);

                if (rangesOne[0] >= rangesTwo[0] && rangesOne[1] <= rangesTwo[1])
                {
                    assignmentsPairs++;
                }
                else if (rangesOne[0] <= rangesTwo[0] && rangesOne[1] >= rangesTwo[1])
                {
                    assignmentsPairs++;
                }
            }

            return assignmentsPairs;
        }

        public int Execute(string day)
        {
            Console.WriteLine(File.ReadLines($@".\Items\Input{day}.txt").Count());
            var assignmentsPairs = 0;
            foreach (var line in File.ReadLines($@".\Items\Input{day}.txt"))
            {
                var (rangesOne, rangesTwo) = GetRanges(line);

                if (rangesOne.Max() < rangesTwo.Min() || rangesOne.Min() > rangesTwo.Max())
                {
                   continue;
                }

                assignmentsPairs++;
            }

            return assignmentsPairs;
        }

        private static (int[] rangesOne, int[] rangesTwo) GetRanges(string line)
        {
            var assignments = line.Split(',');
            var rangesOne = assignments[0].Split('-').Select(int.Parse).ToArray();
            var rangesTwo = assignments[1].Split('-').Select(int.Parse).ToArray();
            return (rangesOne, rangesTwo);
        }
    }
}
