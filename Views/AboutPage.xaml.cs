﻿namespace Notes.Views;

public partial class AboutPage : ContentPage
{
	public AboutPage()
	{
		InitializeComponent();
	}

    private async void LearnMore_Clicked(Object sender, EventArgs e)
    {
        //Navigate to the specified URL in the system
        if (BindingContext is Models.About about)
			await Launcher.Default.OpenAsync(about.MoreInfoUrl);
    }
}
