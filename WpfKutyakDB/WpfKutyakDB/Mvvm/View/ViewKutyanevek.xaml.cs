﻿using System;
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
    /// Interaction logic for ViewKutyanevek.xaml
    /// </summary>
    public partial class ViewKutyanevek : Window
    {
        public ViewKutyanevek()
        {
            InitializeComponent();
        }

        private void buttonUjKutyanev_Click(object sender, RoutedEventArgs e)
        {
            var vm = DataContext as RendeloViewModel;
            ViewInputKutyanev inputKutyanev = new ViewInputKutyanev(vm);
            inputKutyanev.ShowDialog();
        }

        private void buttonTorolKutyanev_Click(object sender, RoutedEventArgs e)
        {
            var vm = DataContext as RendeloViewModel;
            if (vm.SelectedKutyanev!=null) {

                if (vm.SelectedKutyanev.Id!=0)
                {
                    vm.TorolKutyanev(vm.SelectedKutyanev);
                    vm.GetKutyanevek();
                }

                

            } else
            {
                MessageBox.Show("Válassza ki a törölni kívánt nevet");
            }
        }
             

        private void DataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var vm = DataContext as RendeloViewModel;
            ViewInputKutyanev inputKutyanev = new ViewInputKutyanev(true, vm);
            inputKutyanev.ShowDialog();
        }
    }
}
