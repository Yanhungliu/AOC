namespace AOC.Common;

public static class StringExtensions
{
    public static string[] SplitLines(this string str)
    {
        return str.Split("\n", StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
    }
}