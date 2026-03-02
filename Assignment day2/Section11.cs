//using System;
//using System.Collections.Generic;
//using System.Linq;

//namespace Assignment_day2
//{
//    internal class Section11
//    {
//        static void Main(string[] args)
//        {
//            // Array (fixed size)
//            int[] arr = new int[3] { 1, 2, 3 };

//            foreach (var num in arr)
//                Console.WriteLine(num);

//            // List (dynamic size)
//            var list = new List<string> { "a", "b" };
//            list.Add("c");

//            foreach (var item in list)
//                Console.WriteLine(item);

//            // LINQ example
//            var listOfInts = new List<int> { 1, 2, 3, 4, 5, 6 };

//            var evens = listOfInts
//                        .Where(i => i % 2 == 0)
//                        .ToArray();

//            Console.WriteLine("Even numbers:");
//            foreach (var e in evens)
//                Console.WriteLine(e);
//        }
//    }
//}
