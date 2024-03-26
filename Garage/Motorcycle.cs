using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage
{
    public class Motorcycle : Vehicle
    {
        public bool HasSideCar { get; set; }

        public Motorcycle(string registrationNumber, string color, int numberOfWheels, bool hasSideCar)
            : base(registrationNumber, color, numberOfWheels)
        {
            HasSideCar = hasSideCar;
        }
    }
}
