class ScriptureReference
{
    private string _book;
    private int    _chapter;
    private int    _startVerse;
    private int    _endVerse;  

    public ScriptureReference(string book, int chapter, int verse)
    {
        _book = book; _chapter = chapter; _startVerse = verse; _endVerse = -1;
    }

    // Verse range:  "Proverbs 3:5-6"
    public ScriptureReference(string book, int chapter, int startVerse, int endVerse)
    {
        _book = book; _chapter = chapter; _startVerse = startVerse; _endVerse = endVerse;
    }

    public string GetDisplayText()
    {
        if (_endVerse == -1)
            return $"{_book} {_chapter}:{_startVerse}";
        return $"{_book} {_chapter}:{_startVerse}-{_endVerse}";
    }
}