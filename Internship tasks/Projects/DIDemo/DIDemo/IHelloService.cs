using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIDemo
{
    public interface IHelloService
    {
        void SayHello(string name);
    }
    public class HelloService : IHelloService
    {
        public void SayHello(string name)
        {
            Console.WriteLine($"Hello, {name} from custom DI!");
        }
    }
}
