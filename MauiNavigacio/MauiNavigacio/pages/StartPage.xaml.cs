namespace MauiNavigacio.pages;

public partial class StartPage : ContentPage
{
	public StartPage()
	{
		InitializeComponent();
	}

    private void buttonTovabb_Clicked(object sender, EventArgs e)
    {
		Navigation.PushAsync(new MiddlePage());
    }
}