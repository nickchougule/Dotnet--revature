using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP.Models
{
    public class Car: Vehicle
    {
        public Car(string make,string model,double fuelLevel):base(make, model, fuelLevel)
        {

        }
        public override void Start()
        { 
            Console.WriteLine("Car Started");
        }
    }
}
