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
    }
}
