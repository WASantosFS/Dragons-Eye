using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace m4dragon.Models_Server
{
    public class Weather
    {
        public decimal WindMPH { get; set; }
        public int WindDegree { get; set; }
        public decimal Pressure { get; set; }
        public decimal Precip { get; set; }
        public int Humidity { get; set; }
        public decimal TempF { get; set; }
    }
}
