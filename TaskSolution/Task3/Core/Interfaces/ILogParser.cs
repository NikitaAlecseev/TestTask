using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task3.Core.Models;

namespace Task3.Core.Interfaces
{
    /// <summary>
    /// Интерфейс для парсера логов 
    /// </summary>
    public interface ILogParser
    {
        bool TryParse(string line, out LogEntry logEntry);
    }
}
