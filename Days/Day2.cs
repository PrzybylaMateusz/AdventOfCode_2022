namespace AdventOfCode2022.Days
{
    internal class Day2 : IExecutor
    {
        public int ExecutePartOne(string day)
        {
            return ExecuteBaseLogic(day);
        }

        public int Execute(string day)
        {
            return ExecuteBaseLogic(day, true);
        }

        public int ExecuteBaseLogic(string day, bool isSecondPart = false)
        {
            var totalPoints = 0;
            foreach (var line in File.ReadLines($@".\Items\Input{day}.txt"))
            {
                var roundResults = line.Split();
                var roundPoints = GetRoundPoints(roundResults[0], roundResults[1], isSecondPart);
                totalPoints += roundPoints;
            }

            return totalPoints;
        }

        private static int GetRoundPoints(string opponentChoice, string myChoice, bool isSecondPart)
        {
            var result = 0;
            switch (myChoice)
            {
                case "Y":
                    result += isSecondPart
                        ? GetScore(new SpecificLogic(3, 1, 2, 3), opponentChoice)
                        : GetScore(new SpecificLogic(2, 6, 3, 0), opponentChoice);
                    break;
                case "X":
                    result += isSecondPart
                        ? GetScore(new SpecificLogic(0, 3, 1, 2), opponentChoice)
                        : GetScore(new SpecificLogic(1, 3, 0, 6), opponentChoice);
                    break;
                case "Z":
                    result += isSecondPart 
                        ? GetScore(new SpecificLogic(6, 2, 3, 1), opponentChoice)
                        : GetScore(new SpecificLogic(3, 0, 6, 3), opponentChoice);
                    break;
            }

            return result;
        }

        private static int GetScore(SpecificLogic specificLogic, string opponentChoice)
        {
            var initialScore = specificLogic.InitialScore;
            var resultScore = opponentChoice switch
            {
                "A" => specificLogic.RockScore,
                "B" => specificLogic.PaperScore,
                _ => specificLogic.ScissorsScore,
            };

            return initialScore + resultScore;
        }

    }

    internal record SpecificLogic(int InitialScore, int RockScore, int PaperScore, int ScissorsScore)
    {
        internal int InitialScore = InitialScore;
        internal int RockScore = RockScore;
        internal int PaperScore = PaperScore;
        internal int ScissorsScore = ScissorsScore;
    }
}
