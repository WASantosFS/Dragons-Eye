using System;
using System.Collections.Generic;
using System.Linq;
using DragonsEye.Logic;

namespace DragonsEye
{
    public class UserInterface
    {
        private readonly Crypto crypto = new Crypto();

        public void ShowMainMenu()
        {
            bool hasQuit = false;

            while (!hasQuit)
            {
                Console.WriteLine("Welcome to Dragon's Eye.");

                SetRotors();

                Console.WriteLine("What is the message?");

                string message = Console.ReadLine().ToUpper();

                Console.WriteLine();

                switch (message)
                {
                    default:
                        HandleMessageInput(message);
                        break;

                    case "Q":
                        hasQuit = true;
                        break;
                }
            }
        }

        private void HandleMessageInput(string message)
        {
            if (!crypto.IsEncrypted())
            {
                string symbolsReplaced = message.FormatPunctuation(false);
                string encryptedMessage = crypto.Encrypt(symbolsReplaced);

                Console.WriteLine(encryptedMessage.InsertGroupingSpaces());
                Console.WriteLine();
            }
            else
            {
                string degroupedMessage = message.RemoveSpaces();
                string encryptedMessage = crypto.Encrypt(degroupedMessage);

                Console.WriteLine(encryptedMessage.FormatPunctuation(true));
                Console.WriteLine();
            }
        }

        private void SetRotors()
        {
            Console.Write("Please list the rotor types you want (separated by a space): ");
            List<string> rotorTypes = Console.ReadLine().Split(" ").ToList();
            Console.Write("Please list rotor positions (A-Z, separated by space): ");
            List<string> rotorPositions = Console.ReadLine().Split(" ").ToList();

            crypto.SetRotors(rotorTypes, rotorPositions);
        }
    }
}
