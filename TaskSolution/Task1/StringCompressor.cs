using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    public class StringCompressor
    {
        // Метод для компрессии строки
        public static string Compress(string input)
        {
            if (string.IsNullOrEmpty(input))
                return input;

            StringBuilder compressed = new StringBuilder();
            char currentChar = input[0];
            int count = 1;

            for (int i = 1; i < input.Length; i++)
            {
                if (input[i] == currentChar)
                {
                    count++;
                }
                else
                {
                    compressed.Append(currentChar);
                    if (count > 1)
                        compressed.Append(count);

                    currentChar = input[i];
                    count = 1;
                }
            }

            // Добавляем последнюю группу символов
            compressed.Append(currentChar);
            if (count > 1)
                compressed.Append(count);

            return compressed.ToString();
        }

        // Метод для декомпрессии строки
        public static string Decompress(string compressed)
        {
            if (string.IsNullOrEmpty(compressed))
                return compressed;

            StringBuilder decompressed = new StringBuilder();
            int i = 0;

            while (i < compressed.Length)
            {
                char currentChar = compressed[i++];
                decompressed.Append(currentChar);

                // Извлекаем число, если оно есть
                int numStart = i;
                while (i < compressed.Length && char.IsDigit(compressed[i]))
                {
                    i++;
                }

                if (numStart < i)
                {
                    int count = int.Parse(compressed.Substring(numStart, i - numStart));
                    decompressed.Append(new string(currentChar, count - 1));
                }
            }

            return decompressed.ToString();
        }
    }
}
