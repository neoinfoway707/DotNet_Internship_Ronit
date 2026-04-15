using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIDemo
{
    internal class D6
    {
        public static void Run()
        {
            Console.WriteLine("#2501 D6");
            D6.run();
        }
        class Animal
        {
            public string name;
            public void demo() {
                Console.WriteLine("animal");
            }
            public virtual void AnimalSound() {
                Console.WriteLine("Animal sound");
            }
        }
        class Dog : Animal
        {
            public int Age = 12;
            public override void AnimalSound()
            {
                Console.WriteLine("Woof");
            }
        }
        class Cat : Animal
        {
            public override void AnimalSound()
            {
                Console.WriteLine("Meow");
            }
        }

        public static void run()
        {
            Dog d = new Dog();
            d.demo();

            Animal a = new Animal();
            Animal mydog = new Dog();
            Animal mycat = new Cat();
            string name = "DAWGG";
            d.name = name;
            Console.WriteLine($"Name: {d.name}, Age: {d.Age}");
            a.AnimalSound();
            mydog.AnimalSound();
            mycat.AnimalSound();
        }

    }
}
