using AppointmentApp.Constant;
using AppointmentApp.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentApp.Service
{
    public class AddressService
    {
        public AddressModel GetAddress(int addressId)
        {
            throw new NotImplementedException();
        }

        public int CreateAddress(AddressModel address)
        {
            string query = $@"
                            INSERT INTO {TABLES.ADDRESS} 
                                ({ADDRESS.ADDRESS1}, {ADDRESS.ADDRESS2}, {ADDRESS.CITY_ID}, 
                                {ADDRESS.POSTAL_CODE}, {ADDRESS.PHONE},{ADDRESS.CREATE_DATE}, 
                                {ADDRESS.CREATED_BY}, {ADDRESS.LAST_UPDATE}, {ADDRESS.LAST_UPDATE_BY})
                            VALUES
                                (@Address1, @Address2, @CityId, @PostalCode, @Phone, @CreateDate, @CreatedBy, @LastUpdate, @LastUpdateBy);
                            ";
            try
            {
                using (MySqlCommand command = new MySqlCommand(query, DbConnection.Connection))
                {
                    command.Parameters.AddWithValue("@Address1", address.Address);
                    command.Parameters.AddWithValue("@Address2", address.Address2);
                    command.Parameters.AddWithValue("@CityId", address.CityId);
                    command.Parameters.AddWithValue("@PostalCode", address.PostalCode);
                    command.Parameters.AddWithValue("@Phone", address.Phone);
                    command.Parameters.AddWithValue("@CreateDate", address.CreateDate);
                    command.Parameters.AddWithValue("@CreatedBy", address.CreatedBy);
                    command.Parameters.AddWithValue("@LastUpdate", address.LastUpdate);
                    command.Parameters.AddWithValue("@LastUpdateBy", address.LastUpdateBy);

                    return Convert.ToInt32(command.ExecuteScalar());
                }

            }catch (MySqlException ex)
            {
                throw new Exception("MySql Error", ex);
            }
        }
    }
}
