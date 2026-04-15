using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIDemo
{
    internal class D4
    {
        public static void Run()
        {
            Console.WriteLine("#2499 D4");
            Car c = new Car("BMW", "X5", "2020");
            c.Multiple();
        }
       
    }
    public class Car
    {
        public string Brand;
        public string Model;
        public string Year;

        public Car(string Brand, string Model, string Year)
        {
            this.Brand = Brand;
            this.Model = Model;
            this.Year = Year;
        }

        public void Multiple()
        {
            Console.WriteLine($"Brand: {Brand}, Model: {Model}, Year: {Year}");
        }
    }
}
