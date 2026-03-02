using System;

namespace OOPS_Demo
{

    // abstraction
    public abstract class Person
    {
        public string Name { get; set; }

        public abstract void DisplayRole();

        public void Greet()
        {
            Console.WriteLine($"Hello, I am {Name}");
        }
    }

//Inheritance
    public class Employee : Person
    {
        
        private double salary;

        public double Salary
        {
            get { return salary; }
            set
            {
                if (value > 0)
                    salary = value;
                else
                    Console.WriteLine("Salary must be positive");
            }
        }

        // Implementing abstract method (not overriding virtual method)
        public override void DisplayRole()
        {
            Console.WriteLine("Role: Employee");
        }

// MethodOverloading
        public double CalculateBonus(double percent)
        {
            return salary * percent / 100;
        }

        public double CalculateBonus(double percent, double extra)
        {
            return (salary * percent / 100) + extra;
        }
    }

//polymorphism
    public class Manager : Employee
    {
        // No method overriding here
        public void DisplayManagerRole()
        {
            Console.WriteLine("Role: Manager");
        }
    }

   
    
}
