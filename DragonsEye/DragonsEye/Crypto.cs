using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace DragonsEye
{
    public class Crypto
    {
        // ABCDEFGHIJKLMNOPQRSTUVWXYZ
        // EKMFLGDQVZNTOWYHXUSPAIBRCJ

        private string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private string encodingString = "EKMFLGDQVZNTOWYHXUSPAIBRCJ"; // Enigma Rotor "I" wiring.
        private string reflector = "YRUHQSLDPXNGOKMIEBFZCWVJAT"; // Standard "B" reflector wiring.
        private int compensated(int x) => x - (26 * (x / 26));
        int count = 0;

        public string Shift(string alphabetString, string ringPos)
        {
            return alphabetString.Substring(compensated(alphabet.IndexOf(ringPos) + count)) +
                alphabetString.Substring(0, compensated(alphabet.IndexOf(ringPos) + count));
        }

        public string Encryption(string message, string ringPos)
        {
            string encryptedMessage = "";

            foreach (char letter in message)
            {
                string shiftedEncodingString = Shift(encodingString, ringPos);

                char encodingLetter = shiftedEncodingString[alphabet.IndexOf(letter)]; // Encoding the letter through the encodingString.
                char throughReflector = reflector[alphabet.IndexOf(encodingLetter)]; // Pushing it through the reflector.
                encryptedMessage += alphabet[shiftedEncodingString.IndexOf(throughReflector)]; // Appending final encoded letter.
                count++;
            }
            count = 0;
            return encryptedMessage;
        }
    }
}
