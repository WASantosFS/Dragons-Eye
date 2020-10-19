using System;
using System.Collections.Generic;
using System.Text;

namespace DragonsEye
{
    public class UserInterface
    {
        Crypto crypto = new Crypto();

        public void MainMenu()
        {
            bool hasQuit = false;

            while (!hasQuit)
            {
                Console.WriteLine("Welcome to Dragon's Eye.");
                Console.WriteLine("What is message? (Q to quit.)");
                string message = Console.ReadLine().ToUpper();

                switch (message)
                {
                    default:
                        Console.WriteLine(crypto.Encryption(message, "A"));
                        break;
                    case "Q":
                        hasQuit = true;
                        break;
                }
            }
        }
    }
}
