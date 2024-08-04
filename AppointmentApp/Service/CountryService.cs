﻿using AppointmentApp.Constant;
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

        public int CreateCountry(string countryName) 
        {
            string query = $@"
                                INSERT INTO {TABLES.COUNTRY} 
                                    ({COUNTRY.COUNTRY_NAME}, {COUNTRY.CREATED_BY}, {COUNTRY.CREATE_DATE}, {COUNTRY.LAST_UPDATE}, {COUNTRY.LAST_UPDATE_BY})
                                VALUES
                                    (@CountryName, @CreatedBy, @CreateDate, @LastUpdate, @LastUpdateBy);
                                SELECT LAST_INSERT_ID();
                            ";
            try
            {
                using (MySqlCommand command = new MySqlCommand(query, DbConnection.Connection))
                {
                    command.Parameters.AddWithValue("@CountryName", countryName);
                    command.Parameters.AddWithValue("@CreateDate", DateTime.UtcNow);
                    command.Parameters.AddWithValue("@CreatedBy", "test");
                    command.Parameters.AddWithValue("@LastUpdate", DateTime.UtcNow);
                    command.Parameters.AddWithValue("@LastUpdateBy", "test");

                    return Convert.ToInt32(command.ExecuteScalar());

                    
                }
            }catch(MySqlException ex)
            {
                throw new Exception($"MySql Error: {ex.Message}", ex);
            }
           
        }

        public bool UpdateCountry(CountryModel country)
        {
            string query = $@"
                                UPDATE {TABLES.COUNTRY}
                                SET
                                    {COUNTRY.COUNTRY_NAME} = @CountryName,
                                    {COUNTRY.LAST_UPDATE} = @LastUpdate,
                                    {COUNTRY.LAST_UPDATE_BY} = @LastUpdateBy
                                WHERE
                                    {COUNTRY.COUNTRY_ID} = @CountryId
                            ";
            try
            {
                using (MySqlCommand command = new MySqlCommand(query, DbConnection.Connection))
                {
                    command.Parameters.AddWithValue("@CountryName", country.Country);
                    command.Parameters.AddWithValue("@LastUpdate", DateTime.UtcNow);
                    command.Parameters.AddWithValue("@LastUpdateBy", "test");
                    command.Parameters.AddWithValue("@CountryId", country.CountryId);

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