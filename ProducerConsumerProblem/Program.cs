// See https://aka.ms/new-console-template for more information

using ProducerConsumerProblem;

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