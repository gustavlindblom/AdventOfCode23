using Shared;

namespace Day1;

public class Day1 : IAoCSolution
{

    private string _input = string.Empty;
    private string[] _lines = Array.Empty<string>();
    
    public void Setup()
    {
        _input = File.ReadAllText($"{Directory.GetCurrentDirectory()}\\Days\\Day1\\input.txt");
        _lines = _input.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
    }

    public void Part1()
    {
        int sum = 0;
        char first = '\0', last = '\0';
        foreach (string line in _lines)
        {
            foreach (var c in line.Where(char.IsDigit))
            {
                last = c;
                if (first == '\0') first = c;
            }   
            
            string number = new string(first, last);
            
            sum += int.Parse(number);
            first = '\0';
        }
        Console.WriteLine("Part 1: " + sum);
    }

    private enum Numbers
    {
        one     = '1',
        two     = '2',
        three   = '3',
        four    = '4',
        five    = '5',
        six     = '6',
        seven   = '7',
        eight   = '8',
        nine    = '9'
    }

    public void Part2()
    {
        string[] numbers = Enum.GetNames(typeof(Numbers));
        
        int sum = 0;
        char first = '\0', last = '\0';
        
        foreach (string line in _lines)
        {
            int firstOccurence = int.MaxValue;
            int lastOccurence = int.MinValue;
            string firstNumber = string.Empty, lastNumber = string.Empty;
            
            foreach (var c in line.Where(char.IsDigit))
            {
                last = c;
                if (first == '\0') first = c;
            }

            foreach (string number in numbers)
            {
                int f = line.IndexOf(number, StringComparison.Ordinal);
                int l = line.LastIndexOf(number, StringComparison.Ordinal);
                if (f >= 0 && f < firstOccurence)
                {
                    firstNumber = number;
                    firstOccurence = f;
                }

                if (l >= 0 && l > lastOccurence)
                {
                    lastNumber = number;
                    lastOccurence = l;
                }
            }

            if (firstOccurence < line.IndexOf(first) || !line.Contains(first))
            {
                first = (char)Enum.Parse<Numbers>(firstNumber);
            }

            if (lastOccurence > line.LastIndexOf(last))
            {
                last = (char)Enum.Parse<Numbers>(lastNumber);
            }

            string parsedNumber = new string(new [] { first, last });
            Console.WriteLine(parsedNumber);
            sum += int.Parse(parsedNumber);
            first = '\0';
        }
        Console.WriteLine("Part 2: " + sum);
    }
}