using Application.Interfaces;
using Domain.Models;
using Infrastructure.Data;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Data;
using Infrastructure.Constants;
using System.Data.SqlClient;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using static System.Runtime.InteropServices.JavaScript.JSType;

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

            using (var transaction = _appDbContext.Database.BeginTransaction())
            {
                try
                {
                    if (CountryCode != null && CityName != null)
                    {
                        using (_appDbContext.Database.BeginTransaction())
                        {
                            var data = await _appDbContext.Data
                            .Where(x => x.CityName == CityName && x.CountryCode == CountryCode)
                            .OrderByDescending(x => x.Datetime)
                            .FirstOrDefaultAsync();

                            var weatherData = await _appDbContext.WeatherData.Where(x => x.Id == data.WeatherDataForeignKey).FirstOrDefaultAsync();

                            return weatherData;
                        }
                    }
                    else
                    {
                        throw new ArgumentException();
                    }
                }
                catch (Exception)
                {
                    transaction.RollbackAsync();
                    throw;
                }
            }
        }

        public async Task SetWeatherDataAsync(WeatherData weatherData)
        {
            using (var transaction = await _appDbContext.Database.BeginTransactionAsync())
            {
                try
                {
                    using (SqlConnection connection = await GetConnectionAsync())
                    {
                        foreach (var data in weatherData.DataList)
                        {
                            using (SqlCommand cmd = new SqlCommand(StoredProcedures.SpInsertWeatherData, connection))
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

                                await cmd.ExecuteNonQueryAsync();
                            }
                        }

                        await transaction.CommitAsync();

                    }

                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
            }
                
        }

        //public void InsertNewBook(Books book)
        //{
        //    try
        //    {
        //        using (SqlConnection connection = GetSqlConnection())
        //        {
        //            SqlCommand cmd = new SqlCommand(Stored_Procedures.spInsertNewBook, connection);
        //            cmd.CommandType = CommandType.StoredProcedure;
        //            cmd.Parameters.AddWithValue("@Title", book.Title);
        //            cmd.Parameters.AddWithValue("@Genre", book.Genre);
        //            cmd.Parameters.AddWithValue("@Description", book.Description);
        //            cmd.Parameters.AddWithValue("@ISBN", book.ISBN);
        //            cmd.Parameters.AddWithValue("@TotalCopies", book.TotalCopies);
        //            cmd.Parameters.AddWithValue("@AvailableCopies", book.AvailableCopies);
        //            cmd.ExecuteNonQuery();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine($"An error has occurred: {ex.Message}");
        //    }
        //}
    }
}
