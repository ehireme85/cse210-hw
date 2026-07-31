class Word
{
    private string _text;
    private bool   _hidden;

    public Word(string text)
    {
        _text   = text;
        _hidden = false;
    }

    public bool IsHidden
    {
        get { return _hidden; }
    }

    public void Hide()
    {
        _hidden = true;
    }

    // Returns underscores matching the word's length when hidden,
    // or the original text when visible.
    public string GetDisplayText()
    {
        if (_hidden)
            return new string('_', _text.Length);
        return _text;
    }
}