
using Domain.Models;
using Infrastructure.Data;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;
using Infrastructure.Constants;
using Application.Interfaces;
using Microsoft.Extensions.Logging;


namespace Infrastructure.Repositories
{
    public class WeatherDataRepository : BaseRepository, IWeatherDataRepository
    {
        private readonly AppDbContext _appDbContext;
        private readonly ILogger<WeatherDataRepository> _logger;
        public WeatherDataRepository(DatabaseConfiguration databaseConfiguration, AppDbContext appDbContext, ILogger<WeatherDataRepository> logger) : base(databaseConfiguration)
        {
            _appDbContext = appDbContext;
            _logger = logger;
        }

        public async Task<WeatherData> GetWeatherDataAsync(string CountryCode, string CityName)
        {

            try
            {
               var data = await _appDbContext.Data
                    .Include(d => d.WeatherData)
                    .Where(x => x.CityName == CityName && x.CountryCode == CountryCode)
                    .OrderByDescending(x => x.Datetime)
                    .FirstOrDefaultAsync();

               return data?.WeatherData;

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving weather data for {CountryCode} and {CityName}", CountryCode, CityName);
                throw new ApplicationException("Error retrieving weather data", ex);
            }


        }

        public async Task SetWeatherDataAsync(WeatherData weatherData)
        {
            try
            {
                using (SqlConnection connection = await GetConnectionAsync())
                {
                    using (var transaction = await connection.BeginTransactionAsync())
                    {
                        try
                        {
                            await InsertWeatherDataAsync(connection, (SqlTransaction)transaction, weatherData);
                            await transaction.CommitAsync();
                        }
                        catch (Exception ex)
                        {
                            await transaction.RollbackAsync();
                            _logger.LogError(ex, "An error occurred while setting weather data.");
                            throw new Exception("An error occurred while setting weather data.", ex);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while setting weather data.");
                throw new ApplicationException("An error occurred while setting weather data.", ex); ;
            }
        }

        private async Task InsertWeatherDataAsync(SqlConnection connection, SqlTransaction transaction, WeatherData weatherData)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand(StoredProcedures.SpInsertWeatherData, connection, transaction))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Count", weatherData.Count);

                    SqlParameter weatherDataOutParams = new SqlParameter
                    {
                        ParameterName = "@WeatherDataId",
                        SqlDbType = SqlDbType.Int,
                        Direction = ParameterDirection.Output
                    };

                    cmd.Parameters.Add(weatherDataOutParams);
                    await cmd.ExecuteNonQueryAsync();

                    int weatherDataId = (int)weatherDataOutParams.Value; 

                    foreach (var data in weatherData.DataList)
                    {
                        int weatherId = await InsertWeatherAsync(connection, transaction, data.Weather);
                        await InsertDataAsync(connection, transaction, data, weatherDataId, weatherId);
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while inserting weather data in WeatherData Table.");
                throw new ApplicationException("An error occurred while inserting weather data in WeatherData Table.", ex);
            }
        }

        private async Task<int> InsertWeatherAsync(SqlConnection connection, SqlTransaction transaction, Weather weather)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand(StoredProcedures.SpInsertWeather, connection, transaction))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Icon", weather.Icon);
                    cmd.Parameters.AddWithValue("@Code", weather.Code);
                    cmd.Parameters.AddWithValue("@Description", weather.Description);

                    SqlParameter weatherOutParams = new SqlParameter
                    {
                        ParameterName = "@WeatherId",
                        SqlDbType = SqlDbType.Int,
                        Direction = ParameterDirection.Output
                    };

                    cmd.Parameters.Add(weatherOutParams);
                    await cmd.ExecuteNonQueryAsync();

                    return (int)weatherOutParams.Value;


                }
            }
            catch (Exception ex)
            {       
                    _logger.LogError(ex, "An error occurred while inserting weather data in Weather Table");
                    throw new ApplicationException("An error occurred while inserting weather data in Weather Table.", ex);
            }
        }

        private async Task InsertDataAsync(SqlConnection connection, SqlTransaction transaction, Domain.Models.Data data, int weatherDataId, int weatherId)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand(StoredProcedures.SpInsertData, connection, transaction))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@WeatherDataId", weatherDataId);
                    cmd.Parameters.AddWithValue("@WeatherId", weatherId);
                    cmd.Parameters.AddWithValue("@WindCdir", data.WindCdir);
                    cmd.Parameters.AddWithValue("@Rh", data.Rh);
                    cmd.Parameters.AddWithValue("@Pod", data.Pod);
                    cmd.Parameters.AddWithValue("@Lon", data.Lon);
                    cmd.Parameters.AddWithValue("@Pres", data.Pres);
                    cmd.Parameters.AddWithValue("@Timezone", data.Timezone);
                    cmd.Parameters.AddWithValue("@ObTime", data.ObTime);
                    cmd.Parameters.AddWithValue("@CountryCode", data.CountryCode);
                    cmd.Parameters.AddWithValue("@Clouds", data.Clouds);
                    cmd.Parameters.AddWithValue("@Vis", data.Vis);
                    cmd.Parameters.AddWithValue("@WindSpd", data.WindSpd);
                    cmd.Parameters.AddWithValue("@Gust", data.Gust);
                    cmd.Parameters.AddWithValue("@WindCdirFull", data.WindCdirFull);
                    cmd.Parameters.AddWithValue("@AppTemp", data.AppTemp);
                    cmd.Parameters.AddWithValue("@StateCode", data.StateCode);
                    cmd.Parameters.AddWithValue("@Ts", data.Ts);
                    cmd.Parameters.AddWithValue("@HAngle", data.HAngle);
                    cmd.Parameters.AddWithValue("@Dewpt", data.Dewpt);
                    cmd.Parameters.AddWithValue("@Uv", data.Uv);
                    cmd.Parameters.AddWithValue("@Aqi", data.Aqi);
                    cmd.Parameters.AddWithValue("@Station", data.Station);
                    cmd.Parameters.AddWithValue("@WindDir", data.WindDir);
                    cmd.Parameters.AddWithValue("@ElevAngle", data.ElevAngle);
                    cmd.Parameters.AddWithValue("@Datetime", data.Datetime);
                    cmd.Parameters.AddWithValue("@Precip", data.Precip);
                    cmd.Parameters.AddWithValue("@Ghi", data.Ghi);
                    cmd.Parameters.AddWithValue("@Dni", data.Dni);
                    cmd.Parameters.AddWithValue("@Dhi", data.Dhi);
                    cmd.Parameters.AddWithValue("@SolarRad", data.SolarRad);
                    cmd.Parameters.AddWithValue("@CityName", data.CityName);
                    cmd.Parameters.AddWithValue("@Sunrise", data.Sunrise);
                    cmd.Parameters.AddWithValue("@Sunset", data.Sunset);
                    cmd.Parameters.AddWithValue("@Temp", data.Temp);
                    cmd.Parameters.AddWithValue("@Lat", data.Lat);
                    cmd.Parameters.AddWithValue("@Slp", data.Slp);

                    var sourceString = data.Sources != null ? string.Join(",", data.Sources) : string.Empty;
                    cmd.Parameters.AddWithValue("@Sources", sourceString);

                    await cmd.ExecuteNonQueryAsync();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while inserting weather data in Data Table.");
                throw new ApplicationException("An error occurred while inserting weather data in Data Table.", ex);
            }
        }

    }
}



