using AppointmentApp.Model;
using AppointmentApp.Database;
using AppointmentApp.Constant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace AppointmentApp.Service
{
    public class CityService
    {
        public List<CityReadDTO> GetAllCities() 
        {
            List<CityReadDTO> cities = new List<CityReadDTO>();

            string query = $@"
                                SELECT 
                                    {CITY.CITY_ID} as CityId,
                                    {CITY.CITY_NAME} CityName,
                                    {CITY.COUNTRY_ID} as CountryId
                                FROM {TABLES.CITY}
                            ";
            try
            {
                using (MySqlCommand command = new MySqlCommand(query, DbConnection.Connection))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            CityReadDTO city = new CityReadDTO
                            {
                                CityId = reader.GetInt32("CityId"),
                                CityName = reader.GetString("CityName"),
                                CountryId = reader.GetInt32("CountryId")
                            };
                            cities.Add(city);
                        }
                    }
                }
            }catch (MySqlException ex)
            {
                throw new Exception("MySql Error", ex);
            }

            
                return cities;
        }

        public int CreateCity(string cityName, int countryId)
        {
            string query = $@"
                                INSERT INTO {TABLES.CITY}
                                    ({CITY.CITY_NAME}, {CITY.COUNTRY_ID}, {CITY.CREATE_DATE}, {CITY.CREATED_BY}, {CITY.LAST_UPDATE}, {CITY.LAST_UPDATE_BY})
                                VALUES
                                    (@CityName, @CountryId, @CreateDate, @CreatedBy, @LastUpdate, @LastUpdateBy);
                                SELECT LAST_INSERT_ID();
                            ";
            try
            {
                using (MySqlCommand command = new MySqlCommand(query, DbConnection.Connection))
                {
                    command.Parameters.AddWithValue("@CityName", cityName);
                    command.Parameters.AddWithValue("@CountryId", countryId);
                    command.Parameters.AddWithValue("@CreateDate", DateTime.UtcNow);
                    command.Parameters.AddWithValue("@CreatedBy", "tes");
                    command.Parameters.AddWithValue("@LastUpdate", DateTime.UtcNow);
                    command.Parameters.AddWithValue("@LastUpdateBy", "test");

                    return Convert.ToInt32(command.ExecuteScalar());
                }
            }
            catch (MySqlException ex)
            {
                throw new Exception("MySql Error", ex);
            }
        }

        public bool UpdateCity(int cityId, string cityName, int countryId)
        {
            string query = $@"
                                UPDATE {TABLES.CITY}
                                SET
                                    {CITY.CITY_NAME} = @CityName,
                                    {CITY.COUNTRY_ID} = @CountryId,
                                    {CITY.LAST_UPDATE} = @LastUpdate,
                                    {CITY.LAST_UPDATE_BY} = @LastUpdateBy
                                WHERE
                                    {CITY.CITY_ID} = @CityId
                            ";
            try
            {
                using (MySqlCommand command = new MySqlCommand(query, DbConnection.Connection))
                {
                    command.Parameters.AddWithValue("@CityName", cityName);
                    command.Parameters.AddWithValue("@CountryId", countryId);
                    command.Parameters.AddWithValue("@LastUpdate", DateTime.UtcNow);
                    command.Parameters.AddWithValue("@LastUpdateBy", "test");
                    command.Parameters.AddWithValue("@CityId", cityId);

                    return command.ExecuteNonQuery() > 0;
                }

            }
            catch (MySqlException ex)
            {
                throw new Exception($"MySql Error: {ex.Message}", ex);
            }
        }
    }
}
