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
                Console.WriteLine("Your message?");
                string message = Console.ReadLine();

                if (message == "Q")
                {
                    hasQuit = true;
                }
                else
                {
                    CipherAMessage(message);
                }
            }
        }

        private void CipherAMessage(string message)
        {
            Console.WriteLine();
            Console.WriteLine("Result:");
            Console.WriteLine("-------");
            Console.WriteLine(cryptoService.CipherMessage(message));
        }
    }
}
