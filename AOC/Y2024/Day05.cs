using System.Numerics;
using System.Text.RegularExpressions;
using AOC.Common;
using Pillsgood.AdventOfCode;

namespace AOC.Y2024;

public class Day05 : AocFixture
{
    private string[] _input;
    private List<Rule> _rules;
    private List<List<int>> _tests;


    private string sample =
        """
        47|53
        97|13
        97|61
        97|47
        75|29
        61|13
        75|53
        29|13
        97|29
        53|29
        61|53
        97|53
        61|29
        47|13
        75|47
        97|75
        47|61
        75|61
        47|29
        75|13
        53|13

        75,47,61,53,29
        97,61,53,29,13
        75,29,13
        75,97,47,61,53
        61,13,29
        97,13,75,29,47
        """;

    [OneTimeSetUp]
    public void Setup()
    {
        _input = Input.Get<string[]>();

        _input = sample
            .Split("\r\n", StringSplitOptions.RemoveEmptyEntries)
            .ToArray();


        _rules = new List<Rule>();

        _tests = new List<List<int>>();

        foreach (var row in _input)
        {
            if (row.Contains('|'))
            {
                var parts = row.Split('|').Select(int.Parse).ToArray();
                var rule = new Rule(parts[0], parts[1]);
                _rules.Add(rule);
            }
            else
            {
                var a = row.Split(',', StringSplitOptions.TrimEntries).Select(int.Parse).ToList();
                _tests.Add(a);
            }
        }
    }


    [Test]
    public void Part1()
    {
        var part1 = 0;

        
        
        foreach (var test in _tests)
        {
            var isValidate = true;
            foreach (var rule in _rules)
            {
                var currentNumberIndex = test.IndexOf(rule.Left);
                var validationNumberIndex = test.IndexOf(rule.Right);


                if (currentNumberIndex == -1 || validationNumberIndex == -1)
                {
                    continue;
                }


                if (currentNumberIndex > validationNumberIndex)
                {
                    isValidate = false;
                    break;
                }
            }

            if (isValidate)
            {
                part1 += test[test.Count / 2];
            }
            else
            {
                
            }
        }

        Console.WriteLine(part1);
    }

    private record Rule(int Left, int Right);
}