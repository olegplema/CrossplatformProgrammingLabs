using App;

int n;
List<(int, int)> channels;

try
{
    (n, channels) = FileProcessor.ParseInputFile();
}
catch (Exception e)
{
    Console.WriteLine("Виникла помилка: " + e.Message);
    return;
}

int minStationsCount;
List<HashSet<int>> optimalSolutions;

try
{
    (minStationsCount, optimalSolutions) = ChannelService.FindOptimalStationSets(n, channels);
}
catch (Exception e)
{
    Console.WriteLine("Виникла помилка: " + e.Message);
    return;
}

try
{
    FileProcessor.WriteOutputFile(minStationsCount, optimalSolutions);
}
catch (Exception e)
{
    Console.WriteLine("Виникла помилка: " + e.Message);
}