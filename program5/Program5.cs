using System;
using System.Threading;
class ThreadDemo
{
    public void DisplayNumbers()
    {
        for (int i = 1; i <= 5; i++)
        {
            Console.WriteLine("Number Thread : " + i);
            Thread.Sleep(500);
        }
    }
    public void DisplayAlphabets()
    {
        for (char ch = 'A'; ch <= 'E'; ch++)
        {
            Console.WriteLine("Alphabet Thread : " + ch);
            Thread.Sleep(500);
        }
    }
}
class Program
{
    static void Main(string[] args)
    {
        ThreadDemo obj = new ThreadDemo();
        Thread t1 = new Thread(obj.DisplayNumbers);
        Thread t2 = new Thread(obj.DisplayAlphabets);
        Console.WriteLine("Starting Threads...\n");
        t1.Start();
        t2.Start();
        t1.Join();
        t2.Join();
        Console.WriteLine("\nBoth Threads Completed.");
        Console.ReadKey();
    }
}