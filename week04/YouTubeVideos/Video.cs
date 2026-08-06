// Video.cs
// Represents a YouTube video.
// Tracks the title, author, length (in seconds), and a list of comments.

using System.Collections.Generic;

class Video
{

 // Private backing fields
    private string        _title;
    private string        _author;
    private int           _lengthInSeconds;
    private List<Comment> _comments;

    // Constructor
    public Video(string title, string author, int lengthInSeconds)
    {
        _title           = title;
        _author          = author;
        _lengthInSeconds = lengthInSeconds;
        _comments        = new List<Comment>();
    }

    // Public read-only properties
    public string Title
    {
        get { return _title; }
    }

    public string Author
    {
        get { return _author; }
    }

    public int LengthInSeconds
    {
        get { return _lengthInSeconds; }
    }

    // Adds a comment to this video's comment list
    public void AddComment(Comment comment)
    {
        _comments.Add(comment);
    }

    // Returns the total number of comments on this video
    public int GetNumberOfComments()
    {
        return _comments.Count;
    }

    // Returns an iterable copy of the comments list for display purposes
    public List<Comment> GetComments()
    {
        return _comments;
    }

    // Helper: formats seconds as m:ss (e.g. 512 -> "5:12")
    public string GetFormattedLength()
    {
        int minutes = _lengthInSeconds / 60;
        int seconds = _lengthInSeconds % 60;
        return $"{minutes}:{seconds:D2}";
    }
}
