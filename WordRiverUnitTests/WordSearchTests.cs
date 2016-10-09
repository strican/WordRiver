using System;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using WordRiver.Common;
using WordRiverUnitTests.Mocks;
using System.Collections.Generic;

namespace WordRiverUnitTests
{
    [TestClass]
    public class WordSearchTests
    {
        private MockDictionary SimpleDictSetup()
        {
            var dictionary = new MockDictionary();

            // Create our word list
            var words = new List<string>();
            words.Add("BALK");
            words.Add("BACK");

            // Add it to the dictionary
            dictionary.AddWords(words);

            return dictionary;
        }

        [TestMethod]
        public void FindNextWordTest()
        {
            MockDictionary dictionary = SimpleDictSetup();
            IWordSearch basic = new BasicWordSearch();

            // Valid next word
            dictionary.SelectWord("BACK");
            string singleNextWord = basic.FindNextWord(dictionary, "BACK");
            Assert.AreEqual("BALK", singleNextWord);
            
            // No next word
            dictionary.SelectWord("BALK");
            string noNextWord = basic.FindNextWord(dictionary, "BALK");
            Assert.AreEqual(null, noNextWord);
        }
    }
}
