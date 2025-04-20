using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collections
{
    internal class StudentAgeComparer : IComparer<Student>
    {
        public int Compare(Student x, Student y)
        {
            if (x.Age < y.Age)
            {
                return -1;
            }
            else if (x.Age > y.Age)
            {
                return 1;
            }
            return 0;
            //return y.Age - x.Age; // Descending order
        }
    }
}
