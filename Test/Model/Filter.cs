using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Test.Model;

namespace Test.Model
{
    public static class Filter
    {
        public static string connectionString = @"Data Source=DESKTOP-TGE0OME\SQLEXPRESS;Initial Catalog=TPost;Integrated Security=True";

        public static List<HistoryExport> historyExports = new List<HistoryExport>();
        public static void LoadDataFromDB()
        {
            HistoryExport history;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sqlExpression = "select id, [name], [dateTime], userName, cellName " +
                                       "from historyExports";

                connection.Open();

                SqlCommand command = new SqlCommand(sqlExpression, connection);

                try
                {
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            history = new HistoryExport(Convert.ToInt32(reader.GetValue(0))
                                                       , reader.GetValue(1).ToString()
                                                       , Convert.ToDateTime(reader.GetValue(2))
                                                       , reader.GetValue(3).ToString()
                                                       , reader.GetValue(4).ToString());

                            historyExports.Add(history);
                        }
                    }
                    else
                    {
                        MessageBox.Show("No data found", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    reader.Close();
                }
                catch
                {
                    MessageBox.Show("Неожиданная ошибка", "Critical Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
