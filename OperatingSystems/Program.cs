// See https://aka.ms/new-console-template for more information
//#define Program1
#define Program2


class Program
{
    static async Task Main(string[] args)
    {
#if Program1
        Program1.Run();
#elif Program2
        await Program2.Run();
#else
        Console.WriteLine("No program selected.");
#endif
    }
}



