using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using DatabaseConstruction.DAL;
using DatabaseConstruction.Models;
using DatabaseConstruction;

namespace DatabaseConstructionTests
{
    [TestClass]
    public class DailySettingsDAOTests : ParentTest
    {
        [TestMethod]
        public void GetDailySettingsShouldReturnListCountSix()
        {
            // arrage
            DailySettingsDAO dao = new DailySettingsDAO(databaseConnectionString);
            IList<DailySettings> settings = dao.GetDailySettings();

            // act
            int result = settings.Count;

            // assert
            Assert.AreEqual(6, result);
        }
        
        [TestMethod]
        [DataRow(1)]
        [DataRow(3)]
        [DataRow(5)]
        public void SelectDailySettingsShouldReturnOne(int id)
        {
            // arrage
            DailySettingsDAO dao = new DailySettingsDAO(databaseConnectionString);
            IList<DailySettings> settings = dao.SelectDailySettings(id);

            // act
            int result = settings.Count;

            // assert
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void AddDailySettingsShouldInsert()
        {
            // arrage
            DailySettings daily = new DailySettings();
            daily.DayOfYear = 3;
            daily.TimePeriod = 0;
            daily.Rotors = "I V II";
            daily.Reflector = "B";
            daily.BetaOrGamma = "Beta";
            daily.Offsets = "0 9 21";
            daily.Plugs = "I H L P Y S R D M W O Z B N U F Q K C A";
            daily.StartingPositions = "W O L F";
            DailySettingsDAO dao = new DailySettingsDAO(databaseConnectionString);

            int starting = dao.GetDailySettings().Count;

            // act
            dao.AddDailySettings(daily);

            // assert
            int ending = dao.GetDailySettings().Count;
            Assert.AreNotEqual(starting, ending);
        }
    }
}
