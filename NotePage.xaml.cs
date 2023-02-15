namespace Notes;

public partial class NotePage : ContentPage
{
	string _fileName = Path.Combine(FileSystem.AppDataDirectory, "notes.txt");
	public NotePage()
	{
		InitializeComponent();

		if (File.Exists(_fileName))
			TextEditor.Text = File.ReadAllText(_fileName);
	}

    void SaveButton_Clicked(System.Object sender, System.EventArgs e)
    {
		// Save the file
		File.WriteAllText(_fileName, TextEditor.Text);
    }

    void DeleteButton_Clicked(System.Object sender, System.EventArgs e)
    {
		// Delete the file
		if (File.Exists(_fileName))
			File.Delete(_fileName);

		TextEditor.Text = string.Empty;
    }
}
