namespace ClassLib;

public class Lab3
{
    public static string Execute(string inputData)
    {
        try
        {
            var (n, channels) = ParseInputData(inputData);
            
            var (minStationsCount, optimalSolutions) = FindOptimalStationSets(n, channels);
            
            var result = $"{minStationsCount} {optimalSolutions.Count}\n" +
                         $"{string.Join(" ", optimalSolutions[0].OrderBy(x => x))}";
            
            return result;
        }
        catch (Exception e)
        {
            return "Something went wrong: " + e.Message;
        }
    }
    
    private static (int, List<(int, int)>) ParseInputData(string inputData)
    {
        if (inputData.Length == 0)
        {
            throw new InputException($"No data provided for input");
        }
        
        var lines = inputData.Split('\n') 
            .Select(static line => line.Trim())
            .Where(static line => !string.IsNullOrWhiteSpace(line))
            .ToArray();
        
        var firstLine = lines[0]
            .Split(' ', StringSplitOptions.RemoveEmptyEntries);
        
        if (firstLine.Length != 2)
        {
            throw new InputException("The first line must contain two numbers");
        }

        if (!int.TryParse(firstLine[0], out var n) || !int.TryParse(firstLine[1], out var m))
        {
            throw new InputException("The first line must contain integer numbers");
        }

        if (n < 2 || n > 18)
        {
            throw new InputException("The first number must be between 2 and 18");
        }
        
        if (m < 0)
        {
            throw new InputException("The second number must be greater than 0");
        }

        if (lines.Length - 1 != m)
        {
            throw new InputException("The entered number of rows does not match the specified number.");
        }
        
        var channels = new List<(int, int)>();
        for (var i = 1; i < lines.Length; i++)
        {
            var row= lines[i]
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            if (row.Length != 2)
            {
                throw new InputException("Each row must contain 2 numbers.");
            }
            
            if (!int.TryParse(row[0], out var u))
            {
                throw new InputException("All matrix values must be integers.");
            }
                
            if (!int.TryParse(row[1], out var v))
            {
                throw new InputException("All matrix values must be integers.");
            }
            
            if (u < 1 || u > n || v < 1 || v > n || u == v)
            {
                throw new InputException($"Invalid connection channel ({u}, {v})");
            }
            
            if (channels.Contains((u, v)) || channels.Contains((v, u)))
            {
                throw new InputException($"The connection ({u}, {v}) already exists.");
            }
            
            channels.Add((u, v));
        }
        
        return (n, channels);
    }
    
    private static (int, List<HashSet<int>>) FindOptimalStationSets(int n, List<(int, int)> channels)
    {
        var minStationsCount = n;
        var optimalSolutions = new List<HashSet<int>>();
        
        for (var mask = 1; mask < Math.Pow(2, n); mask++)
        {
            var currentSet = new HashSet<int>();
            for (var i = 0; i < n; i++)
            {
                if ((mask & (1 << i)) != 0)
                {
                    currentSet.Add(i + 1);
                }
            }
            
            if (!AreAllChannelsControlled(currentSet, channels)) continue;
            
            if (currentSet.Count < minStationsCount)
            {
                minStationsCount = currentSet.Count;
                optimalSolutions.Clear();
                optimalSolutions.Add(currentSet);
            }
            else if (currentSet.Count == minStationsCount)
            {
                optimalSolutions.Add(currentSet);
            }
        }

        return (minStationsCount, optimalSolutions);
    }

    private static bool AreAllChannelsControlled(HashSet<int> stationSet, List<(int, int)> channels)
    {
        return channels.All(channel =>
            stationSet.Contains(channel.Item1) || stationSet.Contains(channel.Item2));
    }
}