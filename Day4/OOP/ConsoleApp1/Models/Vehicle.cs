using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace OOP.Models
{
    public abstract class Vehicle
    {
        private static int _idCounter = 1;
        public string Id { get; }
        public string Make { get; }
        public string Model { get; }
        public double FuelLevel { get; private set; }
        public Vehicle(string make, string model, double fuelLevel)
        {
            if (fuelLevel < 0 || fuelLevel > 100)
            
                throw new ArgumentOutOfRangeException(nameof(fuelLevel), "fuel level must be between 0 and 100.");
                Id = $"V{_idCounter++}";
                Make = make;
                Model = model;
                FuelLevel = fuelLevel;
            
            
        }
        public abstract void Start();
        //{
        //    if(FuelLevel <= 0)
        //    {
        //        Console.WriteLine("cannot start the vehicle. No fuel.");
        //        return;
        //    }
        //    Console.WriteLine("Vehicle Started");

        //}
        public void Refuel(double amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException(
                    "Amount must be greater than zero.",
                    nameof(amount)
                );
            }

            if (FuelLevel + amount > 100)
            {
                throw new InvalidOperationException(
                    "Fuel cannot exceed tank capacity (100)."
                );
            }

            FuelLevel += amount;
        }



    }
}
