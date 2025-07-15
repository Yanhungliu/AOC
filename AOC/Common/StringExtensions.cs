namespace AOC.Common;

public static class StringExtensions
{
    public static string[] SplitLines(this string str)
    {
        return str.Split("\n", StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
    }

    public static string ReplaceAt(this string str, int index, char c)
    {
        if (string.IsNullOrEmpty(str)) throw new ArgumentException("string is null or empty");
        if (index < 0 || index >= str.Length) throw new ArgumentOutOfRangeException(nameof(index));

        var chars = str.ToCharArray();
        chars[index] = c;
        return new string(chars);
    }

    public static string ReplaceFrom(this string str, int startIndex, int endIndex, char c)
    {
        if (string.IsNullOrEmpty(str))
            throw new ArgumentException("string is null or empty");

        if (startIndex < 0 || endIndex >= str.Length) throw new ArgumentOutOfRangeException("Index is out of string bounds");

        if (startIndex > endIndex) throw new ArgumentException("startIndex cannot be greater than endIndex");

        var chars = str.ToCharArray();
        for (var i = startIndex; i <= endIndex; i++)
        {
            chars[i] = c;
        }

        return new string(chars);
    }
}