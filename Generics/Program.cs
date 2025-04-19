// See https://aka.ms/new-console-template for more information

using Generics;
using System.Collections;

// Create Pair instances with different data types
Pair<double, double> pair = new Pair<double, double>();
pair.First = 1.0;
pair.Second = 2.0;


Pair<string, string> pair2 = new();
pair2.First = "Hello";
pair2.Second = "World";


Pair<string, string> pair3 = new("Hello", "World");


var pair4 = new Pair<object, object>();
pair4.First = "Scaler";
pair4.Second = 3.45678;
//string value = (string)pair4.Second; // ❌ May cause runtime error if wrong cast


// Collection examples
var list = new List<int>();
var pairs = new List<Pair<double, double>>();


//Hashtable equivalent to raw HashMap
Hashtable hashMap = new Hashtable();
hashMap[10] = 20;
hashMap["Scaler"] = "Bangalore";


// Static method calls on generic class
Pair<string, string>.doSomething("Hello");
Pair<object, object>.doSomething(10);

string str = Pair<object, object>.doSomething2("Hello", 10);
string str2 = Pair<object, object>.doSomething3("Hello", "World");
Console.WriteLine(str);
Console.WriteLine(str2);


var pair5 = new Pair<int, int> { First = 10, Second = 20 };
var avg = findAvg(pair5);
Console.WriteLine($"Average: {avg}");

var pair6 = new Pair<string, string>{ First ="Scaler", Second = "Bangalore" };
//var avg2 = findAvg(pair6); // ❌ This will cause a compile-time error


// Upper bounded wildcard behavior (works with Animal or subclass)
Pair<object, object>.doSomething4(new Dog());
Pair<object, object>.doSomething4(new Animal());


// Lower bounded wildcard (not supported in C#)
// Pair<object, object>.doSomething4(new object()); // ❌ Not allowed in C#


// Covariance-like usage with interfaces
List<Dog> dogs = new List<Dog> { new Dog()};
Pair<object, object>.doSomething5(dogs);



// Generic method to calculate average of two numbers
//where T : struct, IConvertible is the C# way to constrain generics to value types (like int, double, etc.) and ensure they can be converted to double
static double findAvg<T1, T2>(Pair<T1, T2> pair) where T1 : struct, IConvertible where T2 : struct, IConvertible
{
    double first = Convert.ToDouble(pair.First);
    double second = Convert.ToDouble(pair.Second);
    return (first + second) / 2;
}