using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP.Models
{
    internal class Package
    {
        public double Weight { get; }   
        public double IsFragile { get; }
        public bool IsHeavy => Weight > 20;
        public Package(double weight, double isFragile)
        {
            if ( weight <= 0)
            {
                throw new ArgumentException("weight must be greater than zero.", nameof(weight));

            }
            Weight = weight;
            IsFragile = isFragile;



        }


    }
}
