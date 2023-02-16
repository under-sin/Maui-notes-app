using System;
namespace Notes.Models;

public class About
{
    public string Title => AppInfo.Name;
    public string Version => AppInfo.VersionString;
    public string MoreInfoUrl => "https://www.youtube.com/watch?v=uLKAkcDnYnA&t=3940s";
    public string Message => "This app is written in XAML and C# with .NET MAUI.";
}

