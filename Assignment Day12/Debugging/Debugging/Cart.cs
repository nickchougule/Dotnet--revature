using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Debugging
{
    internal class Cart
    {
        string[] items;
        public Cart()
        {
            items = new string[3];
            items[0] = "Apple iPhone 6 Plus";
            items[1] = "HTC One M9";
            items[2] = "Microsoft Lumia 950";

        }
        public void DisplayItems()
        {
            int index = 0;
            int numberOfItems = this.items.Length;
            while (index < numberOfItems)
            {
                Console.WriteLine(this.items[index]);
                index += 1;
            }
        }

    }
}
