using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamsAndLambda
{
    // Predicate is a delegate that takes one input and returns a boolean value. (used in Filters)
    internal static class PredicateExamples
    {
        public static void Run()
        {
            Console.WriteLine("=== Predicate Examples ===");

            // Predicate with string input
            Predicate<string> isLongerThan5 = str => str.Length > 5;
            Console.WriteLine($"Is 'Hello' longer than 5 characters? {isLongerThan5("Hello")}");


            // Predicate with a list of strings
            List<string> names = new List<string> { "Alice", "Bob", "Charlie", "David" };
            Predicate<string> startsWithA = name => name.StartsWith("A");
            List<string> filteredNames = names.FindAll(startsWithA);
            Console.WriteLine("Names starting with 'A': " + string.Join(", ", filteredNames));


            // Predicate with a custom object and multiple conditions
            List<Student> students = new List<Student>
            {
                new Student("Alice", 20, 3, "A"),
                new Student("Bob", 22, 1, "B"),
                new Student("Charlie", 21, 2, "B"),
                new Student("David", 23, 4, "C")
            };
            
            Predicate<Student> isInBatchBAndAgeAbove20 = student =>
                student.Batch == "B" && student.Age > 20;
            List<Student> filteredStudents2 = students.FindAll(isInBatchBAndAgeAbove20);
            Console.WriteLine(
                "Students in Batch B and age above 20: " + string.Join(", ", filteredStudents2)
            );
            
           

        }
    }
}
