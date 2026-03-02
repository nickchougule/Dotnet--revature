namespace Delegates
{
    public class DelegateDemo
    {
        delegate int MathOps(int a, int b);
        void PrintMessage(string message)
        {
            Console.WriteLine(message);
        }

        bool IsEven(int number)
        {
            return number % 2 == 0;
        }
        public void Run()
        {
            Func<int, int, int> genericOperation = Add;

            Action<string> action = PrintMessage;
            action("Hello from Action delegate!");

            Predicate<int> predicate = IsEven;
            int testNumber = 4;

            Console.WriteLine($"Is {testNumber} even? {predicate(testNumber)}");

            //return;

            Func<string, string, string> stringOperation = Concatenate;


            var x = stringOperation("Hello, ", "World!");
            Console.WriteLine($"Concatenation result: {x}");
            MathOps Ops = Add;
            Ops+= Subtract;
            Ops+= Multiply;
            Ops+= Divide;
            var result=Ops(5, 6);
            Console.WriteLine(result);
        }
        public string Concatenate(string a, string b)
        {
            string result = a + b;
            Console.WriteLine($"Concatenating '{a}' and '{b}' results in: '{result}'");
            return result;
        }

        public int Add(int a, int b)
        {
            Console.WriteLine($"The sum of {a} and {b} is {a + b}");
            return a + b;
        }
        public int Subtract(int a, int b)
        {
            Console.WriteLine($"The difference of {a} and {b} is {a - b}");
            return a - b;
        }
        public int Multiply(int a, int b)
        {
            Console.WriteLine($"The product of {a} and {b} is {a * b}");
            return a * b;
        }   
        public int Divide(int a, int b)
            {
                if (b != 0)
                {
                    Console.WriteLine($"The quotient of {a} and {b} is {a / b}");
                }
                else
                {
                    Console.WriteLine("Cannot divide by zero.");
                }
                return b != 0 ? a / b : 0;
        }
    }
    delegate void Mathops(int a, int b);
    delegate TResult GenericTwoParameterFunction<TFirst, TSecond, TResult>(TFirst a, TSecond b);
    delegate void GenericTwoParameterAtion<TFirst, TSecond>(TFirst a, TSecond b);
    public class Program
    {
        public static void Main(string[] args)
        {
            //DelegateDemo demo = new DelegateDemo();
            //demo.Run();
            //LambdaExpressionsDemo demo =new LambdaExpressionsDemo();
            //HigherOrderFunction demo = new HigherOrderFunction();
            //demo.HigherOrderFunctionDemo();
            EventHandler demo = new EventHandler();




        }
    }
}