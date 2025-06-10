using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task3.Core.Interfaces;

namespace Task3.Core
{
    /// <summary>
    /// Обработчик файлов
    /// </summary>
    public class LogFileProcessor : IFileProcessor
    {
        private readonly IEnumerable<ILogParser> _parsers;
        private readonly ILogFormatter _formatter;

        public LogFileProcessor(IEnumerable<ILogParser> parsers, ILogFormatter formatter)
        {
            _parsers = parsers;
            _formatter = formatter;
        }

        public void ProcessFile(string inputPath, string outputPath, string problemsPath)
        {
            using (var outputWriter = new StreamWriter(outputPath))
            {
                using (var problemsWriter = new StreamWriter(problemsPath))
                {
                    foreach (var line in File.ReadLines(inputPath))
                    {
                        if (string.IsNullOrWhiteSpace(line)) continue;

                        bool parsed = false;
                        foreach (var parser in _parsers)
                        {
                            if (parser.TryParse(line, out var logEntry))
                            {
                                outputWriter.WriteLine(_formatter.Format(logEntry));
                                parsed = true;
                                break;
                            }
                        }

                        if (!parsed)
                        {
                            problemsWriter.WriteLine(line);
                        }
                    }
                }
            }
        }
    }
}
