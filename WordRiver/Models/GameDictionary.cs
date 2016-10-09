using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordRiver.Common;

namespace WordRiver.Models
{
    public class GameDictionary : IGameDictionary
    {
        private Dictionary<string, bool> Words;

        public GameDictionary(Dictionary<string, bool> words)
        {
            Words = words;
        }

        public string GetStartingWord()
        {
#if DEBUG
            // This should be one time call, only at the start of the game
            if (isGameStarted)
            {
                throw new Exception("Shouldn't be calling this once the game has started.");
            }
            isGameStarted = true;
#endif

            return GetRandomWord();
        }

        public ResponseType IsValidWord(string word)
        {
            Debug.Assert(word == word.ToUpper());

            ResponseType response = ResponseType.Error;

            if (!Words.ContainsKey(word))
            {
                response = ResponseType.InvalidWord;
            }
            else if (Words[word])
            {
                response = ResponseType.DuplicateWord;
            }
            else
            {
                response = ResponseType.Success;
            }
            return response;
        }

        public void SelectWord(string word)
        {
            Debug.Assert(word == word.ToUpper());
            Debug.Assert(Words.Keys.Contains(word));
            Debug.Assert(!Words[word]);

            Words[word] = true;
        }

        private string GetRandomWord()
        {
            // Filter the list of keys to only include ones that have
            // not been selected yet
            var keys = Words.Keys.ToList().Where(key => !Words[key]).ToList();
            Random rand = new Random();
            return keys[rand.Next(keys.Count)];
        }

#if DEBUG
        private bool isGameStarted = false;
#endif
    }
}
