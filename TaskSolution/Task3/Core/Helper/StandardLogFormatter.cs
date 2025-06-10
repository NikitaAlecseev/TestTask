using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task3.Core.Interfaces;
using Task3.Core.Models;

namespace Task3.Core.Helper
{
    /// <summary>
    /// Форматер для выходного формата логов
    /// </summary>
    public class StandardLogFormatter : ILogFormatter
    {
        public string Format(LogEntry logEntry)
        {
            return $"{logEntry.Date:dd-MM-yyyy}\t{logEntry.Time}\t{logEntry.LogLevel}\t{logEntry.CallingMethod}\t{logEntry.Message}";
        }
    }
}
