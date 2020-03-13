using System;

namespace GuidCreater
{
    class Program
    {
        static void Main(string[] args)
        {
            do
            {
                for(int i = 0; i < 10; i++)
                {
                    Console.WriteLine(string.Format($"\rGuid.Parse(\"{Guid.NewGuid().ToString()}\")"));
                }
                System.Console.WriteLine("-----> Enter 0 exit <-----");
            }while(Console.ReadKey().KeyChar != '0');
        }
    }
}
