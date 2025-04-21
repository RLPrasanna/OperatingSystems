using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamsAndLambda
{
    internal class Student
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
        public override string ToString()
        {
            return $"Name: {Name}, Age: {Age}, RollNo: {RollNo}, Batch: {Batch}";
        }
    }
}
