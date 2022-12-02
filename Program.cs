namespace AoC22
{
    internal class AoC22
    {
        private static void Main(string[] args)
        {
            Day1 day1 = new Day1();
            Day2 day2 = new Day2();

            Console.WriteLine(day1.Part1());
            Console.WriteLine(day1.Part2());

            Console.WriteLine(day2.Part1());
            Console.WriteLine(day2.Part2());
        }
    }
}