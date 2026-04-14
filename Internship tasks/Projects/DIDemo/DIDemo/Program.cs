using DIDemo;
using Microsoft.Extensions.DependencyInjection;

class Program
{
    static void Main(string[] args)
    {
        //// 1. Create a new ServiceCollection (The "Container")
        //var ser = new ServiceCollection();

        //// 2. Register your custom service with a lifetime (Transient, Scoped, or Singleton)
        //ser.AddTransient<IHelloService, HelloService>();

        //// 3. Build the ServiceProvider to resolve dependencies
        //var serPro = ser.BuildServiceProvider();

        //// 4. Resolve and use the service
        //var helloSer = serPro.GetService<IHelloService>();
        //helloSer.SayHello("Ronit");

        
        //D1.Run();
        D2.Run();



    }
}