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
        private readonly UserService _userService;

        public CityService(UserService userService)
        {
            _userService = userService;
        }

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
                Messages.ShowError("SqlError", ex.Message);
            }

            
                return cities;
        }

        public CityReadDTO GetCityById(int cityId)
        {
            string query = $@"
                                SELECT 
                                    {CITY.CITY_ID} as CityId,
                                    {CITY.CITY_NAME} as CityName,
                                    {CITY.COUNTRY_ID} as CountryId
                                FROM {TABLES.CITY}
                                WHERE
                                    {CITY.CITY_ID} = @CityId
                            ";
            try
            {
                using (MySqlCommand command = new MySqlCommand(query, DbConnection.Connection))
                {
                    command.Parameters.AddWithValue("@CityId", cityId);
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            CityReadDTO city = new CityReadDTO
                            {
                                CityId = reader.GetInt32("CityId"),
                                CityName = reader.GetString("CityName"),
                                CountryId = reader.GetInt32("CountryId")
                            };
                            return city;
                        }
                        return null;
                    }
                }
            }
            catch (MySqlException ex)
            {
                Messages.ShowError("SqlError", ex.Message);
                return null;
            }
        }

        public CityReadDTO CreateCity(string cityName, int countryId)
        {
            string query = $@"
                                INSERT INTO {TABLES.CITY}
                                    ({CITY.CITY_NAME}, {CITY.COUNTRY_ID}, {CITY.CREATE_DATE}, {CITY.CREATED_BY}, {CITY.LAST_UPDATE}, {CITY.LAST_UPDATE_BY})
                                VALUES
                                    (@CityName, @CountryId, @CreateDate, @CreatedBy, @LastUpdate, @LastUpdateBy);
                                SELECT LAST_INSERT_ID();
                            ";
            CityReadDTO city;
            try
            {
                using (MySqlCommand command = new MySqlCommand(query, DbConnection.Connection))
                {
                    command.Parameters.AddWithValue("@CityName", cityName);
                    command.Parameters.AddWithValue("@CountryId", countryId);
                    command.Parameters.AddWithValue("@CreateDate", DateTime.UtcNow);
                    command.Parameters.AddWithValue("@CreatedBy", _userService.Username);
                    command.Parameters.AddWithValue("@LastUpdate", DateTime.UtcNow);
                    command.Parameters.AddWithValue("@LastUpdateBy", _userService.Username);

                   city = new CityReadDTO
                    {
                        CityId = Convert.ToInt32(command.ExecuteScalar()),
                        CityName = cityName,
                        CountryId = countryId
                    };

                    return city;
                }
            }
            catch (MySqlException ex)
            {
                
                Messages.ShowError("SqlError", ex.Message);
                return null;
            }
        }

        public bool UpdateCity(CityReadDTO city)
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
                    command.Parameters.AddWithValue("@CityName", city.CityName);
                    command.Parameters.AddWithValue("@CountryId", city.CountryId);
                    command.Parameters.AddWithValue("@LastUpdate", DateTime.UtcNow);
                    command.Parameters.AddWithValue("@LastUpdateBy", _userService.Username);
                    command.Parameters.AddWithValue("@CityId", city.CityId);

                    return command.ExecuteNonQuery() > 0;
                }

            }
            catch (MySqlException ex)
            {
                Messages.ShowError("SqlError", ex.Message);
                return false;
            }
        }
    }
}
