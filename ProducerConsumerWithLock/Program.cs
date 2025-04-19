// See https://aka.ms/new-console-template for more information


/// <summary>
/// This is solving the problem of synchronization between producer and consumer but is making the code sequential.
/// It is allowing only one producer to be present inside the store at a time and only one consumer to be present in store at a time.
/// </summary>
using ProducerConsumerWithLock;

Queue<object> queue=new Queue<object>();
int maxSize = 6;

for(int i = 0; i <=6; i++)
{
    var producer = new Producer(queue, maxSize, $"Producer{i}");
    new Thread(producer.Run).Start();
}

for(int i=1; i <= 4; i++)
{
    var consumer = new Consumer(queue, $"Consumer{i}");
    new Thread(consumer.Run).Start();
}