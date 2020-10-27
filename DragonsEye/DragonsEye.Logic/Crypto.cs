using DragonsEye.Logic;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace DragonsEye
{
    public class Crypto
    {
        private const string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private int count = 0;
        private bool isEncrypted = false;

        private List<string> rotorTypes;
        private List<string> rotorPositions;

        private readonly Rotor rotor = new Rotor();

        /* TODO: This is a good place to start looking at adding in small classes that can be swapped
           out to change the machine's behavior. Maybe a List<Rotor>? */  
        private string rotorTypeI = "EKMFLGDQVZNTOWYHXUSPAIBRCJ"; // Enigma Rotor "I" wiring.
        private string rotorTypeII = "AJDKSIRUXBLHWTMCQGZNPYFVOE"; // Enigma Rotor "II" wiring.
        private string reflector = "YRUHQSLDPXNGOKMIEBFZCWVJAT"; // Standard "B" reflector wiring.

        public bool IsEncrypted() => isEncrypted;
        private static int CalculateCompensatedIndex(int x) => x - (26 * (x / 26));

        public void SetRotors(List<string> types, List<string> positions)
        {
            rotorTypes = types;
            rotorPositions = positions;
        }

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

            // Local Variables. Defines the rotors.
            string encryptedMessage = "";
            string shiftedRotorTypeII = rotorTypeII.Shift(ringPosB, count);
            string shiftedRotorA = rotor.RotorCreation(rotorTypes[0]).Wiring.Shift(rotorPositions[0], count);
            string shiftedRotorB = rotor.RotorCreation(rotorTypes[1]).Wiring.Shift(rotorPositions[1], count);
            string shiftedRotorC = rotor.RotorCreation(rotorTypes[2]).Wiring.Shift(rotorPositions[2], count);
            string shiftedRotorD = rotor.RotorCreation(rotorTypes[3]).Wiring.Shift(rotorPositions[3], count);

            foreach (char letter in message)
            {
                string shiftedRotorTypeI = rotorTypeI.Shift(ringPosA, count);

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
