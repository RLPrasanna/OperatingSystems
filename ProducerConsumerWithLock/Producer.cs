using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProducerConsumerWithLock
{
    internal class Producer
    {
        private readonly Queue<object> _queue;
        private readonly string _name;
        private readonly int _maxSize;

        public Producer(Queue<object> queue, int maxSize, string name)
        {
            _queue = queue;
            _maxSize = maxSize;
            _name = name;
        }

        public void Run()
        {
            while (true)
            {
                lock (_queue)
                {
                    if (_queue.Count < _maxSize)
                    {
                        var item = new object();
                        _queue.Enqueue(item);
                        Console.WriteLine($"{_name} produced an item. Queue size: {_queue.Count}");
                    }
                }       
            }
        }
    }
}
