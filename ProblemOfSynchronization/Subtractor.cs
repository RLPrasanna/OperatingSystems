using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemOfSynchronization
{
    internal class Subtractor
    {
        private Count _count;

        public Subtractor(Count count)
        {
            _count = count;
        }

        public void Run()
        {
            for (int i = 0; i < 1000; i++)
            {
                _count.Value-=i;
            }
        }
    }
}
