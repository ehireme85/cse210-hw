using System;
using System.Collections.Generic;
using System.Text;

class Scripture
{
    private ScriptureReference _reference;
    private List<Word>         _words;
    private Random             _random = new Random();

    public Scripture(ScriptureReference reference, string text)
    {
        _reference = reference;
        _words     = new List<Word>();
        foreach (string w in text.Split(' '))
            _words.Add(new Word(w));
    }

    public bool IsCompletelyHidden()
    {
        foreach (Word word in _words)
            if (!word.IsHidden) return false;
        return true;
    }

    public void HideRandomWords(int count)
    {
        List<int> visibleIndexes = new List<int>();
        for (int i = 0; i < _words.Count; i++)
            if (!_words[i].IsHidden) visibleIndexes.Add(i);

        for (int i = visibleIndexes.Count - 1; i > 0; i--)
        {
            int j = _random.Next(i + 1);
            int temp = visibleIndexes[i];
            visibleIndexes[i] = visibleIndexes[j];
            visibleIndexes[j] = temp;
        }

        int hideCount = Math.Min(count, visibleIndexes.Count);
        for (int i = 0; i < hideCount; i++)
            _words[visibleIndexes[i]].Hide();
    }

    public string GetDisplayText()
    {
        var sb = new StringBuilder();
        sb.AppendLine(_reference.GetDisplayText());
        var displayWords = new List<string>();
        foreach (Word word in _words)
            displayWords.Add(word.GetDisplayText());
        sb.Append(string.Join(" ", displayWords));
        return sb.ToString();
    }
}