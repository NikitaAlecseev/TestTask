using System;
using Task3.Core;

namespace Task3
{
    internal class Program
    {
        static void Main(string[] args)
        {

            // Устанавливаем значения параметров
            string inputPath = Environment.CurrentDirectory + "\\input.log";
            string outputPath = Environment.CurrentDirectory + "\\output.log";
            string problemsPath = Environment.CurrentDirectory + "\\problem.log";

            try
            {
                var processor = LogProcessorFactory.CreateFileProcessor();
                processor.ProcessFile(inputPath, outputPath, problemsPath);
                Console.WriteLine($"Processing completed. Results saved to {outputPath}, problems to {problemsPath}");

                Console.Read();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
