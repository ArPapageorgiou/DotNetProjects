using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Application.Interfaces;
using Application.AppConstants;

namespace Application.Services
{
    internal class WeatherUpdateService : IHostedService, IDisposable
    {

        private readonly ILogger<WeatherUpdateService> _logger;
        private readonly IServiceProvider _serviceProvider;
        private Timer _timer;

        public WeatherUpdateService(ILogger<WeatherUpdateService> logger, IServiceProvider serviceProvider)
        {
            _logger = logger;
            _serviceProvider = serviceProvider;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Weather Update Service is strating");

            _timer = new Timer(UpdateWeather, null, TimeSpan.Zero, TimeSpan.FromMinutes(1));
            return Task.CompletedTask;
        }

        private async void UpdateWeather(object state)
        {
            await UpdateWeatherAsync(CancellationToken.None);
        }

        private async Task UpdateWeatherAsync(CancellationToken cancellationToken) 
        {
            _logger.LogInformation("WeatherUpdate is working");

            using (var scope = _serviceProvider.CreateScope())
            {
                var weatherService = scope.ServiceProvider.GetRequiredService<IWeatherDataService>();
                var cityNames = CityName.GetCityNames();
                var countryCode = CountryCode.Greece;
                

                foreach (var City in cityNames)
                {
                    try
                    {
                        _logger.LogInformation($"Updating weather for keyword: {City}");
                        var weatherResponse = await weatherService.GetWeatherAsync(countryCode, City, forceRefresh : true);
                    }
                    catch (Exception ex)
                    {

                        _logger.LogError(ex, $"Error updating weather for keyword {City}");
                    }
                }
            }
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Weather Update is stopping");
            _timer?.Change(Timeout.Infinite, 0);
            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _timer?.Dispose();
        }

    }
}
