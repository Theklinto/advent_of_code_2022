using System.Text;

List<int> elves = new();
using (StreamReader reader = new("input.txt"))
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