using StreamsAndLambda;

class Program
{
    static void Main(string[] args)
    {
        // Anonymous method using delegate
        Thread thread = new Thread(delegate ()
        {
            Console.WriteLine("Hello from a thread! Printed by: " + Thread.CurrentThread.Name);
        });
        thread.Name = "Thread 1";
        thread.Start();


        // Lambda expression
        Thread thread2 = new Thread(() =>
        {
            Console.WriteLine("Hello from a thread! Printed by: " + Thread.CurrentThread.Name);
        });
        thread2.Name = "Thread 2";
        thread2.Start();


        // Lambda expression with parameters
        Thread thread3 = new Thread((name) =>
        {
            Console.WriteLine("Hello from a thread! Printed by: " + name);
        });
        thread3.Start("Thread 3");


        // Lambda expression with return value
        Func<int, int, int> add = (a, b) => a + b;
        int result = add(5, 10);
        Console.WriteLine($"Result of addition: {result}");


        // Lambda expression with multiple statements
        Func<int, int, int> multiply = (a, b) =>
        {
            Console.WriteLine($"Multiplying {a} and {b}");
            return a * b;
        };
        int product = multiply(5, 10);
        Console.WriteLine($"Result of multiplication: {product}");


        // Lambda expression with LINQ
        List<int> numbers = new List<int> { 1, 2, 3, 4, 5 };
        var evenNumbers = numbers.Where(n => n % 2 == 0).ToList();
        Console.WriteLine("Even numbers: " + string.Join(", ", evenNumbers));


        // Lambda expression with LINQ and method syntax
        var oddNumbers = numbers.Where(n => n % 2 != 0).Select(n => n * 2).ToList();
        Console.WriteLine("Odd numbers multiplied by 2: " + string.Join(", ", oddNumbers));


        // Lambda expression with sorting
        List<Student> students = new List<Student>
        {
            new Student("Alice", 20, 3, "A"),
            new Student("Bob", 22, 1, "B"),
            new Student("Charlie", 21, 2, "C"),
            new Student("David", 23, 4, "D")
        };


        // Sort by RollNo using lambda expression
        students.Sort((s1, s2) => s1.RollNo - s2.RollNo);
        Console.WriteLine("Students sorted by RollNo:");
        foreach (var student in students)
        {
            Console.WriteLine(student);
        }


        // Sort by Name using lambda expression
        students.Sort((s1, s2) => string.Compare(s1.Name, s2.Name));
        Console.WriteLine("Students sorted by Name:");
        foreach (var student in students)
        {
            Console.WriteLine(student);
        }


        FuncExamples.Run();
        Console.WriteLine();

        ActionExamples.Run();
        Console.WriteLine();

        PredicateExamples.Run();
    }
}
