using System.Numerics;
using System.Text.RegularExpressions;
using Pillsgood.AdventOfCode;

namespace AOC.Y2024;

public class Day04 : AocFixture
{
    private string[] _input;


    // private string sample =
    //     """
    //     MMMSXXMASM
    //     MSAMXMSMSA
    //     AMXSXMAAMM
    //     MSAMASMSMX
    //     XMASAMXAMM
    //     XXAMMXXAMA
    //     SMSMSASXSS
    //     SAXAMASAAA
    //     MAMMMXMMMM
    //     MXMXAXMASX
    //     """;

    [OneTimeSetUp]
    public void Setup()
    {
        _input = Input.Get<string[]>();

        // _input = sample
        //     .Split("\n", StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)
        //     .ToArray();

        foreach (var s in _input)
        {
            Console.WriteLine(s);
        }
    }


    [Test]
    public void Part1()
    {
        var count = 0;

        var rows = _input.Length;
        var columns = _input[0].Length;

        for (int i = 0; i < rows; i++)
        {
            // var index = regex.Matches(_input[i]).Select(m => m.Index).ToList();
            // xPosition.AddRange(index.Select(num => new Vector2Int(i, num % 10)));

            for (int j = 0; j < columns; j++)
            {
                if (_input[i][j] != 'X') continue;

                // up
                if (i - 3 >= 0 && _input[i - 1][j] == 'M' && _input[i - 2][j] == 'A' && _input[i - 3][j] == 'S')
                    count++;

                // down
                if (i + 3 < rows && _input[i + 1][j] == 'M' && _input[i + 2][j] == 'A' && _input[i + 3][j] == 'S')
                    count++;

                // left
                if (j - 3 >= 0 && _input[i][j - 1] == 'M' && _input[i][j - 2] == 'A' && _input[i][j - 3] == 'S')
                    count++;

                // right
                if (j + 3 < columns && _input[i][j + 1] == 'M' && _input[i][j + 2] == 'A' && _input[i][j + 3] == 'S')
                    count++;

                // up-left
                if (i - 3 >= 0 && j - 3 >= 0 && _input[i - 1][j - 1] == 'M' && _input[i - 2][j - 2] == 'A' &&
                    _input[i - 3][j - 3] == 'S')
                    count++;

                // up-right
                if (i - 3 >= 0 && j + 3 < columns && _input[i - 1][j + 1] == 'M' && _input[i - 2][j + 2] == 'A' &&
                    _input[i - 3][j + 3] == 'S')
                    count++;

                // down-left
                if (i + 3 < rows && j - 3 >= 0 && _input[i + 1][j - 1] == 'M' && _input[i + 2][j - 2] == 'A' &&
                    _input[i + 3][j - 3] == 'S')
                    count++;

                // down-right
                if (i + 3 < rows && j + 3 < columns && _input[i + 1][j + 1] == 'M' && _input[i + 2][j + 2] == 'A' &&
                    _input[i + 3][j + 3] == 'S')
                    count++;
            }
        }

        Answer.Submit(count);

        // Console.WriteLine(count);
    }


    public struct Vector2Int : IEquatable<Vector2Int>
    {
        private int X { get; set; }
        private int Y { get; set; }

        public Vector2Int(int y, int x)
        {
            X = x;
            Y = y;
        }


        public bool Equals(Vector2Int other)
        {
            return X == other.X && Y == other.Y;
        }

        public override bool Equals(object? obj)
        {
            return obj is Vector2Int other && Equals(other);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(X, Y);
        }

        public override string ToString()
        {
            return $"({Y}, {X})";
        }
    }
}