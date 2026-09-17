using System;
// Base Class
class Person
{
    public void ShowPerson()
    {
        Console.WriteLine("Person Details");
    }
}
// Single Inheritance
class Student : Person
{
    public void ShowStudent()
    {
        Console.WriteLine("Student Details");
    }
}
// Interface (for Multiple Inheritance)
interface ISports
{
    void ShowSports();
}
// Multilevel + Interface
class Result : Student, ISports
{
    public void ShowResult()
    {
        Console.WriteLine("Result Published");
    }
    public void ShowSports()
    {
        Console.WriteLine("Sports Certificate Awarded");
    }
}
class Program
{
    static void Main(string[] args)
    {
        Result obj = new Result();
        obj.ShowPerson();
        obj.ShowStudent();
        obj.ShowSports();
        obj.ShowResult();
        Console.ReadKey();
    }
}