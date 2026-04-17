using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIDemo
{
    internal class D5
    {
        public static void Run()
        {
            Console.WriteLine("#2500 D5");
            ConstructorDemo.run();
        }
    }

    public class ConstructorDemo
    {
        public class Person
        {
            private int age;
            public int Age
            { 
                get {return age;}
                set {age = value;}
            }
        }
        public static void run() { 
            Person person = new Person();
            person.Age = 30;
            Console.WriteLine(person.Age);
        }
    }
}
