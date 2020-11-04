using DatabaseConstruction.DAL;
using DatabaseConstruction.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace DatabaseConstruction
{
    public class UserInterface
    {
        RandomLister lister = new RandomLister();

        public void Menus()
        {
            bool hasQuit = false;

            while (!hasQuit)
            {
                Console.WriteLine("Please make a selection:");
                Console.WriteLine("   1) Plugboard");
                Console.WriteLine("   2) Rotor Types");
                Console.WriteLine("   3) Fourth Rotor");
                Console.WriteLine("   4) Reflector");
                Console.WriteLine("   5) Indicator");
                Console.WriteLine("   6) Offsets");
                Console.WriteLine("   7) Populate dbo.daily_settings");
                Console.WriteLine("   Q) Quit");
                string userInput = Console.ReadLine().ToUpper();

                switch (userInput)
                {
                    case "1":
                        Console.WriteLine(string.Join(" ", lister.Randomizer(lister.GetAlphabet(), 20)));
                        break;
                    case "2":
                        Console.WriteLine(string.Join(" ", lister.Randomizer(lister.GetRotors(), 3)));
                        break;
                    case "3":
                        Console.WriteLine(string.Join(" ", lister.Randomizer(lister.GetFourth(), 1)));
                        break;
                    case "4":
                        Console.WriteLine(string.Join(" ", lister.Randomizer(lister.GetReflector(), 1)));
                        break;
                    case "5":
                        Console.WriteLine(string.Join(" ", lister.KeyMaker()));
                        break;
                    case "6":
                        Console.WriteLine(string.Join(" ", lister.OffsetMaker()));
                        break;
                    case "7":
                        PopulateDailySettings();
                        break;
                    case "8":
                        Console.WriteLine(string.Join(" ", lister.BigramMaker()));
                        break;
                    case "Q":
                        hasQuit = true;
                        break;
                    default:
                        break;
                }
            }
        }

        public void PopulateDailySettings()
        {
            int count = 1;
            List<int> period = new List<int>(){ 0, 8, 16 };

            Program program = new Program();

            DailySettingsDAO dao = new DailySettingsDAO(program.ReturnConnectionString());
            Console.WriteLine($"Total rows before inserts: {dao.GetDailySettings().Count}");

            while (count < 1098)
            {
                DailySettings daily = new DailySettings();
                daily.DayOfYear = 1 + count/3;
                daily.TimePeriod = period[count % 3];
                daily.Rotors = string.Join(" ", lister.Randomizer(lister.GetRotors(), 3));
                daily.Reflector = string.Join(" ", lister.Randomizer(lister.GetReflector(), 1));
                daily.BetaOrGamma = string.Join(" ", lister.Randomizer(lister.GetFourth(), 1));
                daily.Offsets = string.Join(" ", lister.OffsetMaker());
                daily.Plugs = string.Join(" ", lister.Randomizer(lister.GetAlphabet(), 20));
                daily.StartingPositions = string.Join(" ", lister.KeyMaker());

                dao.AddDailySettings(daily);
                count++;
            }

            Console.WriteLine($"Total rows after inserts: {dao.GetDailySettings().Count}");
        }
    }
}
