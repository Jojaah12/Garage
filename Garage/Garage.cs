﻿using System.Collections;


namespace Garage
{
    public interface IGarage<T> : IEnumerable<T> where T : IVehicle
    {
        int Capacity { get; }
        int Count { get; }
        void ParkVehicle(T vehicle);
        bool RemoveVehicle(string registrationNumber);
        void ListParkedVehicles();
        List<IVehicle> SearchVehicles(string registrationNumber = null, string color = null, int? numberOfWheels = null);
        T FindVehicle(string registrationNumber);
        void ListVehicleTypesAndCounts();
        void PopulateGarage(IEnumerable<T> initialVehicles);
    }

    public class Garage<T> : IGarage<T> where T : IVehicle
    {
        private T[] vehicles;
        private int count;

        public int Capacity { get; }
        public int Count => count;

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
                    vehicles[i] = default(T);
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

        public List<IVehicle> SearchVehicles(string registrationNumber = null, string color = null, int? numberOfWheels = null)
        {
            List<IVehicle> matchingVehicles = new List<IVehicle>();

            foreach (var vehicle in vehicles)
            {
                if ((registrationNumber == null || vehicle.RegistrationNumber.Equals(registrationNumber, StringComparison.OrdinalIgnoreCase)) &&
                    (color == null || vehicle.Color.Equals(color, StringComparison.OrdinalIgnoreCase)) &&
                    (!numberOfWheels.HasValue || vehicle.NumberOfWheels == numberOfWheels))
                {
                    matchingVehicles.Add(vehicle);
                }
            }

            return matchingVehicles;
        }

        public T FindVehicle(string registrationNumber)
        {
            foreach (var vehicle in vehicles)
            {
                if (vehicle != null && vehicle.RegistrationNumber.Equals(registrationNumber, StringComparison.OrdinalIgnoreCase))
                {
                    return vehicle;
                }
            }
            return default(T);
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

        public void PopulateGarage(IEnumerable<T> initialVehicles)
        {
            foreach (var vehicle in initialVehicles)
            {
                ParkVehicle(vehicle);
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