using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace A_WebRequest
{
    internal class OutputFile : IOutput
    {
        public string Path { get; set; }
        public OutputFile(string path)
        {
            Path = path;
        }
        public void Write(string message)
        {
            try
            {
                // Using the 'using' statement ensures the StreamWriter is properly disposed
                using (StreamWriter writer = new StreamWriter(Path, append: false))
                {
                    writer.WriteLine(message);
                }
                Console.WriteLine($"Content written to {Path}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}
