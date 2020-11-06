using System;
using System.Collections.Generic;
using System.Linq;
using DragonsEye.APIClient;

namespace DragonsEye
{
    public class UserInterface
    {
        private readonly CryptoService cryptoService = new CryptoService();

        public void ShowMainMenu()
        {
            bool hasQuit = false;
            
            Console.WriteLine("Welcome to Dragon's Eye.");
            Console.WriteLine("------------------------");

            while (!hasQuit)
            {
                Console.WriteLine();
                Console.WriteLine("What would you like to do?");
                Console.WriteLine("   1) Encipher a message");
                Console.WriteLine("   2) Decipher a message");
                Console.WriteLine("   3) Quit");

                int userInput = int.Parse(Console.ReadLine());

                Console.WriteLine();

                switch (userInput)
                {
                    case 1:
                        Console.WriteLine("What is the message?");
                        string enMessage = Console.ReadLine();
                        EncipherAMessage(enMessage);
                        break;

                    case 2:
                        Console.WriteLine("What is the message?");
                        string deMessage = Console.ReadLine();
                        DecipherAMessage(deMessage);
                        break;

                    case 3:
                        hasQuit = true;
                        break;

                    default:
                        Console.WriteLine("Please make a valid choice.");
                        break;
                }
            }
        }

        private void EncipherAMessage(string message)
        {
            Console.WriteLine();
            Console.WriteLine("Enciphered Message:");
            Console.WriteLine(cryptoService.EncipherMessage(message));
            Console.WriteLine();
        }

        private void DecipherAMessage(string message)
        {
            Console.WriteLine();
            Console.WriteLine("Deciphered Message:");
            Console.WriteLine(cryptoService.DecipherMessage(message));
            Console.WriteLine();
        }
    }
}
