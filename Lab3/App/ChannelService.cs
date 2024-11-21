namespace App;

public static class ChannelService
{
    public static (int, List<HashSet<int>>) FindOptimalStationSets(int n, List<(int, int)> channels)
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