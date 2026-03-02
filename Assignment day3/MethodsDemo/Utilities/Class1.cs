namespace Utilities;

public class Class1
{
    public string Name { get; set; }
    public int Age { get; set; }

    public Class1(string name, int age)
    {
        Name = name;
        Age = age;
    }
     public int DoubleTheAge()
    {
        return Age * 2;
    }
}
public class TryStudent
{
    public void DisplayStudentInfo(Class1 student)
    {
        Console.WriteLine($"Name: {student.Name}, Age: {student.Age}");
        Console.WriteLine($"Double The Age: {student.DoubleTheAge()}");
    }
}
