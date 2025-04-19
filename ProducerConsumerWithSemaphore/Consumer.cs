using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProducerConsumerWithSemaphore
{
    internal class Consumer
    {
        private readonly Queue<object> _queue;
        private readonly string _name;
        private readonly Semaphore _producerSemaphore;
        private readonly Semaphore _consumerSemaphore;

        public Consumer(Queue<object> queue, string name, Semaphore producerSemaphore, Semaphore consumerSemaphore)
        {
            _queue = queue;
            _name = name;
            _producerSemaphore = producerSemaphore;
            _consumerSemaphore = consumerSemaphore;
        }

        /// <summary>
        /// Continuously consumes items and removes them from the shared queue.
        /// Ensures thread-safety using a semaphore and a lock, and signals the producer semaphore when an item is consumed.
        /// </summary>
        /// Note: 
        /// Queue is not thread-safe, so you must use lock(queue) or wrap it in a thread-safe collection
        /// If we use ConcurrentQueue, we don’t need to use lock(queue)
        public void Run()
        {
            while (true)
            {
                _consumerSemaphore.WaitOne();
                lock (_queue)
                {
                    if (_queue.Count > 0)
                    {
                        var item = _queue.Dequeue();
                        Console.WriteLine($"{_name} consumed an item. Queue size: {_queue.Count}");
                    }
                }
                _producerSemaphore.Release();
            }
        }
    }
}
