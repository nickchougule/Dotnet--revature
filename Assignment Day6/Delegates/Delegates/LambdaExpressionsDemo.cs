using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates
{
    internal class LambdaExpressionsDemo
    {
        public LambdaExpressionsDemo() 
        { 
            Func<int,int>square=(x)=>x*x;
            var result = square(5);
            Console.WriteLine($"The square of 5 is {result}");
        }
    }
}
