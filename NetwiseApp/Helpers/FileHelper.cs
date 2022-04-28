using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetwiseApp.Helpers
{
    public class FileHelper
    {
        private string _filePath;

        public FileHelper(string filePath)
        {
            _filePath = filePath;
        }

        public void WriteToFile()
        {
            StringBuilder stringbuilder = new StringBuilder();
            for (int i = 1; i < 10; i++)
            {
                stringbuilder.Append("Some line of text");
            }
            File.AppendAllText(Path, stringbuilder.ToString());
        }
    }
}
