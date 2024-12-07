using System.Xml.Xsl;
using Pillsgood.AdventOfCode;

namespace AOC.Y2024;

public class Day01 : AocFixture
{
    private string[] _input;

    private string sample = """
                            3   4
                            4   3
                            2   5
                            1   3
                            3   9
                            3   3
                            """;

    [OneTimeSetUp]
    public void Setup()
    {
        _input = Input.Get<string[]>();

        // _input = sample.Split("\n", StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
    }


    [Test]
    public void Part1()
    {
        var answer = 0;

        var LeftNumbers = new List<int>();
        var RightNumbers = new List<int>();

        foreach (var input in _input)
        {
            var numbers = input.Split("  ");

            LeftNumbers.Add(int.Parse(numbers[0]));
            RightNumbers.Add(int.Parse(numbers[1]));
        }


        LeftNumbers.Sort();
        RightNumbers.Sort();

        for (var i = 0; i < LeftNumbers.Count; i++)
        {
            answer += Math.Abs(LeftNumbers[i] - RightNumbers[i]);
        }

        Answer.Submit(answer);
    }

    [Test]
    public void Part2()
    {
        var answer = 0;
        
        var LeftNumbers = new List<int>();
        var RightNumbers = new Dictionary<int,int>();
        
        foreach (var input in _input)
        {
            var numbers = input.Split("  ");

            LeftNumbers.Add(int.Parse(numbers[0]));
            var rightNumber = numbers[1];
            if (RightNumbers.ContainsKey(int.Parse(rightNumber)))
            {
              
                RightNumbers[int.Parse(rightNumber)]++;
            }
            else
            {
                RightNumbers.Add(int.Parse(rightNumber), 1);
            }
        }

        for (int i = 0; i < LeftNumbers.Count; i++)
        {
            var number = LeftNumbers[i];
            
            if(RightNumbers.ContainsKey(number))  {answer += number * RightNumbers[number];}
        }
        
        Answer.Submit(answer);


      
    }
}