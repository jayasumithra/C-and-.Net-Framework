using System;

class Program
{
    static void Main()
    {
        int a, b;

        Console.Write("Enter the first number: ");
        a = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter the second number: ");
        b = Convert.ToInt32(Console.ReadLine());

        if (a > b)
        {
            Console.WriteLine("Largest number = " + a);
        }
        else if (b > a)
        {
            Console.WriteLine("Largest number = " + b);
        }
        else
        {
            Console.WriteLine("Both numbers are equal");
        }
    }
}

