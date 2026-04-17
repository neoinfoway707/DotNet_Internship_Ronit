using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIDemo
{
    internal class D7
    {
        public static void Run()
        {
            Console.WriteLine("#2502 D7");
            //Circle c = new Circle();
            //c.GetArea();
            //c.aa();
            D7.Lists();
            D7.Student();
            D7.Dictionarys();

        }
        public static void Student()
        {
            string[] studentName = { "ronit", "jay", "meet", "mihir", "demo" };
            Console.WriteLine(studentName[0]);
        }
        public static void Lists()
        {
            List<int> mark = new List<int>();
            mark.Add(67);
            mark.Add(89);
            mark.Add(50);
            mark.Add(99);

            //Console.WriteLine(mark.Capacity);
            //Console.WriteLine(mark.Count);

            foreach (int s in mark)
            {
                Console.WriteLine(s);
            }
            double average = mark.Average();
            Console.WriteLine("Average: " + average);
        }

        public static void Dictionarys()
        {
            Dictionary<string, int> dict = new Dictionary<string, int>();
            dict.Add("ronit", 98);
            dict.Add("jayjay", 80);
            dict.Add("meet", 72);
            dict.Add("mihir", 86);
            dict.Add("demo", 91);
            foreach (var s in dict)
            {
                Console.WriteLine(s);
            }
        }
        abstract class Shape
        {
            public abstract void GetArea();
            public void aa() { 
                int a = 10 * 10;
                Console.WriteLine(a);
            }
        }
        class Circle : Shape
        {
            public override void GetArea()
            {
                double r = 10;
                double area = Math.PI * r * r;
                Console.WriteLine($"Area of Circle: {area}");
            }
        }
    }
}
