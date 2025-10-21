using MauiMvvm.Mvvm.View;

namespace MauiMvvm
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new StartPage());
        }
    }
}
