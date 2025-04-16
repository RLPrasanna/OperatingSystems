// See https://aka.ms/new-console-template for more information
using OperatingSystems;

/// <summary>
/// Represents a program that creates and runs multiple threads to print numbers.
/// </summary>
public class Program1
{
    public static void Run()
    {
        // Create a list to store all the threads
        List<Thread> allThreads = new List<Thread>();

        // Create 100 threads
        for (int i = 0; i < 100; i++)
        {
            int num = i;
            NumberPrinter printer = new NumberPrinter(num);

            // Create a new thread and pass the printer's Run method as the thread's entry point
            Thread thread = new Thread(printer.Run);

            //new way using lambda expression
            //Thread thread = new Thread(()=>printer.Run());

            allThreads.Add(thread);
            thread.Start();
        }

        // Wait for all the threads to finish execution
        foreach (Thread thread in allThreads)
        {
            thread.Join();
        }

        // Print a message indicating that all threads have finished execution
        Console.WriteLine("All threads have finished execution.");
    }
}


