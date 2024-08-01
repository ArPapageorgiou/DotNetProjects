using Application.Interfaces;
using Application.Services;
using Domain.ApiRequestStatistic;
using Moq;

namespace AggregateApi_Tests
{
    [TestFixture]
    internal class RequestStatisticsServiceTests
    {
        [Test]
        public void GetRequestStatisticsService_ShouldReturnCorrectStatistics()
        {
            var mockRepository = new Mock<IRequestStatisticRepository>();

            var statistics = new List<RequestStatistic>
            {
                new RequestStatistic { ApiName = "Api1", ResponseTime = 70 },
                new RequestStatistic { ApiName = "Api1", ResponseTime = 120 },
                new RequestStatistic { ApiName = "Api2", ResponseTime = 110 },
                new RequestStatistic { ApiName = "Api2", ResponseTime = 200 },
                new RequestStatistic { ApiName = "Api3", ResponseTime = 140 },
                new RequestStatistic { ApiName = "Api3", ResponseTime = 80 },
                new RequestStatistic { ApiName = "Api3", ResponseTime = 190 }
            };

            mockRepository.Setup(repo => repo.GetStatistics()).Returns(statistics);

            var service = new RequestStatisticsService(mockRepository.Object);

            var result = service.GetRequestStatisticsService();

            var api1Stats = result.FirstOrDefault(r => r.ApiName == "Api1");
            Assert.IsNotNull(api1Stats);
            Assert.AreEqual(2, api1Stats.TotalRequests);
            Assert.AreEqual(1, api1Stats.FastRequests);
            Assert.AreEqual(1, api1Stats.AverageRequests);
            Assert.AreEqual(0, api1Stats.SlowRequests);
            Assert.AreEqual(70, api1Stats.FastAverageTime);
            Assert.AreEqual(120, api1Stats.AverageAverageTime);
            Assert.AreEqual(0, api1Stats.SlowAverageTime);

            var api2Stats = result.FirstOrDefault(r => r.ApiName == "Api2");
            Assert.IsNotNull(api2Stats);
            Assert.AreEqual(2, api2Stats.TotalRequests);
            Assert.AreEqual(0, api2Stats.FastRequests);
            Assert.AreEqual(1, api2Stats.AverageRequests);
            Assert.AreEqual(1, api2Stats.SlowRequests);
            Assert.AreEqual(0, api2Stats.FastAverageTime);
            Assert.AreEqual(110, api2Stats.AverageAverageTime);
            Assert.AreEqual(200, api2Stats.SlowAverageTime);

            var api3Stats = result.FirstOrDefault(r => r.ApiName == "Api3");
            Assert.IsNotNull(api3Stats);
            Assert.AreEqual(3, api3Stats.TotalRequests);
            Assert.AreEqual(1, api3Stats.FastRequests);
            Assert.AreEqual(2, api3Stats.AverageRequests);
            Assert.AreEqual(0, api3Stats.SlowRequests);
            Assert.AreEqual(80, api3Stats.FastAverageTime);
            Assert.AreEqual(165, api3Stats.AverageAverageTime);
            Assert.AreEqual(0, api3Stats.SlowAverageTime);
        }

    }
}
