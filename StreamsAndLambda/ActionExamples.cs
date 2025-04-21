using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamsAndLambda
{
    // Action is a delegate that can take parameters and return no value.
    internal static class ActionExamples
    {
        public static void Run()
        {
            Console.WriteLine("=== Action Examples ===");

            // Action with no input
            Action greet = () => Console.WriteLine("Hello, World!");
            greet();

            // Action with one parameter
            Action<string> printMessage = msg => Console.WriteLine("Message: " + msg);
            printMessage("Hello, World!");

            // Action with multiple parameters
            Action<int, int> addNumbers = (a, b) => Console.WriteLine($"Sum: {a + b}");
            addNumbers(5, 10);

            // Action with custom object
            Action<Student> printStudentInfo = s =>
            {
                Console.WriteLine($"{s.Name}, RollNo: {s.RollNo}, Age: {s.Age}, Batch: {s.Batch}");
            };
            var student = new Student("Prasanna", 26, 1, "A");
            printStudentInfo(student);
        }
    }
}
