using Microsoft.Win32;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfDronok.Model;
using WpfDronok.Views;

namespace WpfDronok;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public List<Dron> Dronok { get; set; }=new List<Dron>();
    public MainWindow()
    {
        InitializeComponent();
    }

    private void menuitemKilepes_Click(object sender, RoutedEventArgs e)
    {
        Environment.Exit(0);
    }

    private void menuitemNevjegy_Click(object sender, RoutedEventArgs e)
    {
        NevjegyView nevjegy=new NevjegyView();
        nevjegy.ShowDialog();
    }

    private void menuitemMegnyitas_Click(object sender, RoutedEventArgs e)
    {
        OpenFileDialog dialog = new OpenFileDialog();
        dialog.Filter = ".csv fájlok|*.csv|minden fájl|*.*";

        if (dialog.ShowDialog()==true)
        {
            try
            {
                Dronok = new DronLista(dialog.FileName, ',').Dronok;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);                
            }
        }
    }

    private void menuitemTipusSzures_Click(object sender, RoutedEventArgs e)
    {
        TipusSzuresView tipusSzures = new TipusSzuresView(Dronok);
        tipusSzures.ShowDialog();
    }

    private void menuitemMentes_Click(object sender, RoutedEventArgs e)
    {
        //Nem ebben az ablakban vagyunk.
    }
}