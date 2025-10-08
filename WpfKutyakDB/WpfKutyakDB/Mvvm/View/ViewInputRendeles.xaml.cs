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
            comboKutyafajtak.SelectedIndex = 0;
            comboKutyanevek.SelectedIndex = 0;
        }

        public ViewInputRendeles(bool modosit,RendeloViewModel vm)
        {
            InitializeComponent();
            this.modosit = modosit;
            this.vm = vm;
            DataContext = vm;
            textblockCim.Text = "Rendelési adat módosítása";
            Title = textblockCim.Text;
            //comboKutyafajtak.SelectedValue = vm.SelectedRendeles.FajtaId;
            //comboKutyanevek.SelectedValue = vm.SelectedRendeles.NevId;
        }

        private void buttonMentes_Click(object sender, RoutedEventArgs e)
        {
            if (textboxEletkor.Text.Length>0 && textboxUtolsoEll.Text.Length==10) {
                if (modosit) {
                  //  vm.SelectedRendeles.FajtaId = (int)comboKutyafajtak.SelectedValue;
                  //  vm.SelectedRendeles.NevId = (int)comboKutyanevek.SelectedValue;
                    vm.ModositRendeles(vm.SelectedRendeles);
                    vm.GetRendelesek();
                    //A vm.SelectedRendeles itt null lesz valamiért

                }
                else
                {
                    try
                    {
                        vm.SelectedRendeles.Eletkor = 0;
                        vm.SelectedRendeles.UtolsoEll = "";
                        Rendeles rendeles = new Rendeles
                        {
                            FajtaId = (int)comboKutyafajtak.SelectedValue,
                            NevId = (int)comboKutyanevek.SelectedValue,
                            Eletkor = Convert.ToInt32(textboxEletkor.Text),
                            UtolsoEll = textboxUtolsoEll.Text
                        };
                        vm.UjRendeles(rendeles);
                        vm.GetRendelesek();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Számot kell megadni az életkornál!");                  
                    }
                    
                }

            } else
            {
                MessageBox.Show("Helyes adatokat adjon meg");
            }

        }
    }
}
