using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022
{
    public static class Day3
    {
        public static void PartOne()
        {
            int sum = 0;
            using StreamReader stream = new("Inputs/day3.txt");
            while (stream.EndOfStream is not true)
            {
                string everything = stream.ReadLine() ?? string.Empty;
                (char[] comp1, char[] comp2) backpack = new()
                {
                    comp1 = everything[..(everything.Length / 2)].ToArray(),
                    comp2 = everything[(everything.Length / 2)..].ToArray(),
                };

                sum += backpack.comp1
                    .Where(x => backpack.comp2.Contains(x))
                    .Select(x => x % 32 + (char.IsLower(x) ? 0 : 26))
                    .Distinct()
                    .Sum();
            }

            Console.WriteLine($"Total priority of items placed in both compartments: {sum}");
        }

        public static void PartTwo()
        {
            int sum = 0;
            using StreamReader stream = new("Inputs/day3.txt");
            while (stream.EndOfStream is not true)
            {
                List<char[]> group = new();
                for (int i = 0; i < 3; i++)
                    group.Add((stream.ReadLine() ?? string.Empty).ToCharArray());

                char badge = group[0].FirstOrDefault(x => group.All(y => y.Contains(x)));
                sum += badge % 32 + (char.IsLower(badge) ? 0 : 26);

            }

            Console.WriteLine($"Total priority of badge items: {sum}");
        }
    }
}
