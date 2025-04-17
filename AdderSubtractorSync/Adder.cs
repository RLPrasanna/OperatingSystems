using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdderSubtractorSync
{
    internal class Adder
    {
        private Count _count;
        private object _lock;
        public Adder(Count count, object lockObj)
        {
            _count = count;
            _lock = lockObj;
        }
        public void Run()
        {
            for (int i = 0; i < 100000; i++)
            {
                lock (_lock)
                {
                    // critical section
                    _count.Value += i;
                }
            }
        }
    }
}
