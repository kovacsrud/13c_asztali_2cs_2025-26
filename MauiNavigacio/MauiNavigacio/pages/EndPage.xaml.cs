namespace MauiNavigacio.pages;

public partial class EndPage : ContentPage
{
	public EndPage()
	{
		InitializeComponent();
	}

    private void buttonVissza_Clicked(object sender, EventArgs e)
    {
        Navigation.PopAsync();
    }

    private void buttonVisszaAzElejere_Clicked(object sender, EventArgs e)
    {
        Navigation.PopToRootAsync();
    }
}