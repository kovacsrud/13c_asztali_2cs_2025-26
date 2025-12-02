using MauiJegyzet13c22025V2.Mvvm.ViewModel;

namespace MauiJegyzet13c22025V2.Mvvm.View;

public partial class JegyzetView : ContentPage
{
	public JegyzetView()
	{
		InitializeComponent();
        BindingContext = new JegyzetViewModel();
	}

    private void buttonUj_Clicked(object sender, EventArgs e)
    {
        var vm=BindingContext as JegyzetViewModel;
        Navigation.PushAsync(new JegyzetInput { BindingContext=vm });
    }

    private void buttonModosit_Clicked(object sender, EventArgs e)
    {
        var vm = BindingContext as JegyzetViewModel;
        Navigation.PushAsync(new JegyzetInput(true,vm));
    }

   
}