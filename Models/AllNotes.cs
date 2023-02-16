using System.Collections.ObjectModel;

namespace Notes.Models;

public class AllNotes
{
    public ObservableCollection<Notes> Notes { get; set; } = new ObservableCollection<Notes>();

    public AllNotes() => LoadNotes();

    public void LoadNotes()
    {
        Notes.Clear();

        string appDataPath = FileSystem.AppDataDirectory;
        IEnumerable<Notes> notes = Directory
            .EnumerateFiles(appDataPath, "*.notes.txt")
            .Select(fileName => new Notes()
            {
                FileName = fileName,
                Text = File.ReadAllText(fileName),
                Date = File.GetCreationTime(fileName)
            })
            .OrderBy(note => note.Date);

        foreach(Notes note in notes)
            Notes.Add(note);
    }
}

