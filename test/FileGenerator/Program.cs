namespace FileGenerator
{
    using FileGenerator.Managers;

    using System;

    class Program
    {
        static void Main(string[] args)
        {
            var fileManager = new FileGenerator();
            fileManager.TargetPath = "C:\\Test\\TestStaleDirectory";
            fileManager.FilePadding = (byte)'a';
            fileManager.GenerationPeriodSeconds = 5;
            fileManager.MinimumFileSize = 25000;
            fileManager.MaximumFileSize = 65535;

            fileManager.Start();

            Console.WriteLine("File Manager started at " + fileManager.TargetPath);

            var read = Console.Read();
            while (read == -1) {
                System.Threading.Thread.Sleep(1000);
            }
            
            fileManager.Stop();

            Console.WriteLine("Stopped.");
            Console.ReadKey();

        }
    }
}
