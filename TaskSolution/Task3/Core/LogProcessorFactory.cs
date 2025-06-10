using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task3.Core.Helper;
using Task3.Core.Interfaces;
using Task3.Core.Parser;

namespace Task3.Core
{
    /// <summary>
    /// Фабрика для создания обработчика файлов
    /// </summary>
    public static class LogProcessorFactory
    {
        public static IFileProcessor CreateFileProcessor()
        {
            var parsers = new List<ILogParser> { new Format1Parser(), new Format2Parser() };
            var formatter = new StandardLogFormatter();
            return new LogFileProcessor(parsers, formatter);
        }
    }
}
