using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Демонстрация работы с сервером
            Console.WriteLine($"Initial count: {Server.GetCount()}");

            // Параллельные чтения
            Parallel.For(0, 5, i => {
                Console.WriteLine($"Reader {i} sees: {Server.GetCount()}");
            });

            // Последовательные записи
            Parallel.For(0, 3, i => {
                Server.AddToCount(i + 1);
                Console.WriteLine($"Writer {i} added {i + 1}");
            });

            Console.WriteLine($"Final count: {Server.GetCount()}");

            Console.Read();
        }
    }
}
