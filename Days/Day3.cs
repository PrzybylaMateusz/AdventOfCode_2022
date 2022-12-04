namespace AdventOfCode2022.Days
{
    internal class Day3 : IExecutor
    {
        public int ExecutePartOne(string day)
        {
            var sumOfPriorities = 0;
            foreach (var line in File.ReadLines($@".\Items\Input{day}.txt"))
            {
                var middle = line.Length / 2;
                var partOne = line[..middle];
                var partTwo = line.Substring(middle , middle);

                foreach (var symbol in partTwo)
                {
                    if (!partOne.Contains(symbol)) continue;
                    sumOfPriorities += GetPriority(symbol);
                    break;
                }
            }

            return sumOfPriorities;
        }

        private static int GetPriority(char symbol)
        {
            var priority = symbol % 32;
            priority = char.IsUpper(symbol) ? priority + 26 : priority;
            return priority;
        }

        public int Execute(string day)
        {
            var sumOfPriorities = 0;
            var lineCounter = 0;
            var commonCharacters = new HashSet<char>();
            foreach (var line in File.ReadLines($@".\Items\Input{day}.txt"))
            {
                lineCounter++;

                if (lineCounter == 1)
                {
                    foreach (var character in line)
                    {
                        commonCharacters.Add(character);
                    }
                    continue;
                }

                foreach (var character in commonCharacters.Where(character => !line.Contains(character)))
                {
                    commonCharacters.Remove(character);
                }
                
                if (lineCounter != 3) continue;
                sumOfPriorities += GetPriority(commonCharacters.FirstOrDefault());
                lineCounter = 0;
                commonCharacters.Clear();
            }

            return sumOfPriorities;
        }
    }
}
