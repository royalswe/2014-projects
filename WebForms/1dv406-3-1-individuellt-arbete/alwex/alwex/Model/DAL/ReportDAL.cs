using alwex.Model.BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace alwex.Model.DAL
{
    public class ReportDAL : DALBase
    {
        public IEnumerable<Report> GetReports(int maximumRows, int startRowIndex, out int totalRowCount) // Hämtar alla rapporter
        {
            var reports = new List<Report>(100);

            using (var conn = CreateConnection())
            {
                try
                {
                    var cmd = new SqlCommand("dbo.usp_GetReports", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@PageNumber", SqlDbType.Int, 4).Value = startRowIndex / maximumRows + 1;
                    cmd.Parameters.Add("@PageSize", SqlDbType.Int, 4).Value = maximumRows;
                    cmd.Parameters.Add("@Records", SqlDbType.Int, 4).Direction = ParameterDirection.Output;

                    conn.Open();

                    using (var reader = cmd.ExecuteReader())
                    {
                        var reportidIndex = reader.GetOrdinal("ReportID");
                        var psidIndex = reader.GetOrdinal("PsID");
                        var customerNUMIndex = reader.GetOrdinal("CustomerNUM");
                        var nameIndex = reader.GetOrdinal("Name");
                        var customerDebtIndex = reader.GetOrdinal("CustomerDebt");

                        while (reader.Read())
                        {
                            reports.Add(new Report
                            {
                                ReportID = reader.GetInt32(reportidIndex),
                                PsID = reader.GetInt32(psidIndex),
                                CustomerNUM = reader.GetInt32(customerNUMIndex),
                                Name = reader.GetString(nameIndex),                            
                                CustomerDebt = reader.GetInt32(customerDebtIndex),
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
            reports.TrimExcess();
            return reports;
        }
    }
}