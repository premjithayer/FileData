using System;
using FileData.Repositories;
using NLog;

namespace FileData
{
    public static class Program
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        public static void Main(string[] args)
        {
            try
            {
                var result = new FileCheckerImplementation(new FileChecker()).Check(args);

                switch (result)
                {
                    case string _:
                        Console.WriteLine($"File Version is: {result}");
                        break;
                    case int _:
                        Console.WriteLine($"File Size is: {result}");
                        break;
                    default:
                        Console.WriteLine("Invalid data type returned.");
                        Logger.Error($"Invalid data type of {result.GetType()}");
                        break;
                }
            }
            catch (Exception exception)
            {
                Logger.Error(exception);
            }

            Console.ReadKey();
        }
    }
}
