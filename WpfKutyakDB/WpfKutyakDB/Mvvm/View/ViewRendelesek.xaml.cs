using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WpfKutyakDB.Mvvm.ViewModel;

namespace WpfKutyakDB.Mvvm.View
{
    /// <summary>
    /// Interaction logic for ViewRendelesek.xaml
    /// </summary>
    public partial class ViewRendelesek : Window
    {
        public ViewRendelesek()
        {
            InitializeComponent();
        }

        private void buttonUjRendeles_Click(object sender, RoutedEventArgs e)
        {
            var vm = DataContext as RendeloViewModel;
            ViewInputRendeles rendeles = new ViewInputRendeles(vm);
            rendeles.ShowDialog();
        }

        private void buttonTorles_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var vm = DataContext as RendeloViewModel;
            ViewInputRendeles rendeles = new ViewInputRendeles(true,vm);
            rendeles.ShowDialog();
        }
    }
}
