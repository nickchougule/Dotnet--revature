using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP.Models
{
    public class Truck : Vehicle, ITrackable,IMaintainable
    {
        private readonly GpsTracker _tracker;
        public Truck(string make,
            string model,
            double fuelLevel,
            GpsTracker tracker)
            : base(make, model, fuelLevel)
        {
            _tracker = tracker;
        }

        public override void Start()
        {
            Console.WriteLine("Truck started");
        }
        public string GetLocation()
        {
            //return "Warehouse Zone A";
            return _tracker.GetCurrentLocation();
        }
        public void ScheduleMaintenance()
        {
            Console.WriteLine("Truck maintenance scheduled.");
        }


    }
}

