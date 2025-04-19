using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProducerConsumerWithSemaphore
{
    internal class Producer
    {
        private readonly Queue<object> _queue;
        private readonly string _name;
        private readonly int _maxSize;
        private readonly Semaphore _producerSemaphore;
        private readonly Semaphore _consumerSemaphore;

        public Producer(Queue<object> queue, string name, int maxSize, Semaphore producerSemaphore, Semaphore consumerSemaphore)
        {
            _queue = queue;
            _name = name;
            _maxSize = maxSize;
            _producerSemaphore = producerSemaphore;
            _consumerSemaphore = consumerSemaphore;
        }


        /// <summary>
        /// Continuously produces items and adds them to the shared queue.
        /// Ensures thread-safety using a semaphore and a lock, and signals the consumer semaphore when an item is produced.
        /// </summary>
        public void Run()
        {
            while (true)
            {
                _producerSemaphore.WaitOne();
                lock (_queue)
                {
                    if (_queue.Count < _maxSize)
                    {
                        var item = new object();
                        _queue.Enqueue(item);
                        Console.WriteLine($"{_name} produced an item. Queue size: {_queue.Count}");
                    }
                }
                _consumerSemaphore.Release();
            }
        }
    }
}
