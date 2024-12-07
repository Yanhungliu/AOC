using System.Numerics;
using System.Text.RegularExpressions;
using Pillsgood.AdventOfCode;

namespace AOC.Y2023;

public class Day3 : AocFixture
{
    private string sample = """
                            467..114..
                            ...*......
                            ..35..633.
                            ......#...
                            617*......
                            .....+.58.
                            ..592.....
                            ......755.
                            ...$.*....
                            .664.598..
                            """;

    public string[] _input;


    [OneTimeSetUp]
    public void SetUp()
    {
        // _input = Input.Get<string[]>();
        _input = sample.Split("\n", StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
    }

    [Test]
    public void Part1()
    {
        Regex regex = new Regex(@"(\d+)|([^\d\.\s])");

        Dictionary<(int x, int y),string> positions = new();
        
        for (var i = 0; i < _input.Length; i++)
        {
            var matchCollection = regex.Matches(_input[i]);
            var positionY = i;

            foreach (Match value in matchCollection)
            {
                var numberPositionX = value.Groups[1].Index;
                var numberLength = value.Groups[1].Length;
                var number = value.Groups[1].Value;
                var symbolPositionX = value.Groups[2].Index;
                
                
            }
        }
    }
}