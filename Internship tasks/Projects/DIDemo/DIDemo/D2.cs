using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIDemo
{
    internal class D2
    {
        public static void Run()
        {
            Console.WriteLine("#2497 D2");
            Console.WriteLine("--Strings--");
            Console.Write("Name:");
            string name = Console.ReadLine();

            Console.WriteLine($"Hello, {name}! and its length is {name.Length}\n Uppercase: {name.ToUpper()}\n Lowercase: {name.ToLower()}");
            if (name.Length > 4)
            {
                Console.WriteLine($"First 4 characters: {name.Substring(0, 4)}");
            }
            else
            {
                Console.WriteLine(name);
            }
            int CharPosition = name.IndexOf('n');
            Console.WriteLine(CharPosition);
            string name2 = name.Substring(CharPosition);
            Console.WriteLine(name2);

            Console.WriteLine("--if/else--");
            Console.WriteLine("Enter marks:");
            int marks = int.Parse(Console.ReadLine());
            if (marks >= 40)
            {
                Console.WriteLine("Passed");
                if (marks>=75)
                {
                    Console.WriteLine("A+");
                }
                else if(marks>=60)
                {
                    Console.WriteLine("B+");
                }
                //else
                //{
                //    Console.WriteLine("just passed");
                //}
            }
            else
            {
                               Console.WriteLine("Failed");
            }
            Console.WriteLine("----Switch Case----");
            Console.WriteLine("1. Add two numbers");
            Console.WriteLine("2. Subtract two numbers");
            Console.WriteLine("3. Multiply two numbers");
            Console.WriteLine("4. Divide two numbers");
            Console.Write("Enter your choice (1-4): ");

            int choice = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter first number: ");
            double num1 = Convert.ToDouble(Console.ReadLine());

            Console.Write("Enter second number: ");
            double num2 = Convert.ToDouble(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.WriteLine($"Result: {num1 + num2}");
                    break;
                case 2:
                    Console.WriteLine($"Result: {num1 - num2}");
                    break;
                case 3:
                    Console.WriteLine($"Result: {num1 * num2}");
                    break;
                case 4:
                    if (num2 != 0)
                        Console.WriteLine($"Result: {num1 / num2}");
                    else
                        Console.WriteLine("Error: Division by zero!");
                    break;
                default:
                    Console.WriteLine("Invalid choice!");
                    break;
            }
        }
    }
}
