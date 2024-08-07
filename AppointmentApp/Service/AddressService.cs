using AppointmentApp.Constant;
using AppointmentApp.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentApp.Service
{
    public class AddressService
    {
        private readonly UserService _userService;

        public AddressService(UserService userService)
        {
            _userService = userService;
        }
        public AddressModel GetAddress(int addressId)
        {
            throw new NotImplementedException();
        }

        public int CreateAddress(AddressCreateDTO address)
        {
           
            string query = $@"
                            INSERT INTO {TABLES.ADDRESS} 
                                ({ADDRESS.ADDRESS1}, {ADDRESS.ADDRESS2}, {ADDRESS.CITY_ID}, 
                                {ADDRESS.POSTAL_CODE}, {ADDRESS.PHONE}, {ADDRESS.CREATE_DATE}, 
                                {ADDRESS.CREATED_BY}, {ADDRESS.LAST_UPDATE}, {ADDRESS.LAST_UPDATE_BY})
                            VALUES
                                (@Address1, @Address2, @CityId, @PostalCode, @Phone, @CreateDate, @CreatedBy, @LastUpdate, @LastUpdateBy);
                            SELECT LAST_INSERT_ID();
                            " ;

            int addressId;
            try
            {
                
                using (MySqlCommand command = new MySqlCommand(query, DbConnection.Connection))
                {
                    command.Parameters.AddWithValue("@Address1", address.Address);
                    command.Parameters.AddWithValue("@Address2", address.Address2);
                    command.Parameters.AddWithValue("@CityId", address.CityId);
                    command.Parameters.AddWithValue("@PostalCode", address.PostalCode);
                    command.Parameters.AddWithValue("@Phone", address.Phone);
                    command.Parameters.AddWithValue("@CreateDate", DateTime.UtcNow);
                    command.Parameters.AddWithValue("@CreatedBy", _userService.Username);
                    command.Parameters.AddWithValue("@LastUpdate", DateTime.UtcNow);
                    command.Parameters.AddWithValue("@LastUpdateBy", _userService.Username);

                    addressId = Convert.ToInt32(command.ExecuteScalar());
                    return addressId;
                }

            }catch (MySqlException ex)
            {
                throw new Exception($"MySql Error: {ex.Message}", ex);
            }
        }

        public bool UpdateAddress(AddressUpdateDTO address) 
        { 
            string query=$@"
                            UPDATE {TABLES.ADDRESS}
                            SET
                                {ADDRESS.ADDRESS1} = @Address,
                                {ADDRESS.ADDRESS2} = @Address2,
                                {ADDRESS.CITY_ID} = @CityId,
                                {ADDRESS.POSTAL_CODE} = @PostalCode,
                                {ADDRESS.PHONE} = @Phone,
                                {ADDRESS.LAST_UPDATE} = @LastUpdate,
                                {ADDRESS.LAST_UPDATE_BY} = @LastUpdateBy
                            WHERE
                                {ADDRESS.ADDRESSS_ID} = @AddressId;
                            ";
            try
            {
                using (MySqlCommand command = new MySqlCommand(query, DbConnection.Connection))
                {
                    command.Parameters.AddWithValue("@Address", address.Address);
                    command.Parameters.AddWithValue("@Address2", address.Address2);
                    command.Parameters.AddWithValue("@CityId", address.CityId);
                    command.Parameters.AddWithValue("@PostalCode", address.PostalCode);
                    command.Parameters.AddWithValue("@Phone", address.Phone);
                    command.Parameters.AddWithValue("@LastUpdate", DateTime.UtcNow);
                    command.Parameters.AddWithValue("@LastUpdateBy", _userService.Username);
                    command.Parameters.AddWithValue("@AddressId", address.AddressId);

                    return command.ExecuteNonQuery() > 0;
                }
            }catch(MySqlException ex)
                {
                    throw new Exception("MySql Error", ex);
                }
            }
    }
}
