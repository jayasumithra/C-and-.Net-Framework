using System;
class Student
{
    int rollNo;
    string name;
    int age;
    double mark;
    public void GetDetails()
    {
        Console.Write("Enter Roll Number: ");
        rollNo = Convert.ToInt32(Console.ReadLine());
        Console.Write("Enter Student Name: ");
        name = Console.ReadLine();
        Console.Write("Enter Age: ");
        age = Convert.ToInt32(Console.ReadLine());
        Console.Write("Enter Mark: ");
        mark = Convert.ToDouble(Console.ReadLine());
    }

    public void DisplayDetails()
    {
        Console.WriteLine("\n----- Student Details -----");
        Console.WriteLine("Roll Number : " + rollNo);
        Console.WriteLine("Name        : " + name);
        Console.WriteLine("Age         : " + age);
        Console.WriteLine("Mark        : " + mark);
        if (mark >= 50)
            Console.WriteLine("Result      : Pass");
        else
            Console.WriteLine("Result      : Fail");
    }
}
class Program
{
    static void Main(string[] args)
    {
        Student s1 = new Student();
        s1.GetDetails();
        s1.DisplayDetails();
        Console.ReadKey();
    }
}