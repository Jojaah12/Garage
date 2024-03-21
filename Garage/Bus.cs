using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage
{
    public class Bus : Vehicle
    {
        public int Capacity { get; set; }

        public Bus(string registrationNumber, string color, int numberOfWheels, int capacity)
            : base(registrationNumber, color, numberOfWheels)
        {
            Capacity = capacity;
        }
    }
}
