using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdderSubtractorSync
{
    public class Count
    {
        private int value = 0;
        private readonly object lockObject = new object();

        public int GetValue()
        {
            return value;
        }

        public void IncrementValue(int x)
        {
            lock (lockObject)
            {
                value+=x;
            }
        }
    }
}
