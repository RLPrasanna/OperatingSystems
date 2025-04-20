// See https://aka.ms/new-console-template for more information


// === Different List Implementations ===

using Collections;

List<int> list1 = new List<int>();
LinkedList<int> list2 = new LinkedList<int>();
Queue<int> queue = new Queue<int>();
Stack<int> stack = new Stack<int>();

PriorityQueue<int, int> q1 = new PriorityQueue<int, int>();
q1.Enqueue(10, 10);
q1.Enqueue(20, 20);
q1.Enqueue(5, 5);
q1.Enqueue(1, 1);
q1.Enqueue(15, 15);
q1.Enqueue(7, 7);

Console.WriteLine("PriorityQueue:");
while(q1.Count > 0)
{
    Console.Write(q1.Dequeue()+" ");
}
Console.WriteLine();


// === Set Implementations ===

HashSet<int> set1 = new HashSet<int>(); // Like HashSet - random order
SortedSet<int> set2 = new SortedSet<int>(); // Like TreeSet - sorted order
LinkedList<int> insertionOrder = new LinkedList<int>(); // Like LinkedHashSet - insertion order

int[] elements = { 550, 1, 1000, 22, 73, 20, 10, 1, 2500 };

foreach(var num in elements)
{
    set1.Add(num);
    set2.Add(num);
    if(!insertionOrder.Contains(num))
        insertionOrder.AddLast(num);
}

Console.WriteLine("HashSet: " + string.Join(", ", set1));
Console.WriteLine("SortedSet: " + string.Join(", ", set2));
Console.WriteLine("Insertion Order: " + string.Join(", ", insertionOrder));


// === Maps ===

Dictionary<string, int> map1 = new Dictionary<string, int>(); // Like HashMap
SortedDictionary<string, int> map2 = new SortedDictionary<string, int>(); // Like TreeMap
var map3 = new LinkedList<KeyValuePair<string, int>>(); // Like LinkedHashMap


// === Student Sorting ===

List<Student> students = new List<Student>
{
    new Student("Alice", 20, 3, "A"),
    new Student("Bob", 22, 1, "B"),
    new Student("Charlie", 21, 2, "C"),
    new Student("David", 23, 4, "D"),
    new Student("Eve", 19, 5, "E")
};

students.Sort(); // Sort by RollNo using IComparable

Console.WriteLine("\nSorted Students by RollNo:");
foreach (var student in students)
{
    Console.WriteLine(student);
}


students.Sort(new StudentAgeComparer()); // Sort by Age using IComparer
Console.WriteLine("\nSorted Students by Age:");
foreach (var student in students)
{
    Console.WriteLine(student);
}

// Priority Queue with Student Object
PriorityQueue<Student, int> studentQueue = new PriorityQueue<Student, int>();
studentQueue.Enqueue(new Student("Rajneesh", 23, 5, "LLD Evening Batch"), 23);
studentQueue.Enqueue(new Student("Deepak", 28, 10, "Non DSA Batch"), 28);
studentQueue.Enqueue(new Student("Sandhya", 24, 2, "Project Evening Batch"), 24);
studentQueue.Enqueue(new Student("Irfan", 20, 15, "Scaler"), 20);
studentQueue.Enqueue(new Student("Apurv", 25, 1, "LLD"), 25);

Console.WriteLine("\nPriority Queue of Students (by Age):");
// Dequeueing students in order of increasing age (lower age = higher priority)
while (studentQueue.Count > 0)
{
    var student = studentQueue.Dequeue();
    Console.WriteLine(student);
}