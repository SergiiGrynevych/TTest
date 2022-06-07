using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Test.Model
{
    public static class Filter
    {
        public static string connectionString = @"Data Source=DESKTOP-TGE0OME\SQLEXPRESS;Initial Catalog=TTest;Integrated Security=True";

        public static List<HistoryExport> historyExports = new List<HistoryExport>();
        public static void LoadDataFromDB()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sqlExpression = "select id, [name], [dateTime], userName, cellName " +
                                       "from historyExports";

                Connection(connection, sqlExpression);
            }
        }
        public static void GetDataFromDBByFilter(string name, string dataFrom, string dataTo)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sqlExpression = "select id, [name], [dateTime], userName, cellName " +
                    "from historyExports " +
                   $"where name = '{name}' " +
                   $"and [dateTime] between CONVERT(datetime, '{dataFrom}', 103)  and  CONVERT(datetime, '{dataTo}', 103)";

                Connection(connection, sqlExpression);
            }
        }

        private static void Connection(SqlConnection connection, string sqlExpression)
        {
            connection.Open();

            SqlCommand command = new SqlCommand(sqlExpression, connection);

            try
            {
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        HistoryExport history = new HistoryExport(Convert.ToInt32(reader.GetValue(0))
                                                   , reader.GetValue(1).ToString()
                                                   , Convert.ToDateTime(reader.GetValue(2))
                                                   , reader.GetValue(3).ToString()
                                                   , reader.GetValue(4).ToString());

                        historyExports.Add(history);
                    }
                }
                else
                {
                    MessageBox.Show("No data found", "Attention!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                reader.Close();
            }
            catch
            {
                MessageBox.Show("Unexpected error", "Critical Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
