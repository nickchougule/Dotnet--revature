using System.Reflection.Metadata;

namespace Day6
{
    class Program
    {
        public static void Main()
        {
            // DelegatesAndEvents delegateevent = new DelegatesAndEvents();
            // delegateevent.run();

            // AnonymousAndLambdaDemo AandL=new AnonymousAndLambdaDemo();

            // AandL.LambdaDemo();
            // AandL.AnonymousDemo();

            // AnonymousAndLambdaDemo.LambdaDemo();
            // AnonymousAndLambdaDemo.AnonymousDemo();

            // HigherOrderFunctionsDemo HF=new HigherOrderFunctionsDemo();
            // HF.HigherorderFunction();

            // EventHandler ev=new EventHandler();

            

            int number = Convert.ToInt32(Console.ReadLine());
            if (number < 2)
            {
                Console.WriteLine(0);
            }
            int count = 0;

            for (int i = 0; i < number; i++)
            {
                for (int j = 1; j < number; j++)
                {
                    if ((i * i * i) + (j * j * j) == number)
                    {
                        count++;
                    }

                }
            }

            Console.WriteLine(count);
            //



        }
    }

    delegate int MathOperation(int a, int b);

    delegate void GenericTwoParameterAction<TFirst, Tsecond>(TFirst a, Tsecond b);
    public class DelegatesAndEvents
    {


        void printmessage(string message)
        {
            Console.WriteLine(message);
        }

        bool IsEven(int number)
        {
            return number % 2 == 0;
        }


        public void run()
        {
            Func<int, int, int> genericOperation = Add;

            Action<string> action = printmessage;
            action("Hello World");


            Predicate<int> predicate = IsEven;
            int testNumber = 4;

            Console.WriteLine($"Is {testNumber} even? {predicate(testNumber)}");


            Func<string, string, string> stringOperation = Concatenate;

            var x = stringOperation("Hello, ", "World!");
            Console.WriteLine($"Concatenation result: {x}");






            genericOperation += subtract;

            var result = genericOperation(5, 3);
            Console.WriteLine($"Final Result:{result}");

        }

        public string Concatenate(string a, string b)
        {
            string result = a + b;
            Console.WriteLine($"Concatenating '{a}' and '{b}' results in: '{result}'");
            return result;
        }



        public int Add(int a, int b)
        {
            Console.WriteLine($"sum of the Two number is:{a + b}");
            return a + b;
        }

        public int subtract(int a, int b)
        {
            Console.WriteLine($"Subtraction{a - b}");
            return a - b;
        }
    }
}