using AoC22.Helper;

namespace AoC22
{
    public class Day3
    {
        private List<int> ItemPriorities = new List<int>();
        private List<int> GroupPriorities = new List<int>();
        private string[] bags => FileReader.GetLinesFromFile(@"C:\Users\Nicky\Source\Repos\NickyFaulding\AoC22\3\3.txt");

        private int SplitAndCompare(string bag)
        {
            var firstHalf = bag.Substring(0, (bag.Length / 2));
            var secondHalf = bag.Substring((bag.Length / 2), (bag.Length / 2));

            foreach (var c in secondHalf)
            {
                if (firstHalf.Contains(c))
                {
                    return CalculatePriority(c);
                }
            }

            return 0;
        }
        private int CalculatePriority(char item)
        {
            if (item >= 97)
            {
                return item - 96;
            }
            else
            {
                return (item - 64) + 26;
            }
        }

        private int CompareAllBags()
        {
            foreach (var bag in bags)
            {
                ItemPriorities.Add(SplitAndCompare(bag));
            }

            return ItemPriorities.Sum();
        }

        private List<List<string>> GroupBags()
        {

            List<List<string>> BagGroups = new List<List<string>>();
            List<string> group = new List<string>();

            int count = 0;

            foreach (var bag in bags)
            {
                group.Add(bag);
                count++;

                if (count == 3)
                {
                    BagGroups.Add(new List<string>(group));
                    group.Clear();
                    count = 0;
                }
            }

            return BagGroups;
        }

        private void CompareSetsOfBags()
        {
            var BagGroups = GroupBags();

            foreach (var group in BagGroups)
            {
                group.OrderByDescending(s => s.Length);
                foreach (var c in group.First())
                {
                    if (group.ElementAt(1).Contains(c) && group.ElementAt(2).Contains(c))
                    {
                        GroupPriorities.Add(CalculatePriority(c));
                        break;
                    }
                }
            }
        }

        public int Part1()
        {
            return CompareAllBags();
        }

        public int Part2()
        {
            CompareSetsOfBags();
            return GroupPriorities.Sum();
        }
    }
}
