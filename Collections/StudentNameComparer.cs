using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collections
{
    internal class StudentNameComparer : IComparer<Student>
    {
        public int Compare(Student x, Student y)
        {
            // Compare the names of the students
            return string.Compare(x.Name, y.Name, StringComparison.OrdinalIgnoreCase);
        }
    }
}
