using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProducerConsumerWithLock
{
    internal class Consumer
    {
        private readonly Queue<object> _queue;
        private readonly string _name;

        public Consumer(Queue<object> queue, string name)
        {
            _queue = queue;
            _name = name;
        }

        public void Run()
        {
            while (true)
            {
                lock (_queue)
                {
                    if (_queue.Count > 0)
                    {
                        var item = _queue.Dequeue();
                        Console.WriteLine($"{_name} consumed an item. Queue size: {_queue.Count}");
                    }
                }
            }
        }
    }
}
