using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIDemo
{
    internal class D3
    {
        public static void Run()
        {
            Console.WriteLine("#2498 D3");
            //Console.WriteLine("enter number:");
            //int n = Convert.ToInt32(Console.ReadLine());
            //for (int i = 1; i <= 10; i++)
            //{
            //    Console.WriteLine(n + "*" + i + "=" + (n * i));
            //}

            //int[] array = { 1, 2, 3 };
            //int sum = 0;
            //for (int i = 0; i < array.Length; i++)
            //{
            //    sum += array[i];
            //    Console.WriteLine(array[i]);
            //}
            //Console.WriteLine("Sum: " + sum);

            //long answer = Factorial(5);
            //Console.WriteLine("Factorial of 5 is: " + answer);
            Console.WriteLine("Method Overloading");

            demo d = new demo();
            Console.WriteLine($"int: {d.Add(1, 2)}");
            Console.WriteLine($"double: {d.Add(14.34, 4.24)}");

        }

        //public static long Factorial(int n)
        //{
        //    long result = 1;
        //    for (int i = 1; i <= n; i++)
        //    {
        //        result = result * i;
        //    }
        //    return result;
        //}
        
    }

}

public class demo
{

    public int Add(int a, int b)
    {
        return a + b;
    }

    public double Add(double a, double b)
    {
        return a + b;
    }

}