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
        private string rotorTypeI = "EKMFLGDQVZNTOWYHXUSPAIBRCJ"; // Enigma Rotor "I" wiring.
        private string rotorTypeII = "AJDKSIRUXBLHWTMCQGZNPYFVOE"; // Enigma Rotor "II" wiring.
        private string reflector = "YRUHQSLDPXNGOKMIEBFZCWVJAT"; // Standard "B" reflector wiring.
        private bool isEncrypted = false;

        private int compensated(int x) => x - (26 * (x / 26));
        int count = 0;

        public bool IsEncrypted()
        {
            return isEncrypted;
        }

        public string Shift(string alphabetString, string ringPos)
        {
            return alphabetString.Substring(compensated(alphabet.IndexOf(ringPos) + count)) +
                alphabetString.Substring(0, compensated(alphabet.IndexOf(ringPos) + count));
        }

        public string Encryption(string message, string ringPosA, string ringPosB)
        {
            string encryptedMessage = "";
            string shiftedRotorTypeII = Shift(rotorTypeII, ringPosB);

            foreach (char letter in message)
            {
                string shiftedRotorTypeI = Shift(rotorTypeI, ringPosA);

                char encodingLetterA = shiftedRotorTypeI[compensated(alphabet.IndexOf(letter))]; // Encoding through first rotor.
                char encodingLetterB = shiftedRotorTypeII[alphabet.IndexOf(encodingLetterA)]; // Encoding through second rotor.

                char throughReflector = reflector[alphabet.IndexOf(encodingLetterB)]; // Pushing it through the reflector.

                char throughRotorB = alphabet[shiftedRotorTypeII.IndexOf(throughReflector)];

                encryptedMessage += alphabet[shiftedRotorTypeI.IndexOf(throughRotorB)]; // Appending final encoded letter.
                count++;
            }
            count = 0;
            isEncrypted = true;
            return encryptedMessage;
        }
    }
}
