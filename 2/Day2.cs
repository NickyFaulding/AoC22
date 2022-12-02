using AoC22.Helper;

namespace AoC22
{
    public class Day2
    {
        const int Win = 6;
        const int Loss = 0;
        const int Draw = 3;

        const int Rock = 1;
        const int Paper = 2;
        const int Scissors = 3;

        // Not the most graceful solution. Come back later and do something better !
        internal class RPSGame
        {
            string CurrentGame { get; set; }

            public RPSGame(string game)
            {
                CurrentGame = game;
            }

            public int CalculateResult()
            {
                switch (CurrentGame)
                {
                    case "A Y":
                        return Win + Paper;
                    case "B Z":
                        return Win + Scissors;
                    case "C X":
                        return Win + Rock;
                    case "A Z":
                        return Loss + Scissors;
                    case "B X":
                        return Loss + Rock;
                    case "C Y":
                        return Loss + Paper;
                    case "B Y":
                        return Draw + Paper;
                    case "A X":
                        return Draw + Rock;
                    case "C Z":
                        return Draw + Scissors;
                }
                return 0;
            }

            public int CalculateP2Result()
            {
                switch (CurrentGame)
                {
                    case "A Y":
                        return Draw + Rock;
                    case "B Z":
                        return Win + Scissors;
                    case "C X":
                        return Loss + Paper;
                    case "A Z":
                        return Win + Paper;
                    case "B X":
                        return Loss + Rock;
                    case "C Y":
                        return Draw + Scissors;
                    case "B Y":
                        return Draw + Paper;
                    case "A X":
                        return Loss + Scissors;
                    case "C Z":
                        return Win + Rock;
                }
                return 0;
            }
        }

        public int Part1()
        {
            var games = FileReader.GetLinesFromFile("C:\\Users\\nicky\\source\\repos\\AoC22\\2\\2.txt");

            int totalScore = 0;

            foreach (var game in games)
            {
                RPSGame g = new RPSGame(game);

                totalScore += g.CalculateResult();
            }

            return totalScore;
        }

        //X means you need to lose
        //Y means you need to draw
        //Z means you need to win
        public int Part2()
        {
            var games = FileReader.GetLinesFromFile("C:\\Users\\nicky\\source\\repos\\AoC22\\2\\2.txt");

            int totalScore = 0;

            foreach (var game in games)
            {
                RPSGame g = new RPSGame(game);

                totalScore += g.CalculateP2Result();
            }

            return totalScore;
        }
    }
}
