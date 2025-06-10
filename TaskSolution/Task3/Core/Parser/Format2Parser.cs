using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task3.Core.Interfaces;
using Task3.Core.Models;

namespace Task3.Core.Parser
{
    /// <summary>
    /// Парсер для второго формата логов
    /// </summary>
    public class Format2Parser : ILogParser
    {
        public bool TryParse(string line, out LogEntry logEntry)
        {
            logEntry = null;
            if (string.IsNullOrWhiteSpace(line)) return false;

            var parts = line.Split('|');
            if (parts.Length < 5) return false;

            try
            {
                if (!DateTime.TryParse(parts[0].Trim(), out var dateTime))
                    return false;

                logEntry = new LogEntry
                {
                    Date = dateTime,
                    Time = dateTime.ToString("HH:mm:ss.ffff").TrimEnd('0').TrimEnd('.'),
                    LogLevel = NormalizeLogLevel(parts[1].Trim()),
                    CallingMethod = parts[3].Trim(),
                    Message = parts[4].Trim()
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
