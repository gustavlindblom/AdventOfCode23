// See https://aka.ms/new-console-template for more information

using Shared;

if (args.Length == 0)
{
    Console.Error.WriteLine("USAGE: dotnet run <day-number>");
    return;
}

Dictionary<int, IAoCSolution> days = new()
{
    { 1, new Day1.Day1() },
    { 2, new Day2.Day2() },
};

if (!int.TryParse(args[0], out int dayInput))
{
    Console.Error.WriteLine("ERROR: Could not parse {0} as integer", args[0]);
    return;
}

if (!days.ContainsKey(dayInput))
{
    Console.Error.WriteLine("ERROR: Day {0} not implemented.", dayInput);
    return;
}

IAoCSolution day = days[dayInput];
day.Setup();
day.Part1();
day.Part2();