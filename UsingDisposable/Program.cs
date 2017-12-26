using System;

namespace UsingDisposable
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Case 1:");
            Console.WriteLine("================================");
            using (var outer = new MyResource("Outer"))
            {
                var inner = new MyResource("Inner");
                Console.WriteLine("In Using");
            }
            Console.WriteLine("================================");
            Console.WriteLine();
            Console.WriteLine("Case 2:");
            Console.WriteLine("================================");
            using (var outer = new MyResource("Outer"))
            {
                using (var inner = new MyResource("Inner"))
                {
                    Console.WriteLine("In Using");
                }
            }
            Console.WriteLine("================================");


            Console.ReadLine();
        }
    }

    public class MyResource : IDisposable
    {
        public string Name { get; set; }
        // The class constructor.
        public MyResource(string name)
        {
            Name = name;
            Console.WriteLine($"Constructor: {Name}");
        }

        ~MyResource()
        {
            Console.WriteLine($"Destructor: {Name}");
        }

        public void Dispose()
        {
            Console.WriteLine($"Dispose: {Name}");
        }
    }
}
