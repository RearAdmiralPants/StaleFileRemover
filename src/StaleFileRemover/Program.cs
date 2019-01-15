using System;

namespace StaleFileRemover
{
    using Helpers;
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var monitor = new DirectoryMonitor();
            monitor.Path = "C:\\src\\";

            Console.WriteLine("Directory monitoring " + monitor.Path);

            Console.ReadKey();

            var provider = new Providers.ConfigurationProvider();

            Console.WriteLine("Initialized config provider.");

            var config = new Abstractions.AppConfiguration();

            Console.WriteLine("Initialized app config abstraction");

            Console.ReadKey();

            var dir = "C:\\src";
            var filename = "testFile.txt";

            Console.WriteLine(System.IO.Path.Combine(dir, filename));
            Console.ReadKey();
        }
    }
}
