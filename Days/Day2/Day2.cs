using Shared;

namespace Day2;

public class Day2 : IAoCSolution
{
    private string _input = string.Empty;
    private string[] _lines = Array.Empty<string>();

    public void Setup()
    {
        _input = File.ReadAllText($"{Directory.GetCurrentDirectory()}\\Days\\Day2\\input.txt");
        _lines = _input.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
    }

    private const int GameIdIndex = 5;

    public void Part1()
    {
        int result = 0;

        foreach (string line in _lines)
        {
            string gameId = string.Empty;
            using IEnumerator<char> enumerator = line.Skip(GameIdIndex).GetEnumerator();
            while (enumerator.MoveNext() && char.IsDigit(enumerator.Current))
            {
                gameId += enumerator.Current;
            }

            int parsedGameId = int.Parse(gameId);

            enumerator.MoveNext();

            Dictionary<string, int> cubeColorOccurences = new Dictionary<string, int>
            {
                { "red", 0 },
                { "green", 0 },
                { "blue", 0 }
            };
            
            bool possible = true;
            while (true)
            {
                string cubeNumber = string.Empty;
                string cubeColor = string.Empty;

                while (enumerator.MoveNext() && char.IsDigit(enumerator.Current))
                {
                    cubeNumber += enumerator.Current;
                }

                int parsedCubeNumber = int.Parse(cubeNumber);
                while (enumerator.MoveNext() && char.IsAsciiLetter(enumerator.Current))
                    cubeColor += enumerator.Current;

                cubeColorOccurences[cubeColor] += parsedCubeNumber;
                char lastChar = enumerator.Current;
                bool hasMore = enumerator.MoveNext();
                if (!hasMore || lastChar == ';')
                {
                    if (cubeColorOccurences["red"] > 12 ||
                        cubeColorOccurences["green"] > 13 ||
                        cubeColorOccurences["blue"] > 14)
                        possible = false;
                    
                    cubeColorOccurences["red"] = 0;
                    cubeColorOccurences["green"] = 0;
                    cubeColorOccurences["blue"] = 0;
                }

                if (!hasMore)
                    break;
            }

            if (!possible) continue;
            result += parsedGameId;
        }

        Console.WriteLine("Part one: " + result);
    }

    public void Part2()
    {
        int result = 0;

        foreach (string line in _lines)
        {
            string gameId = string.Empty;
            using IEnumerator<char> enumerator = line.Skip(GameIdIndex).GetEnumerator();
            while (enumerator.MoveNext() && char.IsDigit(enumerator.Current))
            {
                gameId += enumerator.Current;
            }

            int parsedGameId = int.Parse(gameId);

            enumerator.MoveNext();

            Dictionary<string, int> cubeColorOccurences = new Dictionary<string, int>
            {
                { "red", 0 },
                { "green", 0 },
                { "blue", 0 }
            };
            
            int minimumRed = int.MinValue;
            int minimumGreen = int.MinValue;
            int minimumBlue = int.MinValue;
            
            while (true)
            {
                string cubeNumber = string.Empty;
                string cubeColor = string.Empty;

                while (enumerator.MoveNext() && char.IsDigit(enumerator.Current))
                {
                    cubeNumber += enumerator.Current;
                }

                int parsedCubeNumber = int.Parse(cubeNumber);
                while (enumerator.MoveNext() && char.IsAsciiLetter(enumerator.Current))
                    cubeColor += enumerator.Current;

                cubeColorOccurences[cubeColor] += parsedCubeNumber;
                char lastChar = enumerator.Current;
                bool hasMore = enumerator.MoveNext();
                if (!hasMore || lastChar == ';')
                {
                    if (cubeColorOccurences["red"] > minimumRed)
                        minimumRed = cubeColorOccurences["red"];
                    if (cubeColorOccurences["green"] > minimumGreen)
                        minimumGreen = cubeColorOccurences["green"];
                    if (cubeColorOccurences["blue"] > minimumBlue)
                        minimumBlue = cubeColorOccurences["blue"];
                    
                    cubeColorOccurences["red"] = 0;
                    cubeColorOccurences["green"] = 0;
                    cubeColorOccurences["blue"] = 0;
                }

                if (!hasMore)
                    break;
            }

            int power = minimumRed * minimumBlue * minimumGreen;
            result += power;
        }

        Console.WriteLine("Part two: " + result);
    }
}