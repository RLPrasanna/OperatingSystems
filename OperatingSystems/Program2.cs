using OperatingSystems;

public class Program2
{
    /// <summary>
    /// Runs the program asynchronously.
    /// This method creates a semaphore to limit the number of concurrent tasks to a maximum of 'maxThreads'.
    /// It then creates a list of tasks and iterates from 0 to 99.
    /// For each iteration, it waits for the semaphore to be available, then starts a new task.
    /// Each task creates a new NumberPrinter object and runs it.
    /// Finally, it waits for all tasks to complete and prints a message indicating that all tasks have finished execution.
    /// </summary>
    public static async Task Run()
    {
        int maxThreads = 10;
        var semaphore = new SemaphoreSlim(maxThreads);
        var tasks = new List<Task>();

        for (int i = 0; i < 100; i++)
        {
            int num = i;
            await semaphore.WaitAsync();

            var task = Task.Run(() =>
            {
                try
                {
                    NumberPrinter printer = new NumberPrinter(num);
                    printer.Run();
                }
                finally
                {
                    semaphore.Release();
                }
            });

            tasks.Add(task);
        }

        await Task.WhenAll(tasks);

        Console.WriteLine("All tasks have finished execution.");
    }
}
