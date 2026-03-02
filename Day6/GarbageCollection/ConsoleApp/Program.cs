using System.Collections;
using System.Reflection;
using System.Reflection.Metadata.Ecma335;
using Microsoft.VisualBasic;


namespace Day6
{
    class Program
{
    static void Main()
    {
        // GarbageCollection x= CreateObjects(); 
       
        // ArrayList arr=new ArrayList();

        // arr.Add(10);
        
        // arr.Add(20);
        // arr.Add(30);
        // arr.Add("Hello");
        // arr.Add(3.14);
        //  var sum=0;
        // foreach(var item in arr){
        //         sum+=(int)item;
        //         Console.WriteLine($"sum:{sum}");
        //     }


        // List<string> list=new List<string>();

        // list.Add("Hello");
        // list.Add("Hi");
        // list.Add("Hey");


        // foreach(var items in list)
        //     {
        //         Console.WriteLine(items);
        //     }
        // GC.Collect();
        // GC.WaitForPendingFinalizers();

        // Console.WriteLine("Waiting");
        // Console.ReadLine();
        // RecordDemo();
        // Demo();

        CollectionDemo();

        
    }

    // static  GarbageCollection CreateObjects()
    // {
    //     var resource1 = new GarbageCollection("resource1");
    //     var Resource2 = new GarbageCollection("Resource2");

    //     resource1 = null;
    //     return Resource2;

        
    // }


        static void Demo()
        {
            Polymorphism poly = new Polymorphism();
            int a=4,b=5;
            string name1="Nikhil";
            string name2="Nick";

            poly.swap(ref a,ref b);
            Console.WriteLine($"x:{a},y:{b}");

            poly.swap(ref name1,ref name2);
            
                Console.WriteLine($"Name1:{name1},Name2:{name2}");
            
            



        }

        private static void RecordDemo()
        {
            var temp1=new Temp{ID=1,Name="temp1"};
            var temp2=new Temp{ID=2,Name="temp2"};

            Console.WriteLine(temp1);
            Console.WriteLine(temp2);
            Console.WriteLine(temp1==temp2);
        }

        public static void CollectionDemo()
        {
            List<int> list=new List<int>(10);

            list.Add(1);
            list.Add(2);

            

            Console.WriteLine($"{list.Count},{list.Capacity}");
            

            list.AddRange(new int []{1,2,3,4,5});

            Console.WriteLine($"{list.Count},{list.Capacity}");

            list.AddRange(new int[]{1,2,3,4,5,6,7});

            Console.WriteLine($"{list.Count},{list.Capacity}");
            
        }
}

}