using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DictionaryFilter
{
    class Program
    {
        static void Main(string[] args)
        {
            string currentDir = System.IO.Directory.GetCurrentDirectory();
            using (StreamWriter writer = new StreamWriter(currentDir + "\\WordRiverDict.txt"))
            {
                using (StreamReader reader = new StreamReader(currentDir + "\\dictionary.txt"))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        // Check the contents of the line and write it to our
                        // final dictionary if it meets the requirements:
                        //   1. 4 letters lonng
                        //   2. Not a proper noun
                        if (line.Length == 4 && char.IsLower(line[0]))
                        {
                            writer.WriteLine(line);
                        }
                    }
                }
            }
        }
    }
}
