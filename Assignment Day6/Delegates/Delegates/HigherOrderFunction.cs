using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates
{
    public class HigherOrderFunction
    {
        public void HigherOrderFunctionDemo()
        {
            var Result = CalcArea(AreaOfRectangle);
            Console.WriteLine($"Area of Rectangle: {Result}");

        }
        int CalcArea(Func<int,int,int> AreaFunction)
        {
            return AreaFunction(5,12);
        }
        int AreaOfRectangle(int length,int width)
        {
            return length * width;
        }
        int AreaOfTriangle(int baseLength,int height)
        {
            return (baseLength * height) / 2;
        }
    }
}
