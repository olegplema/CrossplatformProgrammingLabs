using App;

namespace Tests
{
    public class ChannelServiceTests
    {
        [Fact]
        public void FindOptimalStationSets_WithSimpleChannels_ReturnsExpectedResult()
        {
            var n = 3;
            var channels = new List<(int, int)>
            {
                (1, 2),
                (2, 3)
            };
            
            var (minStationsCount, optimalSolutions) = ChannelService.FindOptimalStationSets(n, channels);
            
            Assert.Equal(1, minStationsCount);
            Assert.Single(optimalSolutions);
            Assert.Equal(new HashSet<int> { 2 }, optimalSolutions[0]);
        }
        
        [Fact]
        public void FindOptimalStationSets_WithNoChannels_ReturnsAllStations()
        {
            var n = 4;
            var channels = new List<(int, int)>();
            
            var (minStationsCount, optimalSolutions) = ChannelService.FindOptimalStationSets(n, channels);
            
            Assert.Equal(1, minStationsCount);
        }
        
        [Fact]
        public void FindOptimalStationSets_AllStationsConnected_ReturnsOneStation()
        {
            var n = 4;
            var channels = new List<(int, int)>
            {
                (1, 2),
                (2, 3),
                (3, 4),
                (4, 1)
            };
            
            var (minStationsCount, optimalSolutions) = ChannelService.FindOptimalStationSets(n, channels);
            
            Assert.Equal(2, minStationsCount);
            Assert.Equal(new HashSet<int> { 1, 3 }, optimalSolutions[0]);
        }
        
        [Fact]
        public void FindOptimalStationSets_MultipleOptimalSolutions_ReturnsAll()
        {
            var n = 4;
            var channels = new List<(int, int)>
            {
                (1, 2),
                (2, 3),
                (3, 4),
                (1, 4)
            };
            
            var (minStationsCount, optimalSolutions) = ChannelService.FindOptimalStationSets(n, channels);
            
            Assert.Equal(2, minStationsCount);
            Assert.Equal(2, optimalSolutions.Count);
            Assert.Contains(new HashSet<int> { 1, 3 }, optimalSolutions);
            Assert.Contains(new HashSet<int> { 2, 4 }, optimalSolutions);
        }
        
        [Theory]
        [InlineData(3, 1, 2, 2, 3, 1, 0, 1,new int[] { 2 })]
        [InlineData(4, 1, 2, 2, 3, 3, 4, 2, new int[] { 1, 3 })]
        public void FindOptimalStationSets_SimpleCases_ReturnsExpectedResults(
            int n, 
            int u1, int v1, 
            int u2, int v2, 
            int u3, int v3, 
            int expectedMinStationsCount, 
            int[] expectedOptimalSet)
        {
            var channels = new List<(int, int)>
            {
                (u1, v1)
            };

            if (u2 != 0 && v2 != 0)
            {
                channels.Add((u2, v2));
            }

            if (u3 != 0 && v3 != 0)
            {
                channels.Add((u3, v3));
            }
            
            var (minStationsCount, optimalSolutions) = ChannelService.FindOptimalStationSets(n, channels);
            
            Assert.Equal(expectedMinStationsCount, minStationsCount);
            Assert.Contains(new HashSet<int>(expectedOptimalSet), optimalSolutions);
        }
    }
}
