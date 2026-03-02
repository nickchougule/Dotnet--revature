namespace Day6
{
    public static class AnonymousAndLambdaDemo
    {
        public static void LambdaDemo()
        {
            Func<int,int>f;

            f=(int x)=>x*x;

            var result=f(5);
            Console.WriteLine($"result:{result}");



        }

        public static void AnonymousDemo()
        {
            MathOperation operation=delegate (int a,int b)
            {
                Console.WriteLine($"the Sum of the :{a+b}");
                return a+b;
            };

            operation(5,3);
        }
    }
}