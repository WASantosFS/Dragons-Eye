using System;
using System.Collections.Generic;
using System.Text;

namespace DragonsEye.Logic
{
    public class Rotor
    {
        /// <summary>
        /// Storage for rotors and allows recall and assignability.
        /// </summary>
        /// <param name="rotorName"></param>
        /// <returns></returns>
        public RotorProps RotorCreation(string rotorName)
        {
            var rotor = new Dictionary<string, RotorProps>()
            {
                ["I"] = new RotorProps { Wiring = "EKMFLGDQVZNTOWYHXUSPAIBRCJ", Notches = "Q" },
                ["II"] = new RotorProps { Wiring = "AJDKSIRUXBLHWTMCQGZNPYFVOE", Notches = "E" },
                ["III"] = new RotorProps { Wiring = "BDFHJLCPRTXVZNYEIWGAKMUSQO", Notches = "V" },
                ["IV"] = new RotorProps { Wiring = "ESOVPZJAYQUIRHXLNFTGKDCMWB", Notches = "J" },
                ["V"] = new RotorProps { Wiring = "VZBRGITYUPSDNHLXAWMJQOFECK", Notches = "Z" },
                ["VI"] = new RotorProps { Wiring = "PGVOUMFYQBENHZRDKASXLICTW", Notches = "Z,M" },
                ["VII"] = new RotorProps { Wiring = "NZJHGRCXMYSWBOUFAIVLPEKQDT", Notches = "Z,M" },
                ["VIII"] = new RotorProps { Wiring = "FKQHTLXOCBJSPDZRAMEWNIUYGV", Notches = "Z,M" },
                ["Beta"] = new RotorProps { Wiring = "LEYJVCNIXWPBQMDRTAKZGFUHOS"},
                ["Gamma"] = new RotorProps { Wiring = "FSOKANUERHMBTIYCWLQPZXVGJD"},
                ["Reflector B"] = new RotorProps { Wiring = "ENKQAUYWJICOPBLMDXZVFTHRGS" },
                ["Reflector C"] = new RotorProps { Wiring = "RDOBJNTKVEHMLFCWZAXGYIPSUQ" }
            };

            return rotor[rotorName];
        }
    }
}
