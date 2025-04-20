using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collections
{
    internal class Student : IComparable<Student>
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public int RollNo { get; set; }
        public string Batch { get; set; }

        public Student(string name, int age, int rollNo, string batch)
        {
            Name = name;
            Age = age;
            RollNo = rollNo;
            Batch = batch;
        }

        // If compareTo returns -ve value, then this object is smaller than 'other' object.
        // If compareTo returns 0, then this object is equal to 'other' object.
        // If compareTo returns +ve value, then this object is greater than 'other' object.
        public int CompareTo(Student other)
        {
            //if (this.RollNo < other.RollNo)
            //{
            //    return -1;
            //}
            //else if (this.RollNo > other.RollNo)
            //{
            //    return 1;
            //}
            //return 0;
            return this.RollNo - other.RollNo;
        }

        public override string ToString()
        {
            return $"Name: {Name}, Age: {Age}, RollNo: {RollNo}, Batch: {Batch}";
        }
    }
}
