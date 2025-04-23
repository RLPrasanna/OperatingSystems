using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamsAndLambda
{
    // Delegate is a type that represents references to methods with a specific parameter list and return type.
    // Delegates are used to pass methods as arguments to other methods.
    // They are similar to function pointers in C/C++ but are type-safe and secure.
    // Delegates can be used to define callback methods, event handlers, and LINQ queries.
    // A delegate can be declared using the "delegate" keyword followed by the return type and method signature.
    internal static class DelegateExamples
    {
        public delegate void GreetDelegate(string name);
        public delegate int MathOperation(int a, int b);

        public static void Run()
        {
            Console.WriteLine("\n=== Delegate Examples ===");

            // Assign method to delegate
            GreetDelegate greet = GreetUser;
            greet("Prasanna");

            // Multicast delegate
            greet += GreetUserLoudly;
            greet("Prasanna");

            Console.WriteLine("\n --------Delegate for Math Operations--------");

            MathOperation add = Add;
            MathOperation multiply = Multiple;

            Console.WriteLine($"Addition: {add(5, 10)}");
            Console.WriteLine($"Multiplication: {multiply(5, 10)}");

            // Using anonymous methods
            MathOperation subtract = delegate (int a, int b)
            {
                return a - b;
            };
            Console.WriteLine($"Subtraction: {subtract(10, 5)}");


            // Pass delegates to method as parameters
            PerformOperations(5, 3, add);
            PerformOperations(5, 3, multiply);

            // Or pass lambda expressions directly
            PerformOperations(10, 2, (x, y) => x - y);


            // Using built-in delegates: Func, Action, Predicate
            Console.WriteLine("\n----- Built-in Delegates -----");

            // Func: returns a value
            Func<int, int, int> divide=(a,b) => a / b;
            Console.WriteLine($"Division: {subtract(10, 5)}");

            // Action: returns void
            Action<string> printMessage = message => Console.WriteLine(message);
            printMessage("Hello from Action delegate!");

            // Predicate: returns bool
            Predicate<int> isEven = num => num % 2 == 0;
            Console.WriteLine($"Is 4 even? {isEven(4)}");
            Console.WriteLine($"Is 5 even? {isEven(5)}");
        }


        // Delegate-compatible methods
        static void GreetUser(string name)
        {
            Console.WriteLine($"Hello, {name}!");
        }

        static void GreetUserLoudly(string name)
        {
            Console.WriteLine($"HELLO, {name.ToUpper()}!!!");
        }

        static int Add(int a, int b) => a + b;

        static int Multiple(int a, int b) => a * b;


        // Method that takes a delegate as a parameter (method pointer)
        static void PerformOperations(int a, int b, MathOperation operation)
        {
            int result = operation(a, b);
            Console.WriteLine($"Result: {result}");
        }
    }
}
