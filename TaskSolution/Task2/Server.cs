using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Task2
{
    public static class Server
    {
        private static int _count = 0;
        private static readonly ReaderWriterLockSlim _lock = new ReaderWriterLockSlim();


        public static int GetCount()
        {
            try
            {
                _lock.EnterReadLock(); // Множественные читатели могут зайти одновременно
                return _count;
            }
            finally
            {
                _lock.ExitReadLock(); // Гарантированное освобождение блокировки
            }
        }

       
        public static void AddToCount(int value)
        {
            try
            {
                _lock.EnterWriteLock(); // Только один писатель может зайти
                _count += value;
            }
            finally
            {
                _lock.ExitWriteLock(); // Гарантированное освобождение блокировки
            }
        }
    }
}
