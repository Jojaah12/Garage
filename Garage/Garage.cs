﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage
{
    public class Garage<T> : IEnumerable<T> where T : Vehicle
    {
        private T[] vehicles;
        private int count;

        public int Capacity { get; }

        public Garage(int capacity)
        {
            Capacity = capacity;
            vehicles = new T[capacity];
            count = 0;
        }

        public void ParkVehicle(T vehicle)
        {
            if (count < Capacity)
            {
                vehicles[count++] = vehicle;
                Console.WriteLine($"Vehicle parked: {vehicle.RegistrationNumber}");
            }
            else
            {
                Console.WriteLine("Garage is full. Cannot park more vehicles.");
            }
        }

        public bool RemoveVehicle(string registrationNumber)
        {
            for (int i = 0; i < count; i++)
            {
                if (vehicles[i].RegistrationNumber.Equals(registrationNumber, StringComparison.OrdinalIgnoreCase))
                {
                    vehicles[i] = null;
                    count--;
                    Console.WriteLine($"Vehicle with registration number {registrationNumber} removed from the garage.");
                    return true;
                }
            }
            Console.WriteLine($"Vehicle with registration number {registrationNumber} not found in the garage.");
            return false;
        }

        public void ListParkedVehicles()
        {
            Console.WriteLine("Parked Vehicles:");
            foreach (var vehicle in vehicles)
            {
                if (vehicle != null)
                {
                    Console.WriteLine($"Registration Number: {vehicle.RegistrationNumber}, Color: {vehicle.Color}, Number of Wheels: {vehicle.NumberOfWheels}");
                }
            }
        }

        public void ListVehicleTypesAndCounts()
        {
            Dictionary<Type, int> vehicleCounts = new Dictionary<Type, int>();

            foreach (var vehicle in vehicles)
            {
                if (vehicle != null)
                {
                    Type vehicleType = vehicle.GetType();
                    if (vehicleCounts.ContainsKey(vehicleType))
                    {
                        vehicleCounts[vehicleType]++;
                    }
                    else
                    {
                        vehicleCounts[vehicleType] = 1;
                    }
                }
            }

            Console.WriteLine("Vehicle Types and Counts:");
            foreach (var kvp in vehicleCounts)
            {
                Console.WriteLine($"{kvp.Key.Name}: {kvp.Value}");
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var vehicle in vehicles)
            {
                if (vehicle != null)
                {
                    yield return vehicle;
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}