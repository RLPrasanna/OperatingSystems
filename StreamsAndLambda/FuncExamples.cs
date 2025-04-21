using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamsAndLambda
{
    // Func is a delegate that can take parameters and return a value.
    internal static class FuncExamples
    {
        public static void Run()
        {
            Console.WriteLine("=== Func Examples ===");

            // Func with no input, returns a string
            Func<string> greet = () => "Hello, World!";
            Console.WriteLine(greet());

            // Func with one input, returns squared value
            Func<int, int> square = x => x * x;
            Console.WriteLine($"Square of 5: {square(5)}");

            // Func with two inputs, returns their sum
            Func<int, int, int> add = (x, y) => x + y;
            Console.WriteLine($"Sum of 5 and 10: {add(5, 10)}");

            // Func with custom object input
            Func<Student, string> getStudentInfo = s => $"{s.Name} is {s.Age} years old.";
            var student = new Student("Prasanna", 26, 1, "A");
            Console.WriteLine(getStudentInfo(student));

            
            List<string> names = new List<string> { "Alice", "Bob", "Charlie", "David" };
            Func<string, bool> startsWithA = name => name.StartsWith("A");
            Console.WriteLine(
                "Names starting with 'A' (using LINQ): " + string.Join(", ", names.Where(startsWithA))
            );
        }
    }
}
