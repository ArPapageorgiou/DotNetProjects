using Application.Interfaces;
using Domain.WeatherBitApi_Models;
using Moq;
using Polly.CircuitBreaker;
using Moq.Protected;
using System.Net;
using System.Text.Json;
using Microsoft.Extensions.Configuration;
using Infrastructure.Repositories;

namespace AggregateApi_Tests
{
    [TestFixture]
    public class WeatherHttpClientTests
    {
        private IWeatherHttpClient _weatherHttpClient;
        private Mock<HttpMessageHandler> _httpMessageHnadlerMock;
        private HttpClient _httpClient;
        private IRequestStatisticRepository _requestStatistics;
        private IConfiguration _configuration;

        [SetUp]
        public void Setup()
        {
            //Mocking IConfiguration
            var configurationMock = new Mock<IConfiguration>();
            configurationMock.Setup(config => config["ApiSettings:WeatherBitUrl"]).Returns("https://api.weatherbit.io/v2.0/current");
            configurationMock.Setup(config => config["ApiSettings:WeatherBitApiKey"]).Returns("test_api_key");
            _configuration = configurationMock.Object;

            // Mocking IRequestStatisticsRepository
            var requestStatisticsRepository = new Mock<IRequestStatisticRepository>();
            _requestStatistics = requestStatisticsRepository.Object;

            // Mocking HttpMessageHandler
            _httpMessageHnadlerMock = new Mock<HttpMessageHandler>(MockBehavior.Strict);
            _httpMessageHnadlerMock.Protected()
                .Setup("Dispose", ItExpr.IsAny<bool>())
                .Verifiable();

            // Initialize HttpClient
            _httpClient = new HttpClient(_httpMessageHnadlerMock.Object);

            // Creating an instance of WeatherApiClient with mocks
            _weatherHttpClient = new WeatherHttpClient(_httpClient, _configuration, _requestStatistics);
        }

        [Test]
        public async Task GetWeatherAsync_ShouldReturnWeatherData_WhenApiCallIsSuccesful()
        {
            var expectedResponse = new WeatherData
            {
                Count = 1,
                DataList = new List<Data>
                {
                    new Data
                    {
                        WindCdir = "N",
                        Rh = 50.0f,
                        Pod = "d",
                        Lon = -122.4194,
                        Pres = 1013.0,
                        Timezone = "PST",
                        ObTime = "2023-07-05 12:00",
                        CountryCode = "US",
                        Clouds = 20.0f,
                        Vis = 10.0f,
                        WindSpd = 5.0,
                        Gust = 7.0,
                        WindCdirFull = "North",
                        AppTemp = 24.0,
                        StateCode = "CA",
                        Ts = 1657036800,
                        HAngle = 0.0f,
                        Dewpt = 10.0,
                        Weather = new Weather
                        {
                            Icon = "c01d",
                            Code = 800,
                            Description = "Clear sky"
                        },
                        Uv = 5.0f,
                        Aqi = 50.0f,
                        Station = "KSFO",
                        Sources = new List<string> { "KSFO", "E1234" },
                        WindDir = 0.0f,
                        ElevAngle = 45.0,
                        Datetime = "2023-07-05:12",
                        Precip = 0.0,
                        Ghi = 1000.0,
                        Dni = 800.0,
                        Dhi = 500.0,
                        SolarRad = 200.0,
                        CityName = "San Francisco",
                        Sunrise = "06:00",
                        Sunset = "20:00",
                        Temp = 25.0,
                        Lat = 37.7749,
                        Slp = 1013.0
                    }
                }
            };

            var jsonResponse = JsonSerializer.Serialize(expectedResponse, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });

            _httpMessageHnadlerMock.Protected()
                .Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>()
                )
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(jsonResponse)
                });

            var result = await _weatherHttpClient.GetWeatherAsync("GR", "Athens");

            Assert.IsNotNull(result);
            Assert.AreEqual(expectedResponse.Count, result.Count);
            Assert.AreEqual(expectedResponse.DataList.Count, result.DataList.Count);
            Assert.AreEqual(expectedResponse.DataList[0].CityName, result.DataList[0].CityName);
            Assert.AreEqual(expectedResponse.DataList[0].Weather.Description, result.DataList[0].Weather.Description);
            
        }

        [Test]
        public async Task GetWeatherAsync_ShouldThrowException_WhenCicuitBreakerIsOpen()
        {
            _httpMessageHnadlerMock.Protected()
                .Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>()
                )
                .ThrowsAsync(new BrokenCircuitException());

            var ex = Assert.ThrowsAsync<Exception>(async () => await _weatherHttpClient.GetWeatherAsync("GR", "Athens"));
            Assert.AreEqual("Circuit Breaker is open. Unable to fetch data from the Api", ex.Message);
        }

        [Test]
        public async Task GetWeatherAsync_ShouldThrowException_WhenCallFails()
        {
            _httpMessageHnadlerMock.Protected()
                .Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>()
                )
                .ThrowsAsync(new Exception());

            var ex = Assert.ThrowsAsync<Exception>(async () => await _weatherHttpClient.GetWeatherAsync("GR", "Athens"));
            Assert.AreEqual("An error occured while fetching data from the api", ex.Message);
        }

    }
}
