using System;
using System.Threading;
using System.Threading.Tasks;

namespace Task1
{
    class Program
    {
        static string input;
        static object locker = new object();

        static void Main(string[] args)
        {
            input = Console.ReadLine();
            Task.Run(() => PrintAsync());

            while (true)
            {
                if (Console.ReadLine() == "")
                {
                    lock (locker)
                    {
                        input = Console.ReadLine();
                    }
                }
            }
        }

        private static async Task PrintAsync()
        {
            while (true)
            {
                lock (locker)
                {
                    Console.WriteLine(input);
                }
                await Task.Delay(1000);
            }
        }
    }
}
