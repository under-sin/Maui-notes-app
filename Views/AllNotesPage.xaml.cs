namespace Notes.Views;

public partial class AllNotesPage : ContentPage
{
	public AllNotesPage()
	{
		InitializeComponent();
	}

    private void ContentPage_NavigatedTo(Object sender, NavigatedToEventArgs e)
    {
        // vai limpar o <CollectionView x:Name="notesCollection"
        notesCollection.SelectedItem = null;
    }
}
