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
        /// Entire system signal flow is as follows:
        /// Input -> Plugboard -> Fixed Entry/Exit Plate (FEP) -> {Rotor Array} -> Reflector -> {Rotor Array}^-1 -> FEP -> Plugboard -> Output
        /// Where {Rotor Array} = Rotor 1 -> Rotor 2 -> Rotor 3 -> Rotor 4, and ^-1 indicates working in reverse.
        /// Rotor A steps with every letter while Rotors B and C are triggers by the rotor next to it notch(es). Historically, Rotor D does not step.
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public string Encrypt(string message)
        {
            if (message == null) throw new ArgumentNullException(nameof(message));

            // Local Variables. Defines the rotors.
            string encryptedMessage = "";
            string shiftedRotorA = rotor.RotorCreation(rotorTypes[0]).Wiring.Shift(rotorPositions[0], count);
            string shiftedRotorB = rotor.RotorCreation(rotorTypes[1]).Wiring.Shift(rotorPositions[1], 0);
            string shiftedRotorC = rotor.RotorCreation(rotorTypes[2]).Wiring.Shift(rotorPositions[2], 0);
            string shiftedRotorD = rotor.RotorCreation(rotorTypes[3]).Wiring.Shift(rotorPositions[3], 0);

            foreach (char letter in message)
            {
                shiftedRotorA = shiftedRotorA.Shift(rotorPositions[0], count);

                // Encoding through first rotor.
                char encodingLetterA = shiftedRotorA[CalculateCompensatedIndex(alphabet.IndexOf(letter))];

                // Encoding through second rotor.
                //shiftedRotorB = shiftedRotorB.HasReachedNotch(encodingLetterA.ToString(), rotorTypes[0]);
                char encodingLetterB = shiftedRotorB[CalculateCompensatedIndex(alphabet.IndexOf(encodingLetterA))];

                // Encoding through third rotor.
                //shiftedRotorC = shiftedRotorC.HasReachedNotch(encodingLetterB.ToString(), rotorTypes[1]);
                char encodingLetterC = shiftedRotorC[CalculateCompensatedIndex(alphabet.IndexOf(encodingLetterB))];

                // Encoding through forth rotor.
                char encodingLetterD = shiftedRotorD[CalculateCompensatedIndex(alphabet.IndexOf(encodingLetterC))];

                // Pushing it through the reflector.
                char throughReflector = reflector[alphabet.IndexOf(encodingLetterD)]; 

                // Recoding through forth rotor.
                char throughRotorD = alphabet[shiftedRotorD.IndexOf(throughReflector)];

                // Recoding through third rotor.
                char throughRotorC = alphabet[shiftedRotorC.IndexOf(throughRotorD)];

                // Recoding through second rotor.
                char throughRotorB = alphabet[shiftedRotorB.IndexOf(throughRotorC)];

                // Appending final encoded letter.
                encryptedMessage += alphabet[shiftedRotorA.IndexOf(throughRotorB)]; 

                count++;
            }

            count = 0;
            isEncrypted = true;

            return encryptedMessage;
        }
    }
}
