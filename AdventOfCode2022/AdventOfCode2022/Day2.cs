using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022
{
    public static class Day2
    {
        public static void PartOne()
        {

            Dictionary<char, int> points = new()
            {
                {'A', 1 },
                {'B', 2 },
                {'C', 3 },
                {'X', 1 },
                {'Y', 2 },
                {'Z', 3 },
            };

            int totalPoints = 0;
            using StreamReader streamReader = new("input.txt");
            while (streamReader.EndOfStream is not true)
            {
                string line = streamReader.ReadLine() ?? string.Empty;
                char[] choices = line.Replace(" ", "").ToCharArray();
                totalPoints += (points[choices[1]] - points[choices[0]]) switch
                {
                    1 or -2 => points[choices[1]] + 6,
                    0 => points[choices[1]] + 3,
                    _ => points[choices[1]],
                };
            }
            Console.WriteLine($"Total points: {totalPoints}");
        }

        public static void PartTwo()
        {

            Dictionary<char, int> points = new()
            {
                {'A', 1 },
                {'B', 2 },
                {'C', 3 },
                {'X', 1 },
                {'Y', 2 },
                {'Z', 3 },
            };

            int totalPoints = 0;
            using StreamReader streamReader = new("Inputs/day2.txt");
            while (streamReader.EndOfStream is not true)
            {
                string? line = streamReader.ReadLine() ?? string.Empty;
                char[] choices = line.Replace(" ", "").ToCharArray();

                totalPoints += choices[1] switch
                {
                    'X' => points.FirstOrDefault(x => new int[] { -1, 2 }.Contains(x.Value - points[choices[0]])).Value,
                    'Y' => points.FirstOrDefault(x => new int[] { 0 }.Contains(x.Value - points[choices[0]])).Value + 3,
                    'Z' => points.FirstOrDefault(x => new int[] { 1, -2 }.Contains(x.Value - points[choices[0]])).Value + 6,
                    _ => 0,
                };
            }

            Console.WriteLine($"Total points: {totalPoints}");
        }
    }
}
