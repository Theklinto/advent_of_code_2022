using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022
{
    public static class Day1
    {
        public static void PartOne()
        {
            List<int> elves = new();
            using (StreamReader reader = new("Inputs/day1.txt"))
            {
                int calories = 0;
                while (!reader.EndOfStream)
                {
                    string? line = reader.ReadLine();
                    if (string.IsNullOrEmpty(line))
                    {
                        elves.Add(calories);
                        calories = 0;
                    }
                    else
                        calories += int.Parse(line);
                }
            }

            StringBuilder stringBuilder = new();
            stringBuilder.AppendLine("The top three elves are carrying:");
            elves = elves.OrderByDescending(x => x).Take(3).ToList();
            for (int i = 0; i < elves.Count; i++)
            {
                stringBuilder.AppendLine($" {i + 1}: {elves[i]}");
            }
            stringBuilder.AppendLine($"Totalling {elves.Sum()} calories");
            Console.WriteLine(stringBuilder.ToString());
        }
    }
}
