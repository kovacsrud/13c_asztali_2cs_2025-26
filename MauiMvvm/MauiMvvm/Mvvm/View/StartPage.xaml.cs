using MauiMvvm.Mvvm.ViewModel;

namespace MauiMvvm.Mvvm.View;

public partial class StartPage : ContentPage
{
	public StartPage()
	{
		InitializeComponent();

		BindingContext = new PageViewModel();
	}

    private void buttonTovabb_Clicked(object sender, EventArgs e)
    {
		var vm=BindingContext as PageViewModel;
		Navigation.PushAsync(new MiddlePage { BindingContext=vm });
    }
}