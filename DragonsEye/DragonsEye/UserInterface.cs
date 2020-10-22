using System;
using System.Collections.Generic;
using System.Text;

namespace DragonsEye
{
    public class UserInterface
    {
        Crypto crypto = new Crypto();
        Formatting formatting = new Formatting();

        public void MainMenu()
        {
            bool hasQuit = false;

            while (!hasQuit)
            {
                Console.WriteLine("Welcome to Dragon's Eye.");
                Console.WriteLine("What is message? (Q to quit.)");
                string message = Console.ReadLine().ToUpper();
                Console.WriteLine();

                switch (message)
                {
                    default:
                        if (!crypto.IsEncrypted())
                        {
                            string symbolsReplaced = formatting.Format(message, false);
                            string encryptedMessage = crypto.Encryption(symbolsReplaced, "A", "A");
                            Console.WriteLine(formatting.Grouping(encryptedMessage));
                            Console.WriteLine();
                        }
                        else
                        {
                            string degroupedMessage = formatting.Degrouping(message);
                            string encryptedMessage = crypto.Encryption(degroupedMessage, "A", "A");
                            Console.WriteLine(formatting.Format(encryptedMessage, true));
                            Console.WriteLine();
                        }
                        break;
                    case "Q":
                        hasQuit = true;
                        break;
                }
            }
        }
    }
}
