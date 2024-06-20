
﻿using Domain.Models;
using Infrastructure.Data;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;
using Infrastructure.Constants;
using Application.Interfaces;


namespace Infrastructure.Repositories
{
    public class WeatherDataRepository : BaseRepository, IWeatherDataRepository
    {
        private readonly AppDbContext _appDbContext;
        public WeatherDataRepository(DatabaseConfiguration databaseConfiguration, AppDbContext appDbContext) : base(databaseConfiguration)
        {
            _appDbContext = appDbContext;
        }

        public async Task<WeatherData> GetWeatherDataAsync(string CountryCode, string CityName)
        {

            if(CountryCode == null || CityName == null)
            {
                throw new ArgumentException("CountryCode and CityName cannot be null");
            }

            using (var transaction = await _appDbContext.Database.BeginTransactionAsync())
            {
                try
                {
                    var data = await _appDbContext.Data
                        .Where(x => x.CityName == CityName && x.CountryCode == CountryCode)
                        .OrderByDescending(x => x.Datetime)
                        .FirstOrDefaultAsync();

                    var weatherData = await _appDbContext.WeatherData
                        .Where(x => x.Id == data.WeatherDataForeignKey)
                        .FirstOrDefaultAsync();

                    await transaction.CommitAsync();

                        return weatherData;
                    
                }
                catch (Exception)
                {
                    await transaction.RollbackAsync();

                    throw;
                }
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
                            foreach (var data in weatherData.DataList)
                            {
                                using (SqlCommand cmd = new SqlCommand(StoredProcedures.SpInsertWeatherData, connection, (SqlTransaction)transaction))
                                {
                                    cmd.CommandType = CommandType.StoredProcedure;
                                    // Parameters for WeatherData table
                                    cmd.Parameters.AddWithValue("@Count", weatherData.Count);

                                    // Parameters for Weather table
                                    cmd.Parameters.AddWithValue("@Icon", data.Weather.Icon);
                                    cmd.Parameters.AddWithValue("@Code", data.Weather.Code);
                                    cmd.Parameters.AddWithValue("@Description", data.Weather.Description);

                                    // Parameters for Data table
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

                            await transaction.CommitAsync();

                        }
                        catch (Exception)
                        {
                            await transaction.RollbackAsync();
                            throw;
                        }
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }



        }
    }
}



