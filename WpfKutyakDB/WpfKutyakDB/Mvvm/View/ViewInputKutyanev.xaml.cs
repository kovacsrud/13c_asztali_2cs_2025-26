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
using WpfKutyakDB.Mvvm.Model;
using WpfKutyakDB.Mvvm.ViewModel;

namespace WpfKutyakDB.Mvvm.View
{
    /// <summary>
    /// Interaction logic for ViewInputKutyanev.xaml
    /// </summary>
    public partial class ViewInputKutyanev : Window
    {
        bool modosit=false;
        RendeloViewModel vm;
        public ViewInputKutyanev(RendeloViewModel vm)
        {
            InitializeComponent();
            this.vm = vm;
            DataContext = vm;
            vm.SelectedKutyanev.KutyaNev = "";
        }

        public ViewInputKutyanev(bool modosit,RendeloViewModel vm)
        {
            InitializeComponent(); 
            this.modosit = modosit;
            textblockCim.Text = "Kutyanév módosítása";
            Title = "Kutyanév módosítás";
            this.vm = vm;
            DataContext= vm;
        }

        private void buttonMentes_Click(object sender, RoutedEventArgs e)
        {
            if (textboxKutyanev.Text.Length>1) {
                if (modosit) {
                    vm.ModositKutyanev(vm.SelectedKutyanev);
                    vm.GetKutyanevek();

                } else
                {
                    Kutyanev kutyanev= new Kutyanev { KutyaNev = textboxKutyanev.Text };
                    vm.UjKutyanev(kutyanev);
                    vm.GetKutyanevek();
                }

            } else
            {
                MessageBox.Show("Adjon meg legalább 1 karaktert!");
            }
        }
    }
}
