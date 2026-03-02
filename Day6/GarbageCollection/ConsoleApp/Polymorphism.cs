namespace Day6
{
    public class Polymorphism
    {
        public void swap<T>(ref T a,ref T b)
        {
            T temp=a;
            a=b;
            b=temp; 
        }
        
    }
} 