using alwex.Model.BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace alwex.Model.DAL
{
    public class PalletStatementDAL : DALBase
    {
        public PalletStatement GetPalletById(int PsID) // Hämtar enskild pallstansning
        {

            using (var conn = CreateConnection())
            {
                try
                {
                    var cmd = new SqlCommand("dbo.usp_GetPalletByID", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@PsID", SqlDbType.Int, 4).Value = PsID;

                    conn.Open();

                    using (var reader = cmd.ExecuteReader())
                    {
                        var psidIndex = reader.GetOrdinal("PsID");
                        var customerNUMIndex = reader.GetOrdinal("CustomerNUM");
                        var outDateIndex = reader.GetOrdinal("OutDate");
                        var inDateIndex = reader.GetOrdinal("InDate");
                        var apalletIndex = reader.GetOrdinal("Apallet");
                        var bpalletIndex = reader.GetOrdinal("Bpallet");
                        var apalletOUTIndex = reader.GetOrdinal("ApalletOUT");

                        if (reader.Read())
                        {
                            return new PalletStatement
                            {
                                PsID = reader.GetInt32(psidIndex),
                                CustomerNUM = reader.GetInt32(customerNUMIndex),
                                OutDate = reader.GetDateTime(outDateIndex),
                                InDate = reader.GetDateTime(inDateIndex),
                                Apallet = reader.GetInt32(apalletIndex),
                                Bpallet = reader.GetInt32(bpalletIndex),
                                ApalletOUT = reader.GetInt32(apalletOUTIndex),
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
        public IEnumerable<PalletStatement> GetPalletStatements(int maximumRows, int startRowIndex, out int totalRowCount) // Hämtar alla pallstansningar
        {
            var palletstatements = new List<PalletStatement>(100);

            using (var conn = CreateConnection())
            {
                try
                {
                    var cmd = new SqlCommand("dbo.usp_GetPallets", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@PageNumber", SqlDbType.Int, 4).Value = startRowIndex / maximumRows + 1;
                    cmd.Parameters.Add("@PageSize", SqlDbType.Int, 4).Value = maximumRows;
                    cmd.Parameters.Add("@Records", SqlDbType.Int, 4).Direction = ParameterDirection.Output;

                    conn.Open();

                    using (var reader = cmd.ExecuteReader())
                    {
                        var psidIndex = reader.GetOrdinal("PsID");
                        var customerNUMIndex = reader.GetOrdinal("CustomerNUM");
                        var outDateIndex = reader.GetOrdinal("OutDate");
                        var inDateIndex = reader.GetOrdinal("InDate");
                        var apalletIndex = reader.GetOrdinal("Apallet");
                        var bpalletIndex = reader.GetOrdinal("Bpallet");
                        var apalletOUTIndex = reader.GetOrdinal("ApalletOUT");

                        while (reader.Read())
                        {
                            palletstatements.Add(new PalletStatement
                            {
                                PsID = reader.GetInt32(psidIndex),
                                CustomerNUM = reader.GetInt32(customerNUMIndex),
                                OutDate = reader.GetDateTime(outDateIndex),
                                InDate = reader.GetDateTime(inDateIndex),
                                Apallet = reader.GetInt32(apalletIndex),
                                Bpallet = reader.GetInt32(bpalletIndex),
                                ApalletOUT = reader.GetInt32(apalletOUTIndex),
                            });
                        }

                    }
                    totalRowCount = (int)cmd.Parameters["@Records"].Value;

                }
                catch
                {
                    throw new ArgumentException("Fel vid anslutning till databasen");
                }
            }
            palletstatements.TrimExcess();
            return palletstatements;
        }
        public void DeletePalletStatement(int PsID) // Tabort en pallstansning
        {
            using (var conn = CreateConnection())
            {
                try
                {
                    var cmd = new SqlCommand("dbo.usp_RemovePalletStatement", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@PsID", SqlDbType.Int, 4).Value = PsID;

                    conn.Open();

                    cmd.ExecuteNonQuery();
                }
                catch
                {
                    throw new ArgumentException("Fel vid anslutning till databasen");
                }

            }
        }
        public void UpdatePalletStatement(PalletStatement palletStatement) // Redigera en pallstansning
        {
            using (var conn = CreateConnection())
            {
                try
                {
                    var cmd = new SqlCommand("dbo.usp_UpdatePalletStatement", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@PsID", SqlDbType.Int, 4).Value = palletStatement.PsID;
                    cmd.Parameters.Add("@CustomerNUM", SqlDbType.Int, 4).Value = palletStatement.CustomerNUM;
                    cmd.Parameters.Add("@OutDate", SqlDbType.DateTime).Value = palletStatement.OutDate;
                    cmd.Parameters.Add("@InDate", SqlDbType.DateTime).Value = palletStatement.InDate;
                    cmd.Parameters.Add("@Apallet", SqlDbType.Int, 4).Value = palletStatement.Apallet;
                    cmd.Parameters.Add("@Bpallet", SqlDbType.Int, 4).Value = palletStatement.Bpallet;
                    cmd.Parameters.Add("@ApalletOUT", SqlDbType.Int, 4).Value = palletStatement.ApalletOUT;

                    conn.Open();

                    cmd.ExecuteNonQuery();

                }
                catch
                {
                    throw new ArgumentException("Fel vid anslutning till databasen");
                }

            }
        }
        public void InsertPalletStatement(PalletStatement palletStatement) //Lägg till en pallstansning
        {
            using (var conn = CreateConnection())
            {
                try
                {
                    var cmd = new SqlCommand("dbo.usp_AddPalletStatement", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@CustomerNUM", SqlDbType.Int, 4).Value = palletStatement.CustomerNUM;
                    cmd.Parameters.Add("@OutDate", SqlDbType.DateTime).Value = palletStatement.OutDate;
                    cmd.Parameters.Add("@InDate", SqlDbType.DateTime).Value = palletStatement.InDate;
                    cmd.Parameters.Add("@Apallet", SqlDbType.Int, 4).Value = palletStatement.Apallet;
                    cmd.Parameters.Add("@Bpallet", SqlDbType.Int, 4).Value = palletStatement.Bpallet;
                    cmd.Parameters.Add("@ApalletOUT", SqlDbType.Int, 4).Value = palletStatement.ApalletOUT;

                    cmd.Parameters.Add("@PsID", SqlDbType.Int, 4).Direction = ParameterDirection.Output;

                    conn.Open();

                    cmd.ExecuteNonQuery();

                    palletStatement.PsID = (int)cmd.Parameters["@PsID"].Value;
                }
                catch
                {
                    throw new ArgumentException("Fel vid anslutning till databasen");
                }

            }
        }
    }
}