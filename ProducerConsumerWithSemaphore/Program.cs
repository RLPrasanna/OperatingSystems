// See https://aka.ms/new-console-template for more information

using ProducerConsumerWithSemaphore;

Queue<object> queue = new Queue<object>();
int maxSize = 6;
Semaphore producerSemaphore =new Semaphore(maxSize, maxSize);
Semaphore consumerSemaphore = new Semaphore(0, maxSize);

for (int i=0;i <= 6; i++)
{
    var producer = new Producer(queue, $"Producer{i}", maxSize, producerSemaphore, consumerSemaphore);
    new Thread(producer.Run).Start();
} 

for(int i = 1; i <= 4; i++)
{
    var consumer = new Consumer(queue, $"Consumer{i}", producerSemaphore, consumerSemaphore);
    new Thread(consumer.Run).Start();
}