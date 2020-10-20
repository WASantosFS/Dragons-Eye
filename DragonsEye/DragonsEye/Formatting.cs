using System;
using System.Collections.Generic;
using System.Text;

namespace DragonsEye
{
    public class Formatting
    {
        //{" ", "!", "?", "'", ":", ";", "(", ")", "-", ",", "."};
        //{"YX", "XD", "YD", "ZD", "XX", "XY", "KKA", "KKB", "YY", "ZZ", "XZ"};
        public string Format(string message, bool isEnciphered)
        {
            List<string> symbols = new List<string>() { " ", "!", "?", "'", ":", ";", "(", ")", "-", ",", "." };
            List<string> substitutes = new List<string>() { "YX", "XD", "YD", "ZD", "XX", "XY", "KKA", "KKB", "YY", "ZZ", "XZ" };

            for (int i = 0; i < symbols.Count; i++)
            {
                if (!isEnciphered)
                {
                    message = message.Replace(symbols[i], substitutes[i]);
                }
                else
                {
                    message = message.Replace(substitutes[i], symbols[i]);
                }
            }

            return message;
        }
    }
}
