using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP.Models
{
    internal class Location
    {
        
        public string Address { get; }

        public Location(string address)
        {
            Address = address ?? throw new ArgumentNullException(nameof(address));
        }
    }
}

