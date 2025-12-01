using MauiJegyzet13c22025.mvvm.view;

namespace MauiJegyzet13c22025
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new JegyzetView();
        }
    }
}
