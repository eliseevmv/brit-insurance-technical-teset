using Core.Persistence;
using System.Collections.Generic;

namespace UnitTests
{
    class FileReaderStub : IFileReader
    {
        private IEnumerable<string> lines;

        public FileReaderStub(IEnumerable<string> lines)
        {
            this.lines = lines;
        }

        public IEnumerable<string> ReadLines()
        {
            return lines;
        }
    }
}
