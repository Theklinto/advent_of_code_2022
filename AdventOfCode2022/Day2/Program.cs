void PartOne()
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
        string? line = streamReader.ReadLine();
        char[] choices = line.Replace(" ", "").ToCharArray();
        switch (points[choices[1]] - points[choices[0]])
        {
            case 1:
            case -2:
                totalPoints += points[choices[1]] + 6;
                break;

            case 0:
                totalPoints += points[choices[1]] + 3;
                break;

            default:
                totalPoints += points[choices[1]];
                break;
        }
    }
    Console.WriteLine($"Total points: {totalPoints}");
}

void PartTwo()
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
        string? line = streamReader.ReadLine();
        char[] choices = line.Replace(" ", "").ToCharArray();

        totalPoints += choices[1] switch
        {
            'X' => points.FirstOrDefault(x => new int[] { -1, 2 }.Contains(x.Value - points[choices[0]])).Value,
            'Y' => points.FirstOrDefault(x => new int[] { 0 }.Contains(x.Value - points[choices[0]])).Value + 3,
            'Z' => points.FirstOrDefault(x => new int[] { 1, -2 }.Contains(x.Value - points[choices[0]])).Value + 6,
        };
    }

    Console.WriteLine($"Total points: {totalPoints}");
}
PartTwo();