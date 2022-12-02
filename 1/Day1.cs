using AoC22.Helper;

namespace AoC22
{
    public class Day1
    {
        private List<int> WeightGroups = new List<int>();
        private void CalculateWeights()
        {
            var lines = FileReader.GetLinesFromFile("C:\\Users\\nicky\\source\\repos\\AoC22\\1\\1.txt");

            var groupTotal = 0;
            foreach (var line in lines)
            {
                if (line != String.Empty)
                {
                    groupTotal += int.Parse(line);
                }
                else
                {
                    WeightGroups.Add(groupTotal);
                    groupTotal = 0;
                }
            }
        }

        private int CalculateTopThree()
        {
            List<int> TopThree = new List<int>();
            var descendingOrder = WeightGroups.OrderByDescending(i => i);

            TopThree.Add(descendingOrder.ElementAt(0));
            TopThree.Add(descendingOrder.ElementAt(1));
            TopThree.Add(descendingOrder.ElementAt(2));

            return TopThree.Sum();
        }

        public int Part1()
        {
            CalculateWeights();

            return WeightGroups.Max();
        }

        public int Part2()
        {
            return CalculateTopThree();
        }
    }
}
