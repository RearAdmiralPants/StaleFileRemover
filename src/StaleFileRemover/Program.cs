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
        }
    }
}
