namespace AoC22
{
    internal class AoC22
    {
        private static void Main(string[] args)
        {
            Day1 day1 = new Day1();
            Day2 day2 = new Day2();
            Day3 day3 = new Day3();

            Console.WriteLine("*_*_*_*_*_*_ Day 1 *_*_*_*_*_*_");
            Console.WriteLine(day1.Part1());
            Console.WriteLine(day1.Part2());

            Console.WriteLine("\n*_*_*_*_*_*_ Day 2 *_*_*_*_*_*_");
            Console.WriteLine(day2.Part1());
            Console.WriteLine(day2.Part2());

            Console.WriteLine("\n*_*_*_*_*_*_ Day 3 *_*_*_*_*_*_");
            Console.WriteLine(day3.Part1());
            Console.WriteLine(day3.Part2());
        }
    }
}