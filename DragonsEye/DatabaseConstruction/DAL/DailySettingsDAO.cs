using DatabaseConstruction.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseConstruction.DAL
{
    public class DailySettingsDAO : IDailySettingsDAO
    {
        // Connection String from Program.cs
        private string connectionString;

        // SQL Commands
        string getDailySettings = "Select * From daily_settings;";


        public DailySettingsDAO(string databaseConnectionString)
        {
            connectionString = databaseConnectionString;
        }

        public IList<DailySettings> GetDailySettings()
        {
            List<DailySettings> dailySettings = new List<DailySettings>();

            return dailySettings;
        }
    }
}
