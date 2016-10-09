using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using WordRiver.Common;

namespace WordRiverUnitTests.Mocks
{
    class MockDictionary : IGameDictionary
    {
        private Dictionary<string, bool> Words = new Dictionary<string, bool>();

        public MockDictionary()
        {

        }

        public void AddWords(List<string> words)
        {
            foreach (string word in words)
            {
                Words.Add(word, false);
            }
        }

        public void SelectWord(string word)
        {
            Assert.IsTrue(IsValidWord(word) == ResponseType.Success);
            Words[word] = true;
        }

        public ResponseType IsValidWord(string word)
        {
            ResponseType response = ResponseType.Error;
            if (Words.ContainsKey(word) && !Words[word])
            {
                response = ResponseType.Success;
            }
            return response;
        }
    }
}
