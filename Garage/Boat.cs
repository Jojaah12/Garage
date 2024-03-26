using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage
{
    public class Boat : Vehicle
    {
        public double Length { get; set; }

        public Boat(string registrationNumber, string color, int numberOfWheels, double length)
            : base(registrationNumber, color, numberOfWheels)
        {
            Length = length;
        }
    }
}