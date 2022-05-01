using System;
using System.IO;
using System.Text;

namespace NetwiseApp.Services
{
    public interface IFileService
    {
        void SaveMessageToFile(string message, string path);
    }
    public class FileService : IFileService
    {
        public void SaveMessageToFile(string message, string path)
        {
            StringBuilder stringbuilder = new StringBuilder();
            stringbuilder.Append(message);
            File.AppendAllText(path, stringbuilder.ToString() + Environment.NewLine);
        }
    }
}
