using AOC.Common;
using Pillsgood.AdventOfCode;

namespace AOC.Y2024;

public class Day06 : AocFixture
{
    public string sample = """
                           ....#.....
                           .........#
                           ..........
                           ..#.......
                           .......#..
                           ..........
                           .#..^.....
                           ........#.
                           #.........
                           ......#...
                           """;


    [OneTimeSetUp]
    public void Setup()
    {
        var laboratoryMap = sample
            .Split('\n', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries).ToList();

        var height = laboratoryMap.Count;
        var width = laboratoryMap[0].Length;

        // foreach (var s in laboratoryMap)
        // {
        //     Console.WriteLine(s);
        // }


        Console.WriteLine($"Map Height: {height}  Map Width: {width}");


        var startPosition = laboratoryMap
            .Select((line, rowIndex) =>
            {
                var colIndex = line.IndexOfAny([
                    (char)Facing.Up, (char)Facing.Down, (char)Facing.Left, (char)Facing.Right
                ]);

                var facing = colIndex != -1 ? (Facing)line[colIndex] : default;

                return ((rowIndex, colIndex), facing);
            })
            .FirstOrDefault(pos => pos.Item1.colIndex != -1);

        Console.WriteLine($"Start Position : {startPosition}");

        var obstaclesPosition = laboratoryMap
            .Select((line, rowIndex) => (RowIndex: rowIndex, ColIndex: line.IndexOf('#')))
            .Where(pos => pos.ColIndex != -1)
            .ToList();

        Console.WriteLine("Obstacles (row,col):");
        foreach (var valueTuple in obstaclesPosition)
        {
            Console.WriteLine(valueTuple);
            Console.WriteLine("-------");
        }


        while (true)
        {
            var policeColIndex = startPosition.Item1.colIndex;
            var policeRowIndex = startPosition.Item1.rowIndex;
            (int RowIndex, int ColIndex) target = (-1, -1);

            Console.WriteLine($"Start From:{startPosition}");


            if (startPosition.facing is Facing.Right)
            {
                target = obstaclesPosition
                    .Where(obs => obs.RowIndex == policeRowIndex)
                    .Where(obs => obs.ColIndex > policeColIndex)
                    .OrderBy(obs => Math.Abs(policeColIndex - obs.ColIndex))
                    .DefaultIfEmpty((RowIndex: -1, ColIndex: -1))
                    .First();

                laboratoryMap = laboratoryMap
                    .Select((line, rowIndex) =>
                    {
                        if (rowIndex == policeRowIndex)
                        {
                            return line.ReplaceFrom(policeColIndex, target.ColIndex - 2, 'X')
                                .ReplaceAt(target.ColIndex - 1, (char)Facing.Down);
                        }

                        return line;
                    })
                    .ToList();

                startPosition = ((target.RowIndex, target.ColIndex - 1), Facing.Down);
            }

            if (startPosition.facing is Facing.Up)
            {
                target = obstaclesPosition
                    .Where(obs => obs.ColIndex == policeColIndex)
                    .Where(obs => obs.RowIndex < policeRowIndex)
                    .OrderBy(obs => Math.Abs(policeRowIndex - obs.RowIndex))
                    .DefaultIfEmpty((RowIndex: -1, ColIndex: -1))
                    .First();

                laboratoryMap = laboratoryMap
                    .Select((line, rowIndex) =>
                    {
                        if (rowIndex <= policeRowIndex && rowIndex - 1 > target.RowIndex)
                        {
                            return line.ReplaceAt(policeColIndex, 'X');
                        }

                        if (rowIndex - 1 == target.RowIndex)
                        {
                            return line.ReplaceAt(policeColIndex, (char)Facing.Right);
                        }

                        return line;
                    })
                    .ToList();


                startPosition = ((target.RowIndex + 1, target.ColIndex), Facing.Right);
            }


            if (target.RowIndex == -1)
            {
                break;
            }


            foreach (var s in laboratoryMap)
            {
                Console.WriteLine(s);
            }

            Console.WriteLine($"Obstacles:{target}");
            Console.WriteLine($"New Start Position : {startPosition}");
        }
    }


    [Test]
    public void Part1()
    {
    }
}

public enum Facing
{
    None = 0,
    Up = '^',
    Down = 'v',
    Left = '<',
    Right = '>'
}