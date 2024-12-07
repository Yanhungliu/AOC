using AOC.Common;
using FluentAssertions;
using Pillsgood.AdventOfCode;

namespace AOC.Y2024;

public class Day02 : AocFixture
{
    private string[] _input;


    private int[][] _rows;

    [OneTimeSetUp]
    public void Setup()
    {
        _input = Input.Get<string[]>();
        // _input = """
        //          7 6 4 2 1
        //          1 2 7 8 9
        //          9 7 6 2 1
        //          1 3 2 4 5
        //          8 6 4 4 1
        //          1 3 6 7 9
        //          """.SplitLines();

        _rows = _input
            .Select(row =>
                row.Split(" ", StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)
                    .Select(int.Parse)
                    .ToArray())
            .ToArray();
    }


    [Test]
    public void Part1()
    {
        int answer = 0;
        foreach (var row in _rows)
        {
            var isIncreasing = false;
            var isDecreasing = false;
            var isValid = false;


            for (var i = 0; i < row.Length - 1; i++)
            {
                var current = row[i];
                var next = row[i + 1];

                if (current - next > 0)
                {
                    isDecreasing = true;
                }

                if (current - next < 0)
                {
                    isIncreasing = true;
                }

                if (current - next == 0)
                {
                    isValid = false;
                    break;
                }

                var diff = Math.Abs(current - next);
                if (diff is > 0 and <= 3)
                {
                    isValid = true;
                }
                else
                {
                    isValid = false;
                    break;
                }
            }


            if (isIncreasing && isDecreasing)
            {
                isValid = false;
            }


            if (isValid)
            {
                answer++;
            }
        }

        // answer.Should().Be(2);
        Answer.Submit(answer);
    }


    [Test]
    public void Part2()
    {
        int answer = 0;
        
            
        }
        
    }
}