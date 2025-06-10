using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task3.Core.Interfaces;
using Task3.Core.Models;

namespace Task3.Core.Parser
{
    /// <summary>
    /// Парсер для первого формата логов
    /// </summary>
    public class Format1Parser : ILogParser
    {
        public bool TryParse(string line, out LogEntry logEntry)
        {
            logEntry = null;
            if (string.IsNullOrWhiteSpace(line)) return false;

            var parts = line.Split(new[] { ' ' }, 4, StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length < 4) return false;

            try
            {
                var dateTimeStr = $"{parts[0]} {parts[1]}";
                if (!DateTime.TryParse(dateTimeStr, CultureInfo.GetCultureInfo("ru-RU"), DateTimeStyles.None, out var dateTime))
                    return false;

                logEntry = new LogEntry
                {
                    Date = dateTime,
                    Time = parts[1],
                    LogLevel = NormalizeLogLevel(parts[2]),
                    CallingMethod = "DEFAULT",
                    Message = parts[3]
                };
                return true;
            }
            catch
            {
                return false;
            }
        }

        private string NormalizeLogLevel(string level)
        {
            switch (level.ToUpper())
            {
                case "INFORMATION":
                    return "INFO";
                case "WARNING":
                    return "WARN";
                default:
                    return level.ToUpper();
            }
        }
    }
}
