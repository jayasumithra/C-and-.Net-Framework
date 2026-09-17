using System;
class Number
{
    public int value;
    // Constructor
    public Number(int x)
    {
        value = x;
    }
    // Unary Operator Overloading
    public static Number operator ++(Number n)
    {
        n.value++;
        return n;
    }
    // Binary Operator Overloading
    public static Number operator +(Number a, Number b)
    {
        return new Number(a.value + b.value);
    }
    public void Display()
    {
        Console.WriteLine("Value = " + value);
    }
}
class Program
{
    static void Main(string[] args)
    {
        Number n1 = new Number(10);
        Number n2 = new Number(20);
        Console.WriteLine("Before Unary Operator:");
        n1.Display();
        ++n1;
        Console.WriteLine("After Unary Operator:");
        n1.Display();
        Number n3 = n1 + n2;
        Console.WriteLine("After Binary Operator (+):");
        n3.Display();
        Console.ReadKey();
    }
}