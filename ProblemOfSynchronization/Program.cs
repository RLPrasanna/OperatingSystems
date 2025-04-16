// See https://aka.ms/new-console-template for more information
using ProblemOfSynchronization;

Count count = new Count();
Adder adder = new Adder(count);
Subtractor subtractor = new Subtractor(count);

Thread t1 = new Thread(new ThreadStart(adder.Run));
Thread t2 = new Thread(new ThreadStart(subtractor.Run));

t1.Start();
t2.Start();

t1.Join();
t2.Join();

Console.WriteLine("Final count: " + count.Value);
