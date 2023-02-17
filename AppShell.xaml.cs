namespace Notes;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

		// é preciso definir as rotas que não estão no tapbar
		Routing.RegisterRoute(nameof(Views.NotePage), typeof(Views.NotePage));
	}
}

