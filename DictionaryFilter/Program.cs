using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DictionaryFilter
{
    class IOPair
    {
        public string InputPath;
        public string OutputPath;

        public IOPair(string input, string output)
        {
            InputPath = input;
            OutputPath = output;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<IOPair> dictionaries = new List<IOPair>();
            dictionaries.Add(new IOPair("dictionary.txt", "WordRiverDict.txt"));
            dictionaries.Add(new IOPair("dictionary_test.txt", "WordRiverDictTest.txt"));

            foreach (var dict in dictionaries)
            {
                string currentDir = System.IO.Directory.GetCurrentDirectory();
                using (StreamWriter writer = new StreamWriter(currentDir + "\\" + dict.OutputPath))
                {
                    using (StreamReader reader = new StreamReader(currentDir + "\\" + dict.InputPath))
                    {
                        string line;
                        while ((line = reader.ReadLine()) != null)
                        {
                            // Check the contents of the line and write it to our
                            // final dictionary if it meets the requirements:
                            //   1. 4 letters lonng
                            //   2. Not a proper noun
                            if (line.Length == 4 && char.IsLower(line[0]) && !line.Contains('\''))
                            {
                                writer.WriteLine(line);
                            }
                        }
                    }
                }
            }
        }
    }
}
