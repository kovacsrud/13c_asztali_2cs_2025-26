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
using WpfKutyakEF.mvvm.model;
using WpfKutyakEF.mvvm.viewmodel;

namespace WpfKutyakEF.mvvm.view
{
    /// <summary>
    /// Interaction logic for RendelesiAdatokView.xaml
    /// </summary>
    public partial class RendelesiAdatokView : Window
    {
       

        public RendelesiAdatokView()
        {
            InitializeComponent();
           
            
        }

        private void buttonTorol_Click(object sender, RoutedEventArgs e)
        {
            var vm = DataContext as KutyaViewModel;
            var valasz = MessageBox.Show("Biztosan törli?","Törlés",MessageBoxButton.OKCancel,MessageBoxImage.Question);
            if (valasz==MessageBoxResult.OK && vm.SelectedKutya!=null)
            {
                vm.Kutyak.Remove(vm.SelectedKutya);
                vm.DbMentes();
            }
        }

        private void buttonUj_Click(object sender, RoutedEventArgs e)
        {
            var vm = DataContext as KutyaViewModel;
            InputKutyaView inputKutya = new InputKutyaView(vm);
            inputKutya.ShowDialog();
        }

        private void DataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var vm = DataContext as KutyaViewModel;
            InputKutyaView inputKutya = new InputKutyaView(vm,true);
            inputKutya.ShowDialog();
        }
    }
}
