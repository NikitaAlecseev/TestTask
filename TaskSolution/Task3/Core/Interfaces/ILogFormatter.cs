using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task3.Core.Models;

namespace Task3.Core.Interfaces
{
    /// <summary>
    /// Интерфейс для форматера логов
    /// </summary>
    public interface ILogFormatter
    {
        string Format(LogEntry logEntry);
    }
}
