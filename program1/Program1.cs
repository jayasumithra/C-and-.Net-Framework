using System;
class Program
{
    static void Main(string[] args)
    {
        int number;
        Console.WriteLine("----- Even or Odd Program -----");
        Console.Write("Enter a number: ");
        number = Convert.ToInt32(Console.ReadLine());
        if (number % 2 == 0)
        {
            Console.WriteLine(number + " is an Even Number.");
        }
        else
        {
            Console.WriteLine(number + " is an Odd Number.");
        }
        Console.WriteLine("Program Executed Successfully.");
    }}
