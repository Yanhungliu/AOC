using AOC.Common;
using FluentAssertions;
using Pillsgood.AdventOfCode;

namespace AOC.Y2024;

public class Day02Refactor : AocFixture
{
    private string[] _input;


    private IEnumerable<IEnumerable<int>> _rows;

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
                    .Select(int.Parse).ToList());
    }


    [Test]
    public void Part1()
    {
        bool IsSafePart1(IEnumerable<int> numbers) => IsSafe(numbers.Pairwise((x, y) => x - y));

        var answer = _rows.Count(IsSafePart1);

        answer.Should().Be(252);
    }

    [Test]
    public void Part2()
    {
        bool IsSafePart1(IEnumerable<int> numbers) => IsSafe(numbers.Pairwise((x, y) => x - y));

        bool IsSafePart2(IEnumerable<int> numbers)
        {
            var enumerable = numbers as IReadOnlyList<int> ?? numbers.ToArray();
            return Enumerable.Range(0, enumerable.Count())
                .Any(i => IsSafePart1(enumerable.SkipElementAt(i)));
        }

        var answer = _rows.Count(IsSafePart2);
        
        Answer.Submit(answer);
    }


    private bool IsSafe(IEnumerable<int> numbers)
    {
        // [1,2,-3,2], sign: 1 -> [1,2,-3,2]
        var enumerable = numbers as IReadOnlyList<int> ?? numbers.ToArray();
        var sign = Math.Sign(enumerable[0]);
        return enumerable.All(number => (number * sign) is >= 1 and <= 3);
    }
}
