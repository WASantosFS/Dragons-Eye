using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseConstruction.Models
{
    public class DailySettings
    {
        public int Id { get; set; } // Automatically generated -- Identity value and PK.

        public int DayOfYear { get; set; } // Only available values: 1 - 366, inclusive.

        public int TimePeriod { get; set; } // Only available values: 0, 8, 16.

        public string Rotors { get; set; }

        public string BetaOrGamma { get; set; }
        
        public string Reflector { get; set; }
        
        public string StartingPositions { get; set; }

        public string Offsets { get; set; }

        public string Plugs { get; set; }
    }
}
