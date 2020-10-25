using System;

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
                Console.WriteLine("What is message? (Q to quit.)");

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
                string encryptedMessage = crypto.Encrypt(symbolsReplaced, "A", "A");

                Console.WriteLine(encryptedMessage.InsertGroupingSpaces());
                Console.WriteLine();
            }
            else
            {
                string degroupedMessage = message.RemoveSpaces();
                string encryptedMessage = crypto.Encrypt(degroupedMessage, "A", "A");

                Console.WriteLine(encryptedMessage.FormatPunctuation(true));
                Console.WriteLine();
            }
        }
    }
}
