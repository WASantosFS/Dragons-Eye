﻿using DatabaseConstruction.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseConstruction.DAL
{
    public interface IDailySettingsDAO
    {
        public IList<DailySettings> GetDailySettings();

        public IList<DailySettings> SelectDailySettings(int id);

        public void AddDailySettings(DailySettings dailySettings);
    }
}
