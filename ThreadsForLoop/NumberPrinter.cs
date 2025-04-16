using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperatingSystems
{
    public class NumberPrinter
    {
        private int number;

        public NumberPrinter(int number)
        {
            this.number = number;
        }

        public void Run()
        {
            if (number == 50)
            {
                Console.WriteLine("Wait");
            }

            Console.WriteLine("The number is " + number);
        }
    }
}
