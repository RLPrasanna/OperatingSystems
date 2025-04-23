using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamsAndLambda
{
    // Linq is a powerful feature in C# that allows you to query collections in a declarative way.
    internal static class LinqExamples
    {
        public static void Run()
        {
            Console.WriteLine("\n=== LINQ Examples ===");

            List<int> numbers = new List<int> { 1, 9 , 5, 2, 3, 6, 10, 5 };

            // LINQ query syntax
            var evenNumbers = from n in numbers
                              where n % 2 == 0
                              select n;
            Console.WriteLine("Even numbers (LINQ query syntax): " + string.Join(", ", evenNumbers));


            // LINQ method syntax
            var oddNumbers = numbers.Where(n => n % 2 != 0)
                                    .Select(n => n * 2)
                                    .OrderByDescending(n => n)
                                    .ToList();
            Console.WriteLine("Odd numbers multiplied by 2 (LINQ method syntax): " + string.Join(", ", oddNumbers));


            // 3. Find the first odd number squared, with debug print
            var optionalI = numbers
                .Where(x => {
                    Console.WriteLine("Filtering: " + x);
                    return x % 2 == 1;
                })
                .Select(x => {
                    Console.WriteLine("Mapping: " + x);
                    return x * x;
                })
                .FirstOrDefault();

            if (optionalI != 0)
            {
                Console.WriteLine("First matching squared value: " + optionalI);
            }


            // LINQ with custom object
            List<Student> students = new List<Student>
            {
                new Student("Alice", 20, 3, "A"),
                new Student("Bob", 22, 1, "B"),
                new Student("Charlie", 21, 2, "B"),
                new Student("David", 23, 4, "C")
            };
            var studentNames = students
                .Where(s => s.Age > 20)
                .Select(s => s.Name)
                .OrderBy(s => s)
                .ToList();

            Console.WriteLine("Students older than 20 (LINQ): " + string.Join(", ", studentNames));


            // LINQ with grouping
            var groupedStudents = students
                .GroupBy(s => s.Batch)
                .Select(g => new { Batch = g.Key, Count = g.Count() })
                .ToList();

            Console.WriteLine("Number of students in each batch:");
            foreach (var group in groupedStudents)
            {
                Console.WriteLine($"Batch {group.Batch}: {group.Count} students");
            }


            // LINQ with aggregation
            var averageAge = students.Average(s => s.Age);
            Console.WriteLine($"Average age of students: {averageAge}");

            var maxAge = students.Max(s => s.Age);
            Console.WriteLine($"Maximum age of students: {maxAge}");

            var minAge = students.Min(s => s.Age);

            Console.WriteLine($"Minimum age of students: {minAge}");

            var sumAge = students.Sum(s => s.Age);
            Console.WriteLine($"Sum of ages of students: {sumAge}");


            // LINQ with distinct
            var distinctAges = students.Select(s => s.Age).Distinct().ToList();
            Console.WriteLine("Distinct ages of students: " + string.Join(", ", distinctAges));


            // LINQ with first and last
            var firstStudent = students.First();
            Console.WriteLine($"First student: {firstStudent.Name}, Age: {firstStudent.Age}");

            var lastStudent = students.Last();
            Console.WriteLine($"Last student: {lastStudent.Name}, Age: {lastStudent.Age}");


            // LINQ with any and all
            var anyStudentAbove25 = students.Any(s => s.Age > 25);
            Console.WriteLine($"Is there any student above 25? {anyStudentAbove25}");

            var allStudentsInBatchA = students.All(s => s.Batch == "A");
            Console.WriteLine($"Are all students in Batch A? {allStudentsInBatchA}");


            // LINQ with count
            var studentCount = students.Count();
            Console.WriteLine($"Total number of students: {studentCount}");


            // LINQ with elementAt
            var secondStudent = students.ElementAt(1);
            Console.WriteLine($"Second student: {secondStudent.Name}, Age: {secondStudent.Age}");


            // LINQ with take and skip
            var top3Students = students.Take(3).ToList();
            Console.WriteLine("Top 3 students: " + string.Join(", ", top3Students.Select(s => s.Name)));

            var skippedStudents = students.Skip(2).ToList();
            Console.WriteLine("Students after skipping 2: " + string.Join(", ", skippedStudents.Select(s => s.Name)));


            // LINQ with join
            List<Course> courses = new List<Course>
            {
                new Course("A", "Math"),
                new Course("B", "Science"),
                new Course("C", "History")
            };
            var studentCourses = from s in students
                                 join c in courses on s.Batch equals c.Batch
                                 select new { s.Name, c.CourseName };

            Console.WriteLine("Students with their courses:");
            foreach (var sc in studentCourses)
            {
                Console.WriteLine($"{sc.Name} is enrolled in {sc.CourseName}");
            }


            // LINQ with selectMany
            var studentDetails = students.SelectMany(s => new[] { s.Name, s.Batch });
            Console.WriteLine("Student details (Name and Batch): " + string.Join(", ", studentDetails));


            // LINQ with zip
            List<string> studentNamesList = new List<string> { "Alice1", "Bob1", "Charlie1", "David1" };
            var zipped = students.Zip(studentNamesList, (s, name) => new { s.Name, s.Age, StudentName = name });
            Console.WriteLine("Zipped student names and ages:");
            foreach (var z in zipped)
            {
                Console.WriteLine($"{z.Name} is {z.Age} years old. Student Name: {z.StudentName}");
            }

            // LINQ with reverse
            var reversedStudents = students.AsEnumerable().Reverse().ToList();
            Console.WriteLine("Reversed students: " + string.Join(", ", reversedStudents.Select(s => s.Name)));

            // LINQ with orderby descending
            var orderedStudents = students.OrderByDescending(s => s.Age).ToList();
            Console.WriteLine("Students ordered by age (descending): " + string.Join(", ", orderedStudents.Select(s => s.Name)));

            // LINQ with orderby ascending
            var orderedStudentsAsc = students.OrderBy(s => s.Age).ToList();
            Console.WriteLine("Students ordered by age (ascending): " + string.Join(", ", orderedStudentsAsc.Select(s => s.Name)));

            // LINQ with aggregate
            var concatenatedNames = students.Select(s => s.Name).Aggregate((current, next) => current + ", " + next);
            Console.WriteLine("Concatenated student names: " + concatenatedNames);

            // LINQ with toLookup
            var studentLookup = students.ToLookup(s => s.Batch);
            Console.WriteLine("Students grouped by batch:");

            foreach (var group in studentLookup)
            {
                Console.WriteLine($"Batch {group.Key}: " + string.Join(", ", group.Select(s => s.Name)));
            }

            // LINQ with firstOrDefault
            var firstStudentInBatchA = students.FirstOrDefault(s => s.Batch == "A");
            if (firstStudentInBatchA != null)
            {
                Console.WriteLine($"First student in Batch A: {firstStudentInBatchA.Name}, Age: {firstStudentInBatchA.Age}");
            }
            else
            {
                Console.WriteLine("No students found in Batch A.");
            }

            // LINQ with lastOrDefault
            var lastStudentInBatchB = students.LastOrDefault(s => s.Batch == "B");
            if (lastStudentInBatchB != null)
            {
                Console.WriteLine($"Last student in Batch B: {lastStudentInBatchB.Name}, Age: {lastStudentInBatchB.Age}");
            }
            else
            {
                Console.WriteLine("No students found in Batch B.");
            }

            // LINQ with single
            var singleStudent = students.SingleOrDefault(s => s.Name == "Alice");
            if (singleStudent != null)
            {
                Console.WriteLine($"Single student found: {singleStudent.Name}, Age: {singleStudent.Age}");
            }
            else
            {
                Console.WriteLine("No single student found with the name Alice.");
            }

            // LINQ with singleOrDefault
            var singleStudentInBatchD = students.SingleOrDefault(s => s.Batch == "D");
            if (singleStudentInBatchD != null)
            {
                Console.WriteLine($"Single student found in Batch D: {singleStudentInBatchD.Name}, Age: {singleStudentInBatchD.Age}");
            }
            else
            {
                Console.WriteLine("No single student found in Batch D.");
            }


            // LINQ with defaultIfEmpty
            var emptyList = new List<int>();
            var defaultList = emptyList.DefaultIfEmpty(0).ToList();
            Console.WriteLine("Default if empty: " + string.Join(", ", defaultList));


            // LINQ with range
            var range = Enumerable.Range(1, 10).ToList();
            Console.WriteLine("Range of numbers from 1 to 10: " + string.Join(", ", range));


            // LINQ with range and select
            var rangeAndSelect = Enumerable.Range(1, 10)
                .Select(n => n * n)
                .ToList();
            Console.WriteLine("Squares of numbers from 1 to 10: " + string.Join(", ", rangeAndSelect));


            // LINQ with repeat
            var repeated = Enumerable.Repeat("Hello", 5).ToList();
            Console.WriteLine("Repeated string 'Hello' 5 times: " + string.Join(", ", repeated));


            // LINQ with concat
            var list1 = new List<int> { 1, 2, 3 };
            var list2 = new List<int> { 4, 5, 6 };
            var concatenatedList = list1.Concat(list2).ToList();
            Console.WriteLine("Concatenated list: " + string.Join(", ", concatenatedList));


            // LINQ with union
            var list3 = new List<int> { 1, 2, 3, 4 };
            var list4 = new List<int> { 3, 4, 5, 6 };
            var unionList = list3.Union(list4).ToList();
            Console.WriteLine("Union of two lists: " + string.Join(", ", unionList));


            // LINQ with intersect
            var intersectionList = list3.Intersect(list4).ToList();
            Console.WriteLine("Intersection of two lists: " + string.Join(", ", intersectionList));


            // LINQ with except
            var exceptList = list3.Except(list4).ToList();
            Console.WriteLine("Except of two lists: " + string.Join(", ", exceptList));


            // LINQ with sequenceEqual
            var list5 = new List<int> { 1, 2, 3 };
            var list6 = new List<int> { 1, 2, 3 };
            var areEqual = list5.SequenceEqual(list6);
            Console.WriteLine($"Are list5 and list6 equal? {areEqual}");


            // LINQ with toArray
            var array = students.ToArray();
            Console.WriteLine("Students as array: " + string.Join(", ", array.Select(s => s.Name)));


            // LINQ with toDictionary
            var studentDictionary = students.ToDictionary(s => s.Name, s => s.Age);
            Console.WriteLine("Students as dictionary:");

            foreach (var kvp in studentDictionary)
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value}");
            }


            // LINQ with toList
            var studentList = students.ToList();
            Console.WriteLine("Students as List: " + string.Join(", ", studentList.Select(s => s.Name)));

        }
    }
}
