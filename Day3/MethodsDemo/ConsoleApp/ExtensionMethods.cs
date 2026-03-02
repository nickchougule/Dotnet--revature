namespace ExployeeDemo
{
    public class Employee
    {
        public int ID{set; get;}
        public string FirstName{set; get;}

        public string LastName{set; get;}

        public int Age{set; get;}

        public Employee(int ID,string FirstName, string LastName,int Age)
        {
            this.FirstName=FirstName;
            this.LastName=LastName;
            this.ID=ID;
            this.Age=Age;

            
        }

        public void EmployeeDemo()
        {
            Console.WriteLine($"ID: {this.ID}, Name: {this.FirstName} {this.LastName}, Age: {this.Age}");
        }



    }
}

namespace ExtensionMethodsDemo
{
    using ExployeeDemo;
    public static class EmployeeExtension
    {
        public static void DoubleTheAge(this Employee x)
        {
            // x.Age *= 2;
            x.Age = x.Age * 2;
        }

    }
}