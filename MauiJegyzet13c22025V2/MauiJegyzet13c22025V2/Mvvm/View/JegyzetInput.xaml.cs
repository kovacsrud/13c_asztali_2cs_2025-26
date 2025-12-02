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

    public JegyzetInput(bool modosit,JegyzetViewModel vm)
    {
		InitializeComponent();
		this.modosit = modosit;
		BindingContext = vm;
    }

    private async void buttonInput_Clicked(object sender, EventArgs e)
    {
		var vm = BindingContext as JegyzetViewModel;
		if (modosit) {
			labelCim.Text = "Jegyzet módosítása";
			var result =await DisplayAlert("Módosítás", "Biztosan módosítja?", "Igen", "Nem");
			if (result)
			{
				App.JegyzetRepo.UpdateItem(vm.AktualisJegyzet);
                await DisplayAlert("Módosítás", App.JegyzetRepo.StatusMsg, "Ok");
				vm.GetJegyzetek();

            }

		} else
		{
			var ujJegyzet=new Jegyzet { Cim=entryCim.Text, Szoveg=entrySzoveg.Text };
			App.JegyzetRepo.NewItem(ujJegyzet);
			await DisplayAlert("Új jegyzet",App.JegyzetRepo.StatusMsg,"Ok");
			vm.GetJegyzetek();

		}


    }
}