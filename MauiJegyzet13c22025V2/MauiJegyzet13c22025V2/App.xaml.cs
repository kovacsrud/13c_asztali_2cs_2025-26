using MauiJegyzet13c22025V2.Mvvm.Model;
using MauiJegyzet13c22025V2.Mvvm.View;
using MauiJegyzet13c22025V2.Repository;

namespace MauiJegyzet13c22025V2
{
    public partial class App : Application
    {
        public static BaseRepository<Jegyzet> JegyzetRepo {  get; private set; }
        public App(BaseRepository<Jegyzet> repo)
        {
            InitializeComponent();
            JegyzetRepo = repo;
            MainPage = new NavigationPage(new JegyzetView());
        }
    }
}
