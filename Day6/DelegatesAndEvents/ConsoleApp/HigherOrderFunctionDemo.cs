namespace Day6
{
    public class HigherOrderFunctionsDemo
    {
        public void HigherorderFunction()
        {
            var result=CalculateArea(AreaRectangle);

            Console.WriteLine($"Area:{result}");
        }
        int CalculateArea(Func<int,int,int>areaFunction)
        {
            return areaFunction(5,10);
        }

        public int AreaRectangle(int length,int bredth)
        {
            return length*bredth;
        }
    }
}