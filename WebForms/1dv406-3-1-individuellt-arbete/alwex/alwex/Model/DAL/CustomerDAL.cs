using alwex.Model.BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace alwex.Model.DAL
{
    public class CustomerDAL : DALBase
    {
        public Customer GetCustomersById(int customerID) // Hämtar enskild kund
        {

            using (var conn = CreateConnection())
            {
                try
                {
                    var cmd = new SqlCommand("dbo.usp_GetCustomerByID", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@CustomerID", SqlDbType.Int, 4).Value = customerID;

                    conn.Open();

                    using (var reader = cmd.ExecuteReader())
                    {
                        var customeridIndex = reader.GetOrdinal("CustomerID");
                        var customerNumIndex = reader.GetOrdinal("CustomerNUM");
                        var nameIndex = reader.GetOrdinal("Name");
                        var cityIndex = reader.GetOrdinal("City");
                        var postalCodeIndex = reader.GetOrdinal("PostalCode");
                        var phoneIndex = reader.GetOrdinal("Phone");

                        if (reader.Read())
                        {
                            return new Customer
                            {
                                CustomerID = reader.GetInt32(customeridIndex),
                                CustomerNUM = reader.GetInt32(customerNumIndex),
                                Name = reader.GetString(nameIndex),
                                City = reader.GetString(cityIndex),
                                PostalCode = reader.GetString(postalCodeIndex),
                                Phone = reader.GetString(phoneIndex),
                            };
                        }

                    }

                }
                catch
                {
                    throw new ArgumentException("Fel vid anslutning till databasen");
                }

                return null;
            }

        }
        public IEnumerable<Customer> GetCustomers() // Hämtar alla kunderna
        {
            var customers = new List<Customer>(100);

            using (var conn = CreateConnection())
            {
                try
                {
                    var cmd = new SqlCommand("dbo.usp_GetCustomers", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    conn.Open();

                    using (var reader = cmd.ExecuteReader())
                    {
                        var customeridIndex = reader.GetOrdinal("CustomerID");
                        var customerNumIndex = reader.GetOrdinal("CustomerNUM");
                        var nameIndex = reader.GetOrdinal("Name");
                        var cityIndex = reader.GetOrdinal("City");
                        var postalCodeIndex = reader.GetOrdinal("PostalCode");
                        var phoneIndex = reader.GetOrdinal("Phone");

                        while (reader.Read())
                        {
                            customers.Add(new Customer
                            {
                                CustomerID = reader.GetInt32(customeridIndex),
                                CustomerNUM = reader.GetInt32(customerNumIndex),
                                Name = reader.GetString(nameIndex),
                                City = reader.GetString(cityIndex),
                                PostalCode = reader.GetString(postalCodeIndex),
                                Phone = reader.GetString(phoneIndex),
                            });
                        }

                    }

                }
                catch
                {
                    throw new ArgumentException("Fel vid anslutning till databasen");
                }
            }
            customers.TrimExcess();
            return customers;
        }
        public void DeleteCustomer(int customerid) // Tabort en kund
        {
            using (var conn = CreateConnection())
            {
                try
                {
                    var cmd = new SqlCommand("dbo.usp_RemoveCustomer", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@CustomerID", SqlDbType.Int, 4).Value = customerid;

                    conn.Open();

                    cmd.ExecuteNonQuery();
                }
                catch
                {
                    throw new ArgumentException("Fel vid anslutning till databasen");
                }

            }
        }
        public void UpdateCustomer(Customer Customer) // Redigera en kund
        {
            using (var conn = CreateConnection())
            {
                try
                {
                    var cmd = new SqlCommand("dbo.usp_UpdateCustomer", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@CustomerID", SqlDbType.Int, 4).Value = Customer.CustomerID;
                    cmd.Parameters.Add("@CustomerNUM", SqlDbType.Int, 4).Value = Customer.CustomerNUM;
                    cmd.Parameters.Add("@Name", SqlDbType.VarChar, 25).Value = Customer.Name;
                    cmd.Parameters.Add("@City", SqlDbType.VarChar, 25).Value = Customer.City;
                    cmd.Parameters.Add("@PostalCode", SqlDbType.VarChar, 6).Value = Customer.PostalCode;
                    cmd.Parameters.Add("@Phone", SqlDbType.VarChar, 15).Value = Customer.Phone;

                    conn.Open();

                    cmd.ExecuteNonQuery();

                }
                catch
                {
                    throw new ArgumentException("Fel vid anslutning till databasen");
                }

            }
        }
        public void InsertCustomer(Customer customer) //Lägg till en kund
        {
            using (var conn = CreateConnection())
            {
                try
                {
                    var cmd = new SqlCommand("dbo.usp_AddCustomer", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@CustomerNUM", SqlDbType.Int, 4).Value = customer.CustomerNUM;
                    cmd.Parameters.Add("@Name", SqlDbType.VarChar, 25).Value = customer.Name;
                    cmd.Parameters.Add("@City", SqlDbType.VarChar, 25).Value = customer.City;
                    cmd.Parameters.Add("@PostalCode", SqlDbType.VarChar, 6).Value = customer.PostalCode;
                    cmd.Parameters.Add("@Phone", SqlDbType.VarChar, 15).Value = customer.Phone;

                    cmd.Parameters.Add("@CustomerID", SqlDbType.Int, 4).Direction = ParameterDirection.Output;

                    conn.Open();

                    cmd.ExecuteNonQuery();

                    customer.CustomerID = (int)cmd.Parameters["@CustomerID"].Value;
                }
                catch
                {
                    throw new ArgumentException("Fel vid anslutning till databasen");
                }

            }   
        }
    }
}