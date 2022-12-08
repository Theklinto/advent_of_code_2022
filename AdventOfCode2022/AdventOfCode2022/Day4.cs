using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022
{
    public static class Day4
    {
        public static void PartOne()
        {
            using StreamReader stream = new("Inputs/day4.txt");

            int count = 0;
            while (stream.EndOfStream is not true)
            {
                string input = stream.ReadLine() ?? string.Empty;
                List<(int start, int end)> ranges = input.Split(',')
                    .Select(x => (
                        int.Parse(x.Split('-')[0]),
                        int.Parse(x.Split('-')[1])
                        )
                    )
                    .OrderByDescending(x => x.Item2 - x.Item1)
                    .ToList();
                if (ranges[0].start <= ranges[1].start &&
                    ranges[0].end >= ranges[1].end)
                    count++;
            }

            Console.WriteLine($"In {count} cases does the range overlap entirely");
        }

        public static void PartTwo()
        {
            using StreamReader stream = new("Inputs/day4.txt");

            int count = 0;
            while (stream.EndOfStream is not true)
            {
                string input = stream.ReadLine() ?? string.Empty;
                List<(int start, int end)> ranges = input.Split(',')
                    .Select(x => (
                        int.Parse(x.Split('-')[0]),
                        int.Parse(x.Split('-')[1])
                        )
                    )
                    .OrderByDescending(x => x.Item2 - x.Item1)
                    .ToList();

                List<int> test0 = Enumerable.Range(ranges[0].start, ranges[0].end - ranges[0].start + 1).ToList();
                List<int> test1 = Enumerable.Range(ranges[1].start, ranges[1].end - ranges[1].start + 1).ToList();

                if (test0.Except(test1).Count() != test0.Count || test1.Except(test0).Count() != test1.Count)
                    count++;


                //if (Enumerable.Range(ranges[0].start, ranges[0].end).Any(x => Enumerable.Range(ranges[1].start, ranges[1].end).Contains(x)))
                //    count++;
            }

            Console.WriteLine($"In {count} cases does the range overlap");
        }
    }
}
