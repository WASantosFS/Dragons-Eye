using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using DragonsEye.APIClient;

namespace DragonsEye
{
    public class UserInterface
    {
        private readonly CryptoService cryptoService = new CryptoService();

        public void ShowMainMenu()
        {
            Console.WriteLine("Welcome to m4 Dragon");
            Console.WriteLine("--------------------");
            Console.WriteLine();
            Console.WriteLine("You should know this is for fun, but... This is for fun. :-)");

            while (true)
            {
                Console.WriteLine("Please type (Y)es if you accept this, or (N)o if you don't.");

                string userInput = Console.ReadLine().ToUpper();

                if (userInput == "Y" || userInput == "YES")
                {
                    Console.Clear();
                    Console.WriteLine("Rules:");
                    Console.WriteLine("  1) No numbers inside the message.");
                    Console.WriteLine("  2) Only allowed punctuation are spaces and: ! ? , . - ( ) ' :");
                    Console.WriteLine("  3) Maximum character count is 250.");
                    while (true)
                    {
                        Console.WriteLine("Your message or (Q)uit:");
                        string input = Console.ReadLine().ToUpper();

                        if (input == "Q" || input == "QUIT")
                        {
                            QuitProgram();
                        }
                        else
                        {
                            CipherAMessage(input);
                        }
                    }
                }
                else if (userInput == "N" || userInput == "NO")
                {
                    QuitProgram();
                }
                else
                {
                    Console.WriteLine("Please make a valid choice.");
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

        private void QuitProgram()
        {
            Console.WriteLine("Thank you for using m4 Dragon!");
            Console.WriteLine("Goodbye!");
            Environment.Exit(0);
        }

        private int CharacterCounterRemoval(int count)
        {
            if (count <= 9)
            {
                return 4;
            }
            else if (count >= 10 && count <= 99)
            {
                return 5;
            }
            else if (count >= 100 && count <= 1000)
            {
                return 6;
            }

            return 4;
        }

        private string CharacterCounter()
        {
            int countMessage = 0;
            int countLine = 0;
            string message = "";
            ConsoleKeyInfo key;

            do
            {
                key = Console.ReadKey(true);

                if (!char.IsControl(key.KeyChar))
                {
                    message += key.KeyChar;
                    Console.Write($"{message} ({++countMessage})");
                    ++countLine;
                    if (Console.CursorLeft == Console.WindowWidth - 1)
                    {
                        Console.WriteLine();
                        countLine = 0;
                    }
                    else
                    {
                        Console.SetCursorPosition(Console.CursorLeft - CharacterCounterRemoval(countLine) - countLine, Console.CursorTop);
                    }
                    //TODO: How to handle word-wrap? Console.CursorTop applies to only 1 line.
                }
                else
                {
                    if (key.Key == ConsoleKey.Backspace && message.Length > 0)
                    {
                        message = message.Remove(message.Length - 1);
                        Console.Write("\b \b");
                    }
                }
            } while (key.Key != ConsoleKey.Enter);

            return message;
        }
    }
}
