namespace Notes.Views;

public partial class NotePage : ContentPage
{
	string _fileName = Path.Combine(FileSystem.AppDataDirectory, "notes.txt");
	public NotePage()
	{
		InitializeComponent();

		string appDataPath = FileSystem.AppDataDirectory;
		string randomFileName = $"{Path.GetRandomFileName()}.notes.txt";

		LoadNote(Path.Combine(appDataPath, randomFileName));
	}

	private void LoadNote(string fileName)
	{
		Models.Notes noteModel = new Models.Notes();
		noteModel.FileName = fileName;

		if(File.Exists(fileName))
		{
			noteModel.Date = File.GetCreationTime(fileName);
			noteModel.Text = File.ReadAllText(fileName);
		}

		BindingContext = noteModel;
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
