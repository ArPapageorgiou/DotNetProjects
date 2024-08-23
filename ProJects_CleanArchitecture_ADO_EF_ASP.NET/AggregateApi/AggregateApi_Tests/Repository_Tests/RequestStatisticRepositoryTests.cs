using Infrastructure.Repositories;
using Domain.ApiRequestStatistic;

namespace AggregateApi_Tests.Repository_Tests
{
    [TestFixture]
    internal class RequestStatisticRepositoryTests
    {
        [Test]
        public void AddRequestStatistics_ShouldAddToStatistics()
        {
            var repository = new RequestStatisticRepository();

            var statistic1 = new RequestStatistic
            {
                ApiName = "SomeApi",
                ResponseTime = 10,
                Timestamp = DateTime.UtcNow
            };

            var statistic2 = new RequestStatistic
            {
                ApiName = "SomeOtherApi",
                ResponseTime = 200,
                Timestamp = DateTime.UtcNow
            };

            repository.AddRequestStatistics(statistic1);
            repository.AddRequestStatistics(statistic2);

            var statistics = repository.GetStatistics().ToList();

            Assert.AreEqual(2, statistics.Count);

            var addedStatistic1 = statistics.FirstOrDefault(stat => stat.ApiName == "SomeApi");
            var addedStatistic2 = statistics.FirstOrDefault(stat => stat.ApiName == "SomeOtherApi");

            Assert.IsNotNull(addedStatistic1);
            Assert.IsNotNull(addedStatistic2);

            Assert.AreEqual(statistic1.ResponseTime, addedStatistic1.ResponseTime);
            Assert.AreEqual(statistic2.ResponseTime, addedStatistic2.ResponseTime);

        }

    }
}
