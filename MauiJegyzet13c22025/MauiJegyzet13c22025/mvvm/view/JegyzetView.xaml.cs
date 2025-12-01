using SQLite;
using PropertyChanged;
using MauiJegyzet13c22025.mvvm.model;

namespace MauiJegyzet13c22025.mvvm.view;

[AddINotifyPropertyChangedInterface]

public partial class JegyzetView : ContentPage
{
    static string dbname = "jegyzetek.db";
    public const SQLiteOpenFlags Flags = SQLiteOpenFlags.ReadWrite | SQLiteOpenFlags.Create | SQLiteOpenFlags.SharedCache;

    string dbpath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory,dbname);
    SQLiteConnection connection;

    public List<Jegyzet> Jegyzetek { get; set; }=new List<Jegyzet>();
    public Jegyzet AktualisJegyzet { get; set; }

    public JegyzetView()
    {
        InitializeComponent();
        connection = new SQLiteConnection(dbpath, Flags);
        connection.CreateTable<Jegyzet>();

        GetJegyzetek();

        BindingContext = this;
    }

    private void GetJegyzetek()
    {
        Jegyzetek = connection.Table<Jegyzet>().ToList();
    }

    private void buttonUj_Clicked(object sender, EventArgs e)
    {
        try
        {
            var jegyzet=new Jegyzet { Cim=entryCim.Text, Szoveg=entrySzoveg.Text };
            var result=connection.Insert(jegyzet);
            DisplayAlert("Új jegyzet",$"{result} sor beszúrva","Ok");
            GetJegyzetek();
            collectionJegyzetek.SelectedItem = null;

        }
        catch (Exception ex)
        {
            DisplayAlert("Hiba", ex.Message, "Ok");
        }
    }

    private void buttonModosit_Clicked(object sender, EventArgs e)
    {
        try
        {
            connection.Update(AktualisJegyzet);
            GetJegyzetek();
            collectionJegyzetek.SelectedItem = null;
        }
        catch (Exception ex)
        {
           DisplayAlert("Hiba", ex.Message, "Ok");
        }
    }

    private void buttonTorol_Clicked(object sender, EventArgs e)
    {
        
        try
        {
            connection.Delete(AktualisJegyzet);
            GetJegyzetek();
            collectionJegyzetek.SelectedItem=null;
        }
        catch (Exception ex)
        {
            DisplayAlert("Hiba", ex.Message, "Ok");
        }
    }
}