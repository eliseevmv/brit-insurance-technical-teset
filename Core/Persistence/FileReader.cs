using System.Collections.Generic;
using System.IO;

namespace Core.Persistence
{
    public interface IFileReader
    {
        IEnumerable<string> ReadLines();
    }

    public class FileReader : IFileReader
    {
        private string filePath;

        public FileReader(string filePath)
        {
            this.filePath = filePath;
        }

        public IEnumerable<string> ReadLines()
        {
            return File.ReadLines(filePath);
        }
    }
}
