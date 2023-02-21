using System;
namespace Notes.Models;

public class Notes
{
    public string FileName { get; set; }
    public string Text { get; set; }
    public DateTime Date { get; set; }

    public Notes()
    {
        FileName = $"{Path.GetRandomFileName()}.notes.txt";
        Date = DateTime.Now;
        Text = "";
    }

    public void Save() =>
        File.WriteAllText(System.IO.Path.Combine(FileSystem.AppDataDirectory, FileName), Text);

    public void Delete() =>
        File.Delete(System.IO.Path.Combine(FileSystem.AppDataDirectory, FileName));

    public static Notes Load(string filename)
    {
        filename = System.IO.Path.Combine(FileSystem.AppDataDirectory, filename);

        if (!File.Exists(filename))
            throw new FileNotFoundException("Unable to find file on local storage.", filename);

        return
            new()
            {
                FileName = Path.GetFileName(filename),
                Text = File.ReadAllText(filename),
                Date = File.GetLastWriteTime(filename)
            };
    }

    public static IEnumerable<Notes> LoadAll()
    {
        string appDataPath = FileSystem.AppDataDirectory;

        return Directory
            .EnumerateFiles(appDataPath, "*.notes.txt")
            .Select(filename => Notes.Load(Path.GetFileName(filename)))
            .OrderByDescending(note => note.Date);
    }
}
