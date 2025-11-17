using MauiRandomUser13c22025.Mvvm.View;

namespace MauiRandomUser13c22025
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
