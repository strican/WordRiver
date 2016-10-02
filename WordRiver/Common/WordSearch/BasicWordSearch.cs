using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using WordRiver.Models;

namespace WordRiver.Common
{
    class BasicWordSearch : IWordSearch
    {
        public string FindNextWord(IGameDictionary dictionary, string previous)
        {
            List<string> nextOptions = new List<string>();

            for (int i = 0; i < previous.Length; i++)
            {
                for (char attempt = 'A'; attempt <= 'Z'; attempt++)
                {
                    StringBuilder next = new StringBuilder(previous);
                    next[i] = attempt;

                    string nextOption = next.ToString();
                    if (dictionary.IsValidWord(nextOption) == ResponseType.Success)
                    {
                        nextOptions.Add(nextOption);
                    }
                }
            }

            string nextWord = null;
            if (nextOptions.Count > 0)
            {
                Random rand = new Random();
                nextWord = nextOptions[rand.Next(nextOptions.Count)];
            }
            return nextWord;
        }
    }
}
