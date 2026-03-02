using System;

static class Teacher
{
    public static string Name;
    static Teacher()
    {
        Console.WriteLine("Inside static constructor");
        Name = "Lily";
    }
    public static string returnN()
    {
        return Name;
    }
}
class Program
{
    static void Main(string[] args)
    {
        // 1. Uncomment the following statement            
        //Teacher obj = new Teacher();
        /* A compilation error would be thrown. 
         * An object of a static class cannot be created. */
        // 2. Execute the application and observe the output displayed
        Console.WriteLine(Teacher.returnN());

        /* 3. Place the cursor on Console (should be done in Visual Studio) in the previous line of statement
         * Press the key F12 on the keyboard 
         * Observe the metadata displayed 
         * The static class Console has only static members declared */
    }
}