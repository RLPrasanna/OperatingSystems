// See https://aka.ms/new-console-template for more information
using AdderSubtractorSync;

Count count = new Count();
object lockObj = new object();

Adder adder = new Adder(count,lockObj);
Subtractor subtractor = new Subtractor(count, lockObj);

Thread t1 = new Thread(new ThreadStart(adder.Run));
Thread t2 = new Thread(new ThreadStart(subtractor.Run));

t1.Start();
t2.Start();

t1.Join();
t2.Join();

Console.WriteLine("Final count: " + count.Value);
