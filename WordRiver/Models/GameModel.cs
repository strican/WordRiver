using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using WordRiver.Common;

namespace WordRiver.Models
{
    class GameModel
    {
        public GameModel(GameDictionary dictionary, IWordSearch wordSearch)
        {
            Dictionary = dictionary;
            WordSearch = wordSearch;
        }

        #region Public Functions

        public ResponseType AttemptWord(string input)
        {
            ResponseType response = Dictionary.IsValidWord(input);

            if (response == ResponseType.Success)
            {
                Dictionary.SelectWord(input);
                LastWord = input;
            }
            return response;
        }

        public string GetNextWord()
        {
            if (LastWord == null)
            {
                LastWord = Dictionary.GetStartingWord();
            }
            else
            {
                LastWord = WordSearch.FindNextWord(Dictionary, LastWord);
            }
            
            Dictionary.SelectWord(LastWord);
            return LastWord;
        }

        #endregion Public Functions

        #region Private Functions
        
        #endregion Private Functions


        #region Private Data

        private GameDictionary Dictionary;
        private IWordSearch WordSearch;
        private string LastWord;

        #endregion Private Data
    }
}
