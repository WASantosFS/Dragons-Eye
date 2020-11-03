using DatabaseConstruction.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace DatabaseConstruction.DAL
{
    public class DailySettingsDAO : IDailySettingsDAO
    {
        // Connection String from Program.cs
        private string connectionString;

        // SQL Commands
        string getDailySettings = "Select id, day_of_year, time_period, rotors, reflectors, beta_or_gamma, start_position, offset, plugs From daily_settings;";
        string getDailySettingsById = "Select id, day_of_year, time_period, rotors, reflectors, beta_or_gamma, start_position, offset, plugs From daily_settings Where id = @id;";
        string insertIntoDailySettings = "Insert Into daily_settings (day_of_year, time_period, rotors, reflectors, beta_or_gamma, offset, plugs, start_position) Values(@dayofyear, @timeperiod, @rotors, @reflectors, @betaorgamma, @offsets, @plugs, @startposition);";

        public DailySettingsDAO(string databaseConnectionString)
        {
            connectionString = databaseConnectionString;
        }

        public IList<DailySettings> GetDailySettings()
        {
            List<DailySettings> dailySettings = new List<DailySettings>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(getDailySettings, conn);

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        DailySettings daily = ConvertReaderToDailySettings(reader);
                        dailySettings.Add(daily);
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("An error occured communicating with the database. ");
                Console.WriteLine(ex.Message);
                throw;
            }

            return dailySettings;
        }

        private DailySettings ConvertReaderToDailySettings(SqlDataReader reader)
        {
            DailySettings daily = new DailySettings();

            daily.DayOfYear = Convert.ToInt32(reader["day_of_year"]);
            daily.TimePeriod = Convert.ToInt32(reader["time_period"]);
            daily.Rotors = Convert.ToString(reader["rotors"]);
            daily.Reflector = Convert.ToString(reader["reflectors"]);
            daily.BetaOrGamma = Convert.ToString(reader["beta_or_gamma"]);
            daily.StartingPositions = Convert.ToString(reader["start_position"]);
            daily.Offsets = Convert.ToString(reader["offset"]);
            daily.Plugs = Convert.ToString(reader["plugs"]);

            return daily;
        }

        public IList<DailySettings> SelectDailySettings(int id)
        {
            List<DailySettings> settings = new List<DailySettings>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(getDailySettingsById, conn);
                    cmd.Parameters.AddWithValue("@id", id);

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        DailySettings daily = ConvertReaderToDailySettings(reader);
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

        public void AddDailySettings(DailySettings dailySettings)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(insertIntoDailySettings, conn);
                    cmd.Parameters.AddWithValue("@dayofyear", dailySettings.DayOfYear);
                    cmd.Parameters.AddWithValue("@timeperiod", dailySettings.TimePeriod);
                    cmd.Parameters.AddWithValue("@rotors", dailySettings.Rotors);
                    cmd.Parameters.AddWithValue("@reflectors", dailySettings.Reflector);
                    cmd.Parameters.AddWithValue("@betaorgamma", dailySettings.BetaOrGamma);
                    cmd.Parameters.AddWithValue("@offsets", dailySettings.Offsets);
                    cmd.Parameters.AddWithValue("@plugs", dailySettings.Plugs);
                    cmd.Parameters.AddWithValue("@startposition", dailySettings.StartingPositions);

                    cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("An error occured communicating with the database. ");
                Console.WriteLine(ex.Message);
                throw;
            }
        }
    }
}
