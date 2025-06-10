using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3.Core.Interfaces
{
    /// <summary>
    /// Интерфейс для обработчика файлов
    /// </summary>
    public interface IFileProcessor
    {
        void ProcessFile(string inputPath, string outputPath, string problemsPath);
    }
}
