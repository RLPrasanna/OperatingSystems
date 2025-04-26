// See https://aka.ms/new-console-template for more information

using ExceptionHandling;

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
        //catch (FileNotFoundException ex)
        //{
        //    Console.WriteLine(ex.Message);
        //}
        catch (UnauthorizedAccessException ex)
        {
            Console.WriteLine(ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

        //Try - Catch for parsing a number
        try
        {
            Console.WriteLine("Enter a number:");
            int b = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(b);
        }
        catch (FormatException ex)
        {
            Console.WriteLine(ex.Message);
        }
        catch (OverflowException ex)
        {
            Console.WriteLine(ex.Message);
        }

        try
        {
            Console.WriteLine("Enter x:");
            int x = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter y:");
            int y = Convert.ToInt32(Console.ReadLine());

            if (y == 0)
            {
                throw new WrongInputPassedException("Some message");
            }
            else
            {
                Console.WriteLine(x / y);
            }

            // File operations
            // FileInfo file = new FileInfo("fileName");
            // using (StreamReader reader = file.OpenText())
            // {
            //     Console.WriteLine("Line after filereader");
            //     Console.WriteLine(reader.ReadToEnd());
            // }
        }
        catch (DivideByZeroException)
        {
            Console.WriteLine("Got DivideByZeroException");
        }
        catch (WrongInputPassedException)
        {
            Console.WriteLine("Something went wrong");
        }
        // catch (FileNotFoundException)
        // {
        //     Console.WriteLine("Got FileNotFoundException");
        // }
        // catch (IOException)
        // {
        //     Console.WriteLine("Got IOException");
        // }
        catch (Exception)
        {
            Console.WriteLine("Got General Exception");
        }
        finally
        {
            Console.WriteLine("Inside Finally block");
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