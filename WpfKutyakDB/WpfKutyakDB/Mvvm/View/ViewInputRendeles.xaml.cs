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
    /// Interaction logic for ViewInputRendeles.xaml
    /// </summary>
    public partial class ViewInputRendeles : Window
    {
        bool modosit=false;
        RendeloViewModel vm;
        public ViewInputRendeles(RendeloViewModel vm)
        {
            InitializeComponent();
            this.vm = vm;
            DataContext = vm;
        }

        public ViewInputRendeles(bool modosit,RendeloViewModel vm)
        {
            InitializeComponent();
            this.modosit = modosit;
            this.vm = vm;
            DataContext = vm;
            textblockCim.Text = "Rendelési adat módosítása";
            Title = textblockCim.Text;
        }

        private void buttonMentes_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
