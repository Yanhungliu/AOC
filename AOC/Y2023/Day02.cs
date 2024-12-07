using System.Text.RegularExpressions;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Pillsgood.AdventOfCode;

namespace AOC.Y2023;

public class Day02 : AocFixture
{
    private string[] _input;
    private readonly string _pattern = @"(\d+)\s*blue|(\d+)\s*red|(\d+)\s*green|Game\s*(\d+)";


    [OneTimeSetUp]
    public void Setup()
    {
        _input = Input.Get<string[]>();
        
        
        
    }


    [Test]
    public void Part1()
    {
        var answer = 0;

        const int totalRed = 12;
        const int totalGreen = 13;
        const int totalBlue = 14;

        Regex regex = new(_pattern);


        foreach (var input in _input)
        {
            var isValid = true;

            var matchCollection = new List<Match>(regex.Matches(input));
            foreach (Match value in matchCollection)
            {
                if (int.TryParse(value.Groups[1].Value, out var blue))
                {
                    if (blue > totalBlue)
                    {
                        isValid = false;
                        break;
                    }
                }

                if (int.TryParse(value.Groups[2].Value, out var red))
                {
                    if (red > totalRed)
                    {
                        isValid = false;
                        break;
                    }
                }

                if (int.TryParse(value.Groups[3].Value, out var green))
                {
                    if (green > totalGreen)
                    {
                        isValid = false;
                        break;
                    }
                }
            }

            if (isValid)
            {
                var gameId = matchCollection[0].Groups[4].Value;
                Console.WriteLine(gameId);
                answer += int.Parse(gameId);
            }
        }

        Answer.Submit(answer);
    }

    [Test]
    public void Part2()
    {
        var answer = 0;


        Regex regex = new(_pattern);


        foreach (var input in _input)
        {
            var maxBlue = 0;
            var maxRed = 0;
            var maxGreen = 0;


            var matchCollection = regex.Matches(input);

            foreach (Match value in matchCollection)
            {
                if (int.TryParse(value.Groups[1].Value, out var blue))
                {
                    if (blue > maxBlue)
                    {
                        maxBlue = blue;
                    }
                }

                if (int.TryParse(value.Groups[2].Value, out var red))
                {
                    if (red > maxRed)
                    {
                        maxRed = red;
                    }
                }

                if (int.TryParse(value.Groups[3].Value, out var green))
                {
                    if (green > maxGreen)
                    {
                        maxGreen = green;
                    }
                }
            }

            answer += maxBlue * maxRed * maxGreen;
        }
        
        Answer.Submit(answer);
    }
}