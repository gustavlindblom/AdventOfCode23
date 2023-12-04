using Shared;

namespace Day3;

public class Day3 : IAoCSolution
{
    private string _input = string.Empty;
    private string[] _lines = Array.Empty<string>();

    public void Setup()
    {
        _input = File.ReadAllText($"{Directory.GetCurrentDirectory()}\\Days\\Day3\\input.txt");
        _lines = _input.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
    }

    public void Part1()
    {
        int result = 0;
        int length = _lines[0].Length;
        int row = 0;
        int col = 0;
        for (int i = 0; i < _input.Length; i++)
        {
            if (IsSymbol(_input[i]))
            {
                int[] found = new int[6];
                int foundIndex = 0;
                for (int dx = -1; dx < 2; dx++)
                {
                    if (col + dx < 0 || col + dx >= length)
                        continue;
                    
                    for (int dy = -1; dy < 2; dy++)
                    {
                        if (row + dy < 0 || row + dy >= _lines.Length)
                            continue;

                        char adjacent = _lines[row + dy][col + dx];
                        if (!char.IsDigit(adjacent)) continue;
                        
                        int charStart = col + dx;
                        while (charStart >= 0 && char.IsDigit(_lines[row + dy][charStart]))
                        {
                            charStart--;
                        }

                        charStart++;

                        string adjacentNumber = string.Empty;
                        while (charStart < length && char.IsDigit(_lines[row + dy][charStart]))
                        {
                            adjacentNumber += _lines[row + dy][charStart];
                            charStart++;
                        }

                        int parsedNumber = int.Parse(adjacentNumber);
                        if (found.Contains(parsedNumber)) continue;
                        found[foundIndex] = parsedNumber;
                        foundIndex++;
                    }
                }

                result += found.Sum();
            }
            
            col++;

            if (!char.IsWhiteSpace(_input[i])) continue;
            
            row++;
            col = 0;
            i++; // Skip an additional character due to windows newlines
        }

        Console.WriteLine("Part one: " + result);
        return;
        bool IsSymbol(char c) => !char.IsDigit(c) && !char.IsWhiteSpace(c) && c != '.';
    }

    public void Part2()
    {
        int result = 0;
        int length = _lines[0].Length;
        int row = 0;
        int col = 0;
        for (int i = 0; i < _input.Length; i++)
        {
            if (IsGearSymbol(_input[i]))
            {
                int[] found = new int[6];
                int foundIndex = 0;
                for (int dx = -1; dx < 2; dx++)
                {
                    if (col + dx < 0 || col + dx >= length)
                        continue;
                    
                    for (int dy = -1; dy < 2; dy++)
                    {
                        if (row + dy < 0 || row + dy >= _lines.Length)
                            continue;

                        char adjacent = _lines[row + dy][col + dx];
                        if (!char.IsDigit(adjacent)) continue;
                        
                        int charStart = col + dx;
                        while (charStart >= 0 && char.IsDigit(_lines[row + dy][charStart]))
                        {
                            charStart--;
                        }

                        charStart++;

                        string adjacentNumber = string.Empty;
                        while (charStart < length && char.IsDigit(_lines[row + dy][charStart]))
                        {
                            adjacentNumber += _lines[row + dy][charStart];
                            charStart++;
                        }

                        int parsedNumber = int.Parse(adjacentNumber);
                        if (found.Contains(parsedNumber)) continue;
                        
                        found[foundIndex] = parsedNumber;
                        foundIndex++;
                    }
                }

                if (foundIndex == 2)
                {
                    result += found[0] * found[1];
                }
            }
            
            col++;

            if (!char.IsWhiteSpace(_input[i])) continue;
            
            row++;
            col = 0;
            i++; // Skip an additional character due to windows newlines
        }

        Console.WriteLine("Part two: " + result);
        return;
        bool IsGearSymbol(char c) => c == '*';
    }
}