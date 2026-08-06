// Comment.cs
// Represents a single comment left on a YouTube video.
// Tracks the commenter's name and the text of the comment.

class Comment
{
    // Private backing fields — encapsulation
    private string _commenterName;
    private string _text;

    // Constructor
    public Comment(string commenterName, string text)
    {
        _commenterName = commenterName;
        _text          = text;
    }

    // Public read-only properties
    public string CommenterName
    {
        get { return _commenterName; }
    }

    public string Text
    {
        get { return _text; }
    }
}
