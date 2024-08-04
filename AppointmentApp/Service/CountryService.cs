using AppointmentApp.Constant;
using AppointmentApp.Database;
using AppointmentApp.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentApp.Service
{
    public class CountryService
    {
        public List<CountryReadDTO> GetAllCountries()
        {
            List<CountryReadDTO> countries = new List<CountryReadDTO>();
            try
            {
                string query = $@"
                            SELECT 
                                {COUNTRY.COUNTRY_ID} AS CountryId,
                                {COUNTRY.COUNTRY_NAME} AS CountryName
                            FROM
                                {TABLES.COUNTRY}
                            ";

                using (MySqlCommand command = new MySqlCommand(query, DbConnection.Connection))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            CountryReadDTO country = new CountryReadDTO
                            {
                                CountryId = reader.GetInt32("CountryId"),
                                CountryName = reader.GetString("CountryName")
                            };
                            countries.Add(country);
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                throw new Exception($"MySql Error: {ex.Message}", ex);
            }
            
            return countries;
        }

}
}
