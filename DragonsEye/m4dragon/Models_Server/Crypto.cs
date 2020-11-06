using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace m4dragon.Models_Server
{
    public class Crypto
    {
        public int ID { get; set; }
        public int DayOfYear { get; set; }
        public int TimePeriod { get; set; }
        public string Rotors { get; set; }
        public string BetaOrGamma { get; set; }
        public string Reflector { get; set; }
        public string StartingPosition { get; set; }
        public string Offsets { get; set; }
        public string Plugs { get; set; }
        public string Message { get; set; }
    }
}
