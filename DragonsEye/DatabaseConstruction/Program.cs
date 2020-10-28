using System;

namespace DatabaseConstruction
{
    class Program
    {
        static void Main(string[] args)
        {
            bool hasQuit = false;
            RandomLister lister = new RandomLister();

            while (!hasQuit)
            {
                Console.WriteLine("Please select 1 or Q to quit.");
                string userInput = Console.ReadLine();
                Console.WriteLine("Please input target list: alphabet, rotors, fourth, or reflector.");
                string valueInput = Console.ReadLine().ToUpper();
                Console.WriteLine("Please input total desired.");
                int maxInput = int.Parse(Console.ReadLine());

                switch (userInput)
                {
                    default:
                        break;
                    case "Q":
                        hasQuit = true;
                        break;
                    case "1":
                        Console.WriteLine(string.Join(" ", lister.Randomizer(valueInput, maxInput)));
                        break;
                }
            }
        }
    }
}
