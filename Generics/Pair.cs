using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics
{
    internal class Pair<V, S>
    {
        private V first;
        private S second;

        //Constructor
        public Pair(V first, S second)
        {
            this.first = first;
            this.second = second;
        }
        //Default Constructor
        public Pair()
        {
            this.first = default(V);
            this.second = default(S);
        }
        public V First
        {
            get { return first; }
            set { first = value; }
        }
        public S Second
        {
            get { return second; }
            set { second = value; }
        }

        //Generic Static method  where T : class
        public static void doSomething<T>(T obj)
        {
            Console.WriteLine(obj);
        }

        public static X doSomething2<X, Y>(X attr1, Y attr2) 
        {
            return attr1;
        }

        public static X doSomething3<X>(X attr1, X attr2)
        {
            return attr1;
        }

        //T : Animal -> Animal + any child class of Animal.
        public static void doSomething4<T>(T obj) where T: Animal
        {
            Console.WriteLine(obj);
        }

        public static void doSomething5<T>(List<T> animals) where T : Animal
        {
            Console.WriteLine("List of Animals");
        }
    }
}
