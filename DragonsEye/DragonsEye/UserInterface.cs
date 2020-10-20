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

                switch (message)
                {
                    default:
                        if (!crypto.IsEncrypted())
                        {
                            string symbolsReplaced = formatting.Format(message, false);
                            Console.WriteLine(crypto.Encryption(symbolsReplaced, "A"));
                        }
                        else
                        {
                            string encryptedMessage = crypto.Encryption(message, "A");
                            Console.WriteLine(formatting.Format(encryptedMessage, true));
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
