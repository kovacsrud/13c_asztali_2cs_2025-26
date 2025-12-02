using MauiJegyzet13c22025V2.Mvvm.Model;
using MauiJegyzet13c22025V2.Mvvm.ViewModel;

namespace MauiJegyzet13c22025V2.Mvvm.View;

public partial class JegyzetInput : ContentPage
{
	bool modosit = false;
	public JegyzetInput()
	{
		InitializeComponent();
	}

    private void buttonInput_Clicked(object sender, EventArgs e)
    {
		var vm = BindingContext as JegyzetViewModel;
		if (modosit) {
			labelCim.Text = "Jegyzet módosítása";

		} else
		{
			var ujJegyzet=new Jegyzet { Cim=entryCim.Text, Szoveg=entrySzoveg.Text };
			App.JegyzetRepo.NewItem(ujJegyzet);
			DisplayAlert("Új jegyzet",App.JegyzetRepo.StatusMsg,"Ok");
			vm.GetJegyzetek();
		}


    }
}