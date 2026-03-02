using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarbageCollection
{
    namespace DisposableDemo
    {
        public class FileManager : IDisposable
        {
            private FileStream _fileStream;
            private bool _disposed = false;

            public void OpenFile(string path)
            {
                _fileStream = new FileStream(path, FileMode.OpenOrCreate);
                Console.WriteLine("File opened");
            }

            public void Dispose()
            {
                Dispose(true);
                GC.SuppressFinalize(this);
            }

            protected virtual void Dispose(bool disposing)
            {
                if (_disposed) return;

                if (disposing)
                {
                    _fileStream?.Dispose();
                    Console.WriteLine("Managed resources disposed");
                }

                Console.WriteLine("Unmanaged resources cleaned");

                _disposed = true;
            }

            ~FileManager()
            {
                Dispose(false);
            }
        }

    }
}