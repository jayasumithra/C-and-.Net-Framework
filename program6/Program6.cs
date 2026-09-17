using System;
public delegate void Notify();
class Publisher
{
public event Notify OnProcessCompleted;
public void StartProcess()
    {
        Console.WriteLine("Process Started...");
        Console.WriteLine("Process Completed.");

        if (OnProcessCompleted != null)
        {
            OnProcessCompleted();
        }
    }
}


class Subscriber
{
    public void ShowMessage()
    {
        Console.WriteLine("Event Received: Task Completed Successfully.");
    }
}
class Program
{
    static void Main(string[] args)
    {
        Publisher obj = new Publisher();
        Subscriber sub = new Subscriber();

        obj.OnProcessCompleted += sub.ShowMessage;
        obj.StartProcess();
        Console.ReadKey();
    }
}