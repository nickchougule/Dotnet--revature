using System.Collections;
using System.Runtime.CompilerServices;
using System.Xml.Serialization;
using static GarbageCollection.RecordDemo;

namespace GarbageCollection
{
    class Program
    {
        private static void DisposableDemo()
        {
            var temp1 = new Temp
            {
                Id = 1,
                Name = "Temp1"
            };
            var temp2 = new Temp
            {
                Id = 2,
                Name = "Temp2"
            };
            Console.WriteLine(temp1);
            Console.WriteLine(temp2);
            Console.WriteLine(temp1 == temp2);
        }
        public static void swap<t>(ref t a, ref t b)
        {
            t Temp = a;
            a = b;
            b = Temp;
        }
        
        static void Main(string[] args)
        {
            //ArrayList list = new ArrayList();

            //// Adding elements (different data types allowed)
            //list.Add(10);
            //list.Add("Soham");
            //list.Add(25.5);
            //list.Add(true);

            //Console.WriteLine("Elements in ArrayList:");
            //double sum = 0;
            //foreach (var item in list)
            //{
            //    Console.WriteLine(item);
            //    if (item is int intValue)
            //    {
            //        sum += intValue;
            //    }
            //    else if (item is double doubleValue)
            //    {
            //        sum += doubleValue;
            //    }

            //    Console.WriteLine($"sum :{sum }");
            //}
            //List<string> list = new List<string>();
            //list.Add("10");
            //list.Add("Soham");
            //list.Add("20");
            //list.Add("50");
            //list.Add("True");
            //foreach (var item in list)
            //{
            //    Console.WriteLine(item);
            //}
            List<int> list = new List<int>();  
            list.Add(10);
            list.Add(20);
            list.Add(30);
            Console.WriteLine($"the count of list is {list.Count},and capacity is {list.Capacity}");
            list.AddRange(new int[] { 40, 50, 60 });
            Console.WriteLine($"the count of list is {list.Count},and capacity is {list.Capacity}");

            //int a = 5, b = 10;
            //swap(ref a, ref b);
            //Console.WriteLine($"Before swap: a = {a}, b = {b}");
            //float x = 1.5f, y = 2.5f;   
            //swap(ref x,ref y);
            //Console.WriteLine($"Before swap: x = {x}, y = {y}");

            //DisposableDemo();
            //    Console.WriteLine("Creating resources...");
            //    var res2 = new Resource("Resource2"); // Long-lived object

            //    CreateResource(); // Resource1 dies here

            //    GC.Collect();
            //    GC.WaitForPendingFinalizers();
            //    GC.Collect();

            //    Console.WriteLine("Garbage collection completed.");
            //    Console.ReadLine();
            //}

            //static void CreateResource()
            //{
            //    var res1 = new Resource("Resource1");


        }
    }
}

