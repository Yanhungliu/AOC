using Pillsgood.AdventOfCode;

namespace AOC.Y2024;

public class Day01Refactor : AocFixture
{
    private string[] _input;

    private (int left, int right)[] _numbers;

    private int[] left;
    private int[] right;

    private readonly string _sample = """
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


        left = _input
            .Select(numbers =>
                numbers.Split("  ", StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries))
            .Select(part => part[0])
            .Select(int.Parse)
            .Order()
            .ToArray();


        right = _input
            .Select(numbers =>
                numbers.Split("  ", StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries))
            .Select(part => part[1])
            .Select(int.Parse)
            .Order()
            .ToArray();
    }

    [Test]
    public void Part1()
    {
        var answer = left
            .Zip(right, (l, r) => Math.Abs(l - r))
            .Sum();


        Console.WriteLine(answer); //correct ans:1579939
    }


    [Test]
    public void Part2()
    {
        var rightDictionary = right
            .GroupBy(x => x)  
            .ToDictionary(g => g.Key, g => g.Count());  

        
        var answer = left
            .Where(l => rightDictionary.ContainsKey(l))  
            .Sum(l => l * rightDictionary[l]); 

        Answer.Submit(answer); //correct ans:20351745
    }
}