using DragonsEye.Logic;
using System;

namespace DragonsEye
{
    public class Crypto
    {
        // ABCDEFGHIJKLMNOPQRSTUVWXYZ
        // EKMFLGDQVZNTOWYHXUSPAIBRCJ

        private const string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

        /* TODO: This is a good place to start looking at adding in small classes that can be swapped
           out to change the machine's behavior. Maybe a List<Rotor>? */  
        private string rotorTypeI = "EKMFLGDQVZNTOWYHXUSPAIBRCJ"; // Enigma Rotor "I" wiring.
        private string rotorTypeII = "AJDKSIRUXBLHWTMCQGZNPYFVOE"; // Enigma Rotor "II" wiring.
        private string reflector = "YRUHQSLDPXNGOKMIEBFZCWVJAT"; // Standard "B" reflector wiring.

        private bool isEncrypted = false;

        private static int CalculateCompensatedIndex(int x) => x - (26 * (x / 26));

        private int count = 0;

        public bool IsEncrypted() => isEncrypted;

        /* Note: I added optional parameters here to make the tests compile, but I feel like these
          parameters are both internal state to this class or a different class. I'd consider making
          these things fields (class variables).*/
        /// <summary>
        /// Method that actually does the en/deciphering.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="ringPosA"></param>
        /// <param name="ringPosB"></param>
        /// <returns></returns>
        public string Encrypt(string message, string ringPosA = "A", string ringPosB = "A")
        {
            if (message == null) throw new ArgumentNullException(nameof(message));

            // This method isn't really readable to someone who doesn't understand Enigma, even with the comments present.

            string encryptedMessage = "";
            string shiftedRotorTypeII = rotorTypeII.Shift(ringPosB);

            foreach (char letter in message)
            {
                string shiftedRotorTypeI = rotorTypeI.Shift(ringPosA);

                // Encoding through first rotor.
                char encodingLetterA = shiftedRotorTypeI[CalculateCompensatedIndex(alphabet.IndexOf(letter))];
                // Encoding through second rotor.
                char encodingLetterB = shiftedRotorTypeII[alphabet.IndexOf(encodingLetterA)];

                // Pushing it through the reflector.
                char throughReflector = reflector[alphabet.IndexOf(encodingLetterB)]; 

                char throughRotorB = alphabet[shiftedRotorTypeII.IndexOf(throughReflector)];

                // Appending final encoded letter.
                encryptedMessage += alphabet[shiftedRotorTypeI.IndexOf(throughRotorB)]; 

                count++;
            }

            count = 0;
            isEncrypted = true;

            return encryptedMessage;
        }
    }
}
