using AoC22.Helper;
using System.Text.RegularExpressions;

namespace AoC22
{
    public class Day4
    {
        private string[] lines => FileReader.GetLinesFromFile(@"C:\Users\Nicky\Source\Repos\NickyFaulding\AoC22\4\4.txt");

        private Regex SpliterRegex = new Regex(@"(?<firstStart>\d\d?)-(?<firstEnd>\d\d?),(?<secondStart>\d\d?)-(?<secondEnd>\d\d?)");
        private List<(int firstStart, int firstEnd, int secondStart, int secondEnd)> RangePairs = new List<(int firstStart, int firstEnd, int secondStart, int secondEnd)>();

        private void ParseShifts()
        {
            foreach (var line in lines)
            {
                var matches = SpliterRegex.Match(line);
                var shifts = (
                    Convert.ToInt32(matches.Groups[1].Value),
                    Convert.ToInt32(matches.Groups[2].Value),
                    Convert.ToInt32(matches.Groups[3].Value),
                    Convert.ToInt32(matches.Groups[4].Value));
                RangePairs.Add(shifts);
            }
        }

        public int Part1()
        {
            ParseShifts();
            int overlapCount = 0;

            foreach (var i in RangePairs)
            {
                var pairs = new ElfPairs(i.firstStart, i.firstEnd, i.secondStart, i.secondEnd);
                if (pairs.ContainsOverlap())
                {
                    overlapCount++;
                }
            }

            return overlapCount;
        }

        public int Part2()
        {
            int overlapCount = 0;

            foreach (var i in RangePairs)
            {
                var pairs = new ElfPairs(i.firstStart, i.firstEnd, i.secondStart, i.secondEnd);
                if (pairs.ContainsOverlapP2())
                {
                    overlapCount++;
                }
            }

            return overlapCount;
        }
        internal class ElfPairs
        {
            (int start, int end) ElfOneShift;
            (int start, int end) ElfTwoShift;
            public ElfPairs(int firstStart, int firstEnd, int secondStart, int secondEnd)
            {
                ElfOneShift = (firstStart, firstEnd);
                ElfTwoShift = (secondStart, secondEnd);
            }

            public bool ContainsOverlap()
            {
                if (ElfOneShift.start >= ElfTwoShift.start && ElfOneShift.end <= ElfTwoShift.end)
                {
                    return true;
                }
                else if (ElfTwoShift.start >= ElfOneShift.start && ElfTwoShift.end <= ElfOneShift.end)
                {
                    return true;
                }
                return false;
            }

            // look at this in more detail later...
            public bool ContainsOverlapP2()
            {
                if (ElfOneShift.start >= ElfTwoShift.start && ElfOneShift.end <= ElfTwoShift.end)
                {
                    return true;
                }
                // check if contains whole 
                if (ElfTwoShift.start >= ElfOneShift.start && ElfTwoShift.end <= ElfOneShift.end)
                {
                    return true;
                }

                // start of second smaller than last of first
                if (ElfOneShift.end > ElfTwoShift.start && ElfOneShift.start < ElfTwoShift.end)
                {
                    return true;
                }

                if (ElfTwoShift.end > ElfOneShift.start && ElfTwoShift.start < ElfOneShift.end)
                {
                    return true;
                }

                // check start and ends equal
                if (ElfOneShift.start == ElfTwoShift.start ||
                ElfOneShift.start == ElfTwoShift.end ||
                ElfOneShift.end == ElfTwoShift.start ||
                ElfOneShift.end == ElfTwoShift.end)
                {
                    return true;
                }

                return false;
            }
        }
    }
}
