using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DragonsEye.Logic
{
    public static class CryptoUtilities
    {
        private static int CalculateCompensatedIndex(this int x) => x - (26 * (x / 26));

        public static string Shift(this string alpha, string ringPos)
        {
            int count = 0;
            
            string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

            if (alpha == null) throw new ArgumentNullException(nameof(alpha));
            if (ringPos == null) throw new ArgumentNullException(nameof(ringPos));

            int ringIndex = alphabet.IndexOf(ringPos, StringComparison.Ordinal);
            int compensated = CalculateCompensatedIndex(ringIndex + count);

            return alpha.Substring(compensated) + alpha.Substring(0, compensated);
        }
    }
}
