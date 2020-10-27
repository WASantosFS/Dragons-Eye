using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Net.NetworkInformation;

namespace DragonsEye.Logic
{
    public static class CryptoUtilities
    {

        private static int CalculateCompensatedIndex(int x) => x - (26 * (x / 26));
        private const string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

        public static string Shift(this string alpha)
        {
            if (alpha == null) throw new ArgumentNullException(nameof(alpha));

            return alpha.Substring(1) + alpha.Substring(0, 1);
        }

        public static string Shift(this string alpha, string ringPos, int count)
        {
            if (alpha == null) throw new ArgumentNullException(nameof(alpha));
            if (ringPos == null) throw new ArgumentNullException(nameof(ringPos));

            int ringIndex = alphabet.IndexOf(ringPos, StringComparison.Ordinal);
            int compensated = CalculateCompensatedIndex(ringIndex + count);

            return alpha.Substring(compensated) + alpha.Substring(0, compensated);
        }

        public static string HasReachedNotch(this string wiring, string currentLetter, string rotorType)
        {
            Rotor rotor = new Rotor();

            // If prior rotor has reached notch, progress current rotor by 1.
            if (rotorType == "VI" || rotorType == "VII" || rotorType == "VIII")
            {
                if (currentLetter == "M" || currentLetter == "Z")
                {
                    return wiring.Shift();
                }
            }
            if (rotor.RotorCreation(rotorType).Notches == currentLetter)
            {
                return wiring.Shift();
            }

            return wiring;
        }
    }
}
