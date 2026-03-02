using System.Security.Principal;

namespace Day3
{
    class MaxFinder
    {
        public static void TryFindMax(int [] numbers,out int max)
        {
            max=0;

            foreach(var items in numbers)
            {
                if (items > max)
                {
                    max=items;
                }
            }
        }



        public static void PassValues()
        {

            int [] arr={1,2,3,4};
            TryFindMax(arr,out int result);

            Console.WriteLine($"Maximum Value:{result}");

            

        }
    }
}