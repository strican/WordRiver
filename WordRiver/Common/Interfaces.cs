namespace WordRiver.Common
{
    interface IGameDictionary
    {
        ResponseType IsValidWord(string word);

        // TODO: Expand interface
        // Probably needed: SelectWord, Copy Constructor
        // Will likely need tag/roll back implemented in a search dictionary
        // Move GameDictionary to WordRiver.Common?
    }

    interface IWordSearch
    {
        string FindNextWord(IGameDictionary dictionary, string previous);
    }
}