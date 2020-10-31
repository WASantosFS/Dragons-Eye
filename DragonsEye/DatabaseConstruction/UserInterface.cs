﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseConstruction
{
    public class UserInterface
    {
        public void Menus()
        {
            bool hasQuit = false;
            RandomLister lister = new RandomLister();

            while (!hasQuit)
            {
                Console.WriteLine("Please make a selection:");
                Console.WriteLine("   1) Plugboard");
                Console.WriteLine("   2) Rotor Types");
                Console.WriteLine("   3) Fourth Rotor");
                Console.WriteLine("   4) Reflector");
                Console.WriteLine("   5) Indicator");
                Console.WriteLine("   6) Offsets");
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
                    case "Q":
                        hasQuit = true;
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
