using System.Text.RegularExpressions;
using Pillsgood.AdventOfCode;

namespace AOC.Y2023;

public class Day01 : AocFixture
{
    private string[] _input;

    [OneTimeSetUp]
    public void Setup() => _input = Input.Get<string[]>();

    [Test]
    public void Part1()
    {
        var answer = 0;

        foreach (var input in _input)
        {
            var tempNumbers = new List<int>();

            foreach (var letter in input)
            {
                if (char.IsDigit(letter))
                {
                    tempNumbers.Add(letter - '0');
                }
            }

            if (tempNumbers.Count <= 0)
            {
                answer += 0;
            }
            else if (tempNumbers.Count == 1)
            {
                answer += tempNumbers[0] + tempNumbers[0] * 10;
            }
            else if (tempNumbers.Count >= 2)
            {
                answer += tempNumbers[0] * 10 + tempNumbers[^1];
            }
        }

        Answer.Submit(answer);
    }

    [Test]
    public void Part2()
    {
        var numberText = new List<string>()
            { "", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
        var answer = 0;

        var inputList = _input;


        foreach (var input in inputList)
        {
            var inputLower = input.ToLower();


            var pattern = "(one|two|three|four|five|six|seven|eight|nine|[1-9])";
            var normalPattern = new Regex(pattern);
            var fromBackPattern = new Regex(pattern,
                RegexOptions.RightToLeft);

            var firstNumber = normalPattern.Match(inputLower).Value;
            var lastNumber = fromBackPattern.Match(inputLower).Value;

            if (numberText.Contains(firstNumber))
            {
                firstNumber = numberText.IndexOf(firstNumber).ToString();
            }

            if (numberText.Contains(lastNumber))
            {
                lastNumber = numberText.IndexOf(lastNumber).ToString();
            }


            var number = int.Parse(firstNumber + lastNumber);
            

            answer += number;
            
           
        }
        Answer.Submit(answer);
    }
}