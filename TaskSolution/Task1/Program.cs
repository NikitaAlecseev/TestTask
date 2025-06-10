using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string original = "aaabbcccdde";
            Console.WriteLine($"Исходная строка: {original}");

            string compressed = StringCompressor.Compress(original);
            Console.WriteLine($"Сжатая строка: {compressed}");

            string decompressed = StringCompressor.Decompress(compressed);
            Console.WriteLine($"Восстановленная строка: {decompressed}");

            Console.Read();
        }
    }
}
