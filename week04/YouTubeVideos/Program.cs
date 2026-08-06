// Program.cs
// Demonstrates the Video and Comment classes by creating a list of videos,
// each with several comments, and displaying all details.

using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // ---------------------------------------------------------------
        // Build the video library
        // ---------------------------------------------------------------
        List<Video> videos = new List<Video>();

        // --- Video 1 ---
        Video video1 = new Video(
            "10 Minute Morning Yoga for Beginners",
            "YogaWithAdriene",
            638);

        video1.AddComment(new Comment("SunriseSam",    "This changed my entire morning routine — thank you!"));
        video1.AddComment(new Comment("FlexibleFiona",  "Day 14 of doing this every morning. I feel amazing."));
        video1.AddComment(new Comment("ZenZach",        "Perfect length. Not too short, not too long."));
        video1.AddComment(new Comment("MindfulMaria",   "The breathing cues make this so much easier to follow."));

        videos.Add(video1);

        // --- Video 2 ---
        Video video2 = new Video(
            "How to Build a REST API in 30 Minutes",
            "TraversyMedia",
            1847);

        video2.AddComment(new Comment("CodeNewbie_Kay",  "Finally a tutorial that doesn't skip the setup steps!"));
        video2.AddComment(new Comment("BackendBen",      "Timestamps in the description are a lifesaver."));
        video2.AddComment(new Comment("DebugDiana",      "Got mine working on the first try. Subscribed immediately."));

        videos.Add(video2);

        // --- Video 3 ---
        Video video3 = new Video(
            "Gordon Ramsay's Perfect Scrambled Eggs",
            "GordonRamsay",
            312);

        video3.AddComment(new Comment("BrunchKing",      "I've made eggs a thousand times and this still taught me something."));
        video3.AddComment(new Comment("ButterLover99",   "The amount of butter is shocking but also completely correct."));
        video3.AddComment(new Comment("CrèmeFraîcheFan", "Adding crème fraîche at the end is the secret I never knew I needed."));
        video3.AddComment(new Comment("SundayChef",      "Made these for my family — they thought I went to culinary school."));

        videos.Add(video3);

        // --- Video 4 ---
        Video video4 = new Video(
            "NASA's Webb Telescope — First Full-Color Images Explained",
            "NASAGoddard",
            2253);

        video4.AddComment(new Comment("StargazerSophie", "I cried watching this. Humanity is incredible."));
        video4.AddComment(new Comment("AstroAndrew",     "The depth of field in that first image — billions of galaxies!"));
        video4.AddComment(new Comment("CuriousCarla",    "Best science communication I've seen in years."));

        videos.Add(video4);

        // ---------------------------------------------------------------
        // Display all videos and their comments
        // ---------------------------------------------------------------
        foreach (Video video in videos)
        {
            Console.WriteLine("==========================================================");
            Console.WriteLine($"Title   : {video.Title}");
            Console.WriteLine($"Author  : {video.Author}");
            Console.WriteLine($"Length  : {video.GetFormattedLength()} ({video.LengthInSeconds}s)");
            Console.WriteLine($"Comments: {video.GetNumberOfComments()}");
            Console.WriteLine("----------------------------------------------------------");

            foreach (Comment comment in video.GetComments())
            {
                Console.WriteLine($"  [{comment.CommenterName}]: {comment.Text}");
            }

            Console.WriteLine();
        }
    }
}
