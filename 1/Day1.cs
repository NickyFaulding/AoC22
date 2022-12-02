using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC22
{
    public class Day1
    {
        private List<int> WeightGroups = new List<int>();
        private void CalculateWeights()
        {
            string[] lines = System.IO.File.ReadAllLines("C:\\Users\\nicky\\source\\repos\\AoC22\\1\\1.txt");

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
            List<int> topthree = new List<int>();

            topthree.Add(WeightGroups.Max());
            WeightGroups.Remove(WeightGroups.Max());
            topthree.Add(WeightGroups.Max());
            WeightGroups.Remove(WeightGroups.Max());
            topthree.Add(WeightGroups.Max());

            return topthree.Sum();
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
