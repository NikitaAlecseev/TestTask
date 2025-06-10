using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task3.Core.Parser;

namespace UnitTestTask3
{
    [NUnit.Framework.TestFixture]
    public class LogParserTests
    {
        [NUnit.Framework.Test]
        public void Format1Parser_CorrectInput_ParsesSuccessfully()
        {
            var parser = new Format1Parser();
            var result = parser.TryParse("10.03.2025 15:14:49.523 INFORMATION Сообщение", out var logEntry);

            Assert.IsTrue(result);
            Assert.AreEqual("10-03-2025", logEntry.Date.ToString("dd-MM-yyyy"));
            Assert.AreEqual("15:14:49.523", logEntry.Time);
            Assert.AreEqual("INFO", logEntry.LogLevel);
            Assert.AreEqual("DEFAULT", logEntry.CallingMethod);
            Assert.AreEqual("Сообщение", logEntry.Message);
        }

        [NUnit.Framework.Test]
        public void Format2Parser_CorrectInput_ParsesSuccessfully()
        {
            var parser = new Format2Parser();
            var result = parser.TryParse("2025-03-10 15:14:51.5882|INFO|11|Method|Сообщение", out var logEntry);

            Assert.IsTrue(result);
            Assert.AreEqual("10-03-2025", logEntry.Date.ToString("dd-MM-yyyy"));
            Assert.AreEqual("15:14:51.5882", logEntry.Time);
            Assert.AreEqual("INFO", logEntry.LogLevel);
            Assert.AreEqual("Method", logEntry.CallingMethod);
            Assert.AreEqual("Сообщение", logEntry.Message);
        }
    }
}
