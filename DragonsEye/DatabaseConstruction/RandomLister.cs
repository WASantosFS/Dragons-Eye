using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace DatabaseConstruction
{
    public class RandomLister
    {
        private const string alphabet = "A B C D E F G H I J K L M N O P Q R S T U V W X Y Z";
        private const string rotors = "I II III IV V VI VII VIII";
        private const string fourth = "Beta Gamma";
        private const string reflector = "B C";

        private List<string> lister(string x) => x.Split(" ").ToList();

        public string GetAlphabet()
        {
            return alphabet;
        }

        public string GetRotors()
        {
            return rotors;
        }

        public string GetFourth()
        {
            return fourth;
        }

        public string GetReflector()
        {
            return reflector;
        }

        public List<string> Randomizer(string input, int max)
        {
            var random = new Random();
            List<string> list = new List<string>();

            do
            {
                int index = random.Next(lister(input).Count);
                string value = lister(input)[index];
                if (!list.Contains(input))
                {
                    list.Add(value);
                }
                else
                {
                    continue;
                }
            } while (list.Count < max);

            return list;
        }
    }
}