using m4dragon.Models_Server;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace m4dragon.DAL_Server
{
    public class CryptoSqlDAO : ICryptoSqlDAO
    {        
        private string connectionString;
        string getDailySettings = "SELECT TOP 1 * FROM daily_settings WHERE day_of_year = @dayOfYear AND time_period <= @utcHour ORDER BY id DESC;";

        public CryptoSqlDAO(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public List<Crypto> SelectDailySettings(int dayOfYear, int hour)
        {
            List<Crypto> settings = new List<Crypto>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(getDailySettings, conn);
                    cmd.Parameters.AddWithValue("@dayOfYear", dayOfYear);
                    cmd.Parameters.AddWithValue("@utcHour", hour);

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Crypto daily = ConvertReaderToDailySettings(reader);
                        settings.Add(daily);
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("An error occured communicating with the database. ");
                Console.WriteLine(ex.Message);
                throw;
            }

            return settings;
        }

        private Crypto ConvertReaderToDailySettings(SqlDataReader reader)
        {
            Crypto daily = new Crypto();

            daily.ID = Convert.ToInt32(reader["id"]);
            daily.DayOfYear = Convert.ToInt32(reader["day_of_year"]);
            daily.TimePeriod = Convert.ToInt32(reader["time_period"]);
            daily.Rotors = Convert.ToString(reader["rotors"]);
            daily.Reflector = Convert.ToString(reader["reflectors"]);
            daily.BetaOrGamma = Convert.ToString(reader["beta_or_gamma"]);
            daily.StartingPosition = Convert.ToString(reader["start_position"]);
            daily.Offsets = Convert.ToString(reader["offset"]);
            daily.Plugs = Convert.ToString(reader["plugs"]);

            return daily;
        }
    }
}
