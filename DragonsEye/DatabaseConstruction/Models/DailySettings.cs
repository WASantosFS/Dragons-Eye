using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseConstruction.Models
{
    public class DailySettings
    {
        public int Id { get; set; }

        public DateTime DateTime { get; set; }

        public string StartingPositions { get; set; }

        public string Offsets { get; set; }

        public char Reflector { get; set; }

        public string BetaOrGamma { get; set; }

        public string Plugs { get; set; }
    }
}
