using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collections
{
    internal class StudentAgeRollNoCustomComparer : IComparer<Student>
    {
        // Custom comparison logic based on a weighted average of Age (60%) and RollNo(40%
        public int Compare(Student x, Student y)
        {
            int points1=(int)((0.6*x.Age)+(0.4*x.RollNo));
            int points2=(int)((0.6*y.Age)+(0.4*y.RollNo));
            return points1 - points2;
        }
    }
}
