using System;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using System.Collections.Generic;
using WordRiver.Models;
using WordRiver.Common;

namespace WordRiverUnitTests
{
    [TestClass]
    public class DictionaryTests
    {
        [TestMethod]
        public void IsValidWordTest()
        {
            var words = new Dictionary<string, bool>();
            words.Add("BACK", false);
            words.Add("TRUE", true);

            GameDictionary dictionary = new GameDictionary(words);

            // Valid word
            ResponseType validWord = dictionary.IsValidWord("BACK");
            Assert.AreEqual(ResponseType.Success, validWord);

            // Duplicate word
            ResponseType duplicateWord = dictionary.IsValidWord("TRUE");
            Assert.AreEqual(ResponseType.DuplicateWord, duplicateWord);

            // Invalid word
            ResponseType invalidWord = dictionary.IsValidWord("VOID");
            Assert.AreEqual(ResponseType.InvalidWord, invalidWord);
        }

        [TestMethod]
        public void SelectWordTest()
        {
            var words = new Dictionary<string, bool>();
            words.Add("BACK", false);

            GameDictionary dictionary = new GameDictionary(words);

            // Valid word
            ResponseType validWord = dictionary.IsValidWord("BACK");
            Assert.AreEqual(ResponseType.Success, validWord);

            // Duplicate word
            dictionary.SelectWord("BACK");
            ResponseType duplicateWord = dictionary.IsValidWord("BACK");
            Assert.AreEqual(ResponseType.DuplicateWord, duplicateWord);
        }
    }
}
