// See https://aka.ms/new-console-template for more information

public class Program
{
    public static void Main(string[] args)
    {
        // Reading user input
        Console.WriteLine("Enter a number:");
        int a = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine(a);

        //Try - Catch for reading a file
        try
        {
            ReadFile("abc.txt");
        }
        catch (IOException ex)
        {
            Console.WriteLine(ex.Message);
        }

    }

    private static void ReadFile(string path)
    {
        FileInfo file = new FileInfo(path);
        using (StreamReader reader = file.OpenText())
        {
            Console.WriteLine(reader.ReadToEnd());
        }
    }
}