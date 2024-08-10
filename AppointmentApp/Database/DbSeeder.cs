using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppointmentApp.Database
{
    internal class DbSeeder
    {
        public static void ResetAndSeedDatabase()
        {
            try
            {
                // Wipe the database
                MySqlCommand dropDatabase = new MySqlCommand("DROP DATABASE IF EXISTS client_schedule", DbConnection.Connection);
                dropDatabase.ExecuteNonQuery();

                // Create the database
                MySqlCommand createDatabase = new MySqlCommand("CREATE DATABASE client_schedule", DbConnection.Connection);
                createDatabase.ExecuteNonQuery();

                // create the tables
                MySqlCommand createTables = new MySqlCommand(SeedTablesQuery(), DbConnection.Connection);
                createTables.ExecuteNonQuery();

                // Seed the database
                MySqlCommand seedDatabase = new MySqlCommand(SeedDataQuery(), DbConnection.Connection);
                seedDatabase.ExecuteNonQuery();

                Messages.ShowInfo("Database Seeder","Database reset and seeded successfully!");
            }
            catch (Exception ex)
            {
               Messages.ShowError("Database Seeder",ex.Message);
            }


        }

        public static void ResetDatabaseTables()
        {
            try
            {
                // Wipe the database
                MySqlCommand dropDatabase = new MySqlCommand("DROP DATABASE IF EXISTS client_schedule", DbConnection.Connection);
                dropDatabase.ExecuteNonQuery();

                // Create the database
                MySqlCommand createDatabase = new MySqlCommand("CREATE DATABASE client_schedule", DbConnection.Connection);
                createDatabase.ExecuteNonQuery();

                // create the tables
                MySqlCommand createTables = new MySqlCommand(SeedTablesQuery(), DbConnection.Connection);
                createTables.ExecuteNonQuery();

                Messages.ShowInfo("Database Seeder", "Database reset with tables successfully!");
            }catch(Exception ex) 
            {                     
                Messages.ShowError("Database Seeder", ex.Message);
            }

        }

        private static string SeedTablesQuery() {

            string selectDatabase = "USE client_schedule;";
            string createCountryTable = @"create table country
                                            (
                                                countryId    int auto_increment,
                                                country      varchar(50) not null,
                                                createDate   DATETIME    not null,
                                                createdBy    VARCHAR(40) not null,
                                                lastUpdate   TIMESTAMP   not null,
                                                lastUpdateBy VARCHAR(40) not null,
                                                constraint country_pk
                                                    primary key (countryId)
                                            );";

            string createCityTable = @"create table city
                                            (
                                                cityId       int auto_increment,
                                                city         varchar(50) not null,
                                                countryId    int         not null,
                                                createDate   DATETIME    not null,
                                                createdBy    VARCHAR(40) not null,
                                                lastUpdate   TIMESTAMP   not null,
                                                lastUpdateBy VARCHAR(40) not null,
                                                constraint city_pk
                                                    primary key (cityId)

                                            );";

            string createAddressTable = @"create table address
                                            (
                                                addressId    int auto_increment,
                                                address      varchar(50) not null,
                                                address2     varchar(50) not null,
                                                cityId       int         not null,
                                                postalCode   varchar(10) not null,
                                                phone        varchar(20) not null,
                                                createDate   DATETIME    not null,
                                                createdBy    VARCHAR(40) not null,
                                                lastUpdate   TIMESTAMP   not null,
                                                lastUpdateBy VARCHAR(40) not null,
                                                constraint address_pk
                                                    primary key (addressId)

                                            );";

            string createCustomerTable = @"create table customer
                                            (
                                                customerId   int auto_increment,
                                                customerName varchar(45) not null,
                                                addressId    int         not null,
                                                active       tinyint(1)  not null,
                                                createDate   DATETIME    not null,
                                                createdBy    VARCHAR(40) not null,
                                                lastUpdate   TIMESTAMP   not null,
                                                lastUpdateBy VARCHAR(40) not null,
                                                constraint customer_pk
                                                    primary key (customerId)

                                            );";

            string createUserTable = @"create table user(
                                        userId INT auto_increment,
                                        userName VARCHAR(50)     not null,
                                        password VARCHAR(50)     not null,
                                        active TINYINT(1)        not null,
                                        createDate   DATETIME    not null,
                                        createdBy    VARCHAR(40) not null,
                                        lastUpdate   TIMESTAMP   not null,
                                        lastUpdateBy VARCHAR(40) not null,
                                        constraint user_pk
                                                primary key (userId)
                                       
                                            );";

            string createAppointmentTable = @"create table appointment(
                                               appointmentId int auto_increment,
                                               customerId int           not null,
                                               userId int               not null,
                                               title varchar(255)       not null,
                                               description text         not null,
                                               location text            not null,
                                               contact text             not null,
                                               type text                not null,
                                               url VARCHAR(255)         not null,
                                               start DATETIME           not null,
                                               end DATETIME             not null,
                                               createDate   DATETIME    not null,
                                               createdBy    VARCHAR(40) not null,
                                               lastUpdate   TIMESTAMP   not null,
                                               lastUpdateBy VARCHAR(40) not null,
                                                  constraint appointment_pk
                                                    primary key (appointmentId)
                                               
                                                    );";
            string addConstraints = @"ALTER TABLE city
                                ADD CONSTRAINT city_country_countryId_fk
                                    FOREIGN KEY (countryId) REFERENCES country (countryId);

                            ALTER TABLE address
                                ADD CONSTRAINT address_city_cityId_fk
                                    FOREIGN KEY (cityId) REFERENCES city (cityId);

                            ALTER TABLE customer
                                ADD CONSTRAINT customer_address_addressId_fk
                                    FOREIGN KEY (addressId) REFERENCES address (addressId);

                            ALTER TABLE appointment
                                ADD CONSTRAINT appointment_customer_customerId_fk
                                    FOREIGN KEY (customerId) REFERENCES customer (customerId),
                                ADD CONSTRAINT appointment_user_userId_fk
                                    FOREIGN KEY (userId) REFERENCES user (userId);";

            return ($"{selectDatabase} {createCountryTable} {createCityTable} {createAddressTable} {createCustomerTable} {createUserTable} {createAppointmentTable} {addConstraints}");
        }

        private static string SeedDataQuery() {

            string seedUser = @"
                                 INSERT INTO `user` VALUES 
                                (1,'test','test',1,'2019-01-01 00:00:00','test','2019-01-01 00:00:00','test');
                            ";

            string seedCustomer = @"
                                     INSERT INTO `customer` VALUES 
                                    (1,'John Doe',1,1,'2019-01-01 00:00:00','test','2019-01-01 00:00:00','test'),
                                    (2,'Alfred E Newman',2,1,'2019-01-01 00:00:00','test','2019-01-01 00:00:00','test'),
                                    (3,'Ina Prufung',3,1,'2019-01-01 00:00:00','test','2019-01-01 00:00:00','test');
                                ";

            string seedCountry = @" 
                                    INSERT INTO `country` VALUES 
                                    (1,'US','2019-01-01 00:00:00','test','2019-01-01 00:00:00','test'),
                                    (2,'Canada','2019-01-01 00:00:00','test','2019-01-01 00:00:00','test'),
                                    (3,'Norway','2019-01-01 00:00:00','test','2019-01-01 00:00:00','test');
                                ";

            string seedCity = @"
                                INSERT INTO `city` VALUES 
                                (1,'New York',1,'2019-01-01 00:00:00','test','2019-01-01 00:00:00','test'),
                                (2,'Los Angeles',1,'2019-01-01 00:00:00','test','2019-01-01 00:00:00','test'),
                                (3,'Toronto',2,'2019-01-01 00:00:00','test','2019-01-01 00:00:00','test'),
                                (4,'Vancouver',2,'2019-01-01 00:00:00','test','2019-01-01 00:00:00','test'),
                                (5,'Oslo',3,'2019-01-01 00:00:00','test','2019-01-01 00:00:00','test');                          
                            ";

            string seedAddress = @"
                                INSERT INTO `address` VALUES 
                                (1,'123 Main','',1,'11111','555-1212','2019-01-01 00:00:00','test','2019-01-01 00:00:00','test'),
                                (2,'123 Elm','',3,'11112','555-1213','2019-01-01 00:00:00','test','2019-01-01 00:00:00','test'),
                                (3,'123 Oak','',5,'11113','555-1214','2019-01-01 00:00:00','test','2019-01-01 00:00:00','test');
                            ";

            string seedAppointment = @"
                                             INSERT INTO `appointment` VALUES 
                                            (1,1,1,'not needed','not needed','not needed','not needed','Presentation','not needed','2019-01-01 00:00:00','2019-01-01 00:00:00','2019-01-01 00:00:00','test','2019-01-01 00:00:00','test'),
                                            (2,2,1,'not needed','not needed','not needed','not needed','Scrum','not needed','2019-01-01 00:00:00','2019-01-01 00:00:00','2019-01-01 00:00:00','test','2019-01-01 00:00:00','test');
                                    ";

            return $"{seedCountry} {seedCity} {seedAddress} {seedCustomer} {seedUser} {seedAppointment}";
        }
    }
}
