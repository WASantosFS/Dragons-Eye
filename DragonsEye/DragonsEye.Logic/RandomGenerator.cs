using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DragonsEye.Logic
{
    public class RandomGenerator
    {
        Random random = new Random();
        
        private List<string> lister(string x) => x.Split(' ').ToList();
        private const string alphabet = "A B C D E F G H I J K L M N O P Q R S T U V W X Y Z";

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
    }
}
