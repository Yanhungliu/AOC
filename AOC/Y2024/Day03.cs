using System.Text.RegularExpressions;
using AOC.Common;
using Pillsgood.AdventOfCode;

namespace AOC.Y2024;

public class Day03 : AocFixture
{
    private string _input;


    // private string sample =
    // "xmul(2,4)&mul[3,7]!^don't()_mul(5,5)+mul(32,64](mul(11,8)undo()?mul(8,5))don't()_mul(5,5)+mul(32,64";

    [OneTimeSetUp]
    public void Setup()
    {
        _input = Input.Get<string>();

        // _input = sample;
    }


    [Test]
    public void Part1()
    {
        var answer = AddUp(_input);

        Answer.Submit(answer);
    }

    [Test]
    public void Part2()
    {
        var action = new Regex(@"don't\(\)(.|[\r\n])*?do\(\)");
        var action2 = new Regex(@"don't\(\).*", RegexOptions.RightToLeft);

        _input = action.Replace(_input, string.Empty);
        _input = action2.Replace(_input, string.Empty, 1);


        var answer = AddUp(_input);

        Answer.Submit(answer);
    }

    private int AddUp(string input)
    {
        var searchNumbers = new Regex(@"mul\((\d{1,3}),(\d{1,3})\)");

        var leftNumbers = searchNumbers.Matches(input).Select(m => int.Parse(m.Groups[1].Value)).ToArray();
        var rightNumbers = searchNumbers.Matches(input).Select(m => int.Parse(m.Groups[2].Value)).ToArray();

        return leftNumbers.Zip(rightNumbers, (l, r) => l * r).Sum();
    }
}