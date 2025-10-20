namespace MauiStart;

public partial class StartPage : ContentPage
{
	public StartPage()
	{
		InitializeComponent();
	}

    private void buttonSzamol_Clicked(object sender, EventArgs e)
    {
		try
		{
			var kmh = Convert.ToInt32(entryKmh.Text);
			var ms = kmh / 3.6;
			labelEredmeny.Text = ms.ToString();
		}
		catch (Exception ex)
		{
			DisplayAlert("Hiba", ex.Message, "Ok");			
		}
    }
}