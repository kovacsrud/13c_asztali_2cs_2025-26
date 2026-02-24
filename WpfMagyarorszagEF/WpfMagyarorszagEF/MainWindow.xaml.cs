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
using WpfMagyarorszagEF.mvvm.viewmodel;
using WpfMagyarorszagEF.mvvm.views;

namespace WpfMagyarorszagEF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new TelepulesViewModel();
        }

        private void menuitemJogallasok_Click(object sender, RoutedEventArgs e)
        {
            var vm=DataContext as TelepulesViewModel;
            JogallasView jogallasok=new JogallasView { DataContext= vm };
            jogallasok.ShowDialog();
        }

        private void menuitemTelepulesek_Click(object sender, RoutedEventArgs e)
        {

        }

        private void menuitemMegyek_Click(object sender, RoutedEventArgs e)
        {
            var vm = DataContext as TelepulesViewModel;
            MegyeView megyek = new MegyeView { DataContext= vm };
            megyek.ShowDialog();

        }
    }
}