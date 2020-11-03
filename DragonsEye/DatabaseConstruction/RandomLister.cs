using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace DatabaseConstruction
{
    public class RandomLister
    {
        Random random = new Random();
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

        // This method is okay for plugs, rotors, fourth, and reflector.
        public List<string> Randomizer(string input, int max)
        {
            List<string> list = new List<string>();

            do
            {
                int index = random.Next(lister(input).Count);
                string value = lister(input)[index];
                if (!list.Contains(value))
                {
                    list.Add(value);
                }
            } while (list.Count < max);

            return list;
        }

        // This method is exclusively for the starting position, key and encryption indicators generation.
        public List<string> KeyMaker()
        {
            List<string> list = new List<string>();

            do
            {
                int index = random.Next(lister(alphabet).Count);
                string value = lister(alphabet)[index];
                list.Add(value);
            } while (list.Count < 4);

            return list;
        }

        // This method is exclusively for offset generation.
        public List<string> OffsetMaker()
        {
            List<string> list = new List<string>();

            while (list.Count < 3)
            {
                list.Add(random.Next(0, 26).ToString());
            }

            return list;
        }
    }
}