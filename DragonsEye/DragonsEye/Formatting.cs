using System;
using System.Collections.Generic;
using System.Linq;
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

        public string Grouping(string message)
        {
            int count = 5;
            for (int i = 4; i < message.Length; i += 5)
            {
                /*if (count % 4 == 0)
                {
                    message = message.Insert(i, "\n");
                    count++;
                }
                else
                {*/
                    message = message.Insert(i, " ");
                    count++;
                //}
            }
            return message;
        }

        public string Degrouping(string message)
        {
            return message.Replace(" ", "");
        }
    }
}
