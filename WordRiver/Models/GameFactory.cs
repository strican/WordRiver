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
    class GameFactory
    {
        private static Uri DICTIONARY_PATH = new Uri("ms-appx:///Dictionaries\\WordRiverDict.txt");

        public static async Task<GameModel> CreateGame()
        {
            // TODO: Dynamically load different dictionaries
            var words = await LoadDictionary();

            // TODO: Create different search based on selected difficulty
            var wordSearch = new BasicWordSearch();

            return new GameModel(words, wordSearch);
        }

        private static async Task<GameDictionary> LoadDictionary()
        {
            var dictionary = new Dictionary<string, bool>();

            StorageFile file = await StorageFile.GetFileFromApplicationUriAsync(DICTIONARY_PATH);
            var stream = await file.OpenStreamForReadAsync();
            using (StreamReader reader = new StreamReader(stream))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    dictionary.Add(line.ToUpper(), false);
                }
            }

            // Create a new game dictionary with this word fdictionary
            return new GameDictionary(dictionary);
        }
    }
}
