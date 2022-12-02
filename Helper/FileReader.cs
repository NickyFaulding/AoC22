namespace AoC22.Helper
{
    public static class FileReader
    {
        public static string[] GetLinesFromFile(string path)
        {
            return System.IO.File.ReadAllLines(path);
        }
    }
}
