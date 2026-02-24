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
using WpfMagyarorszagEF.mvvm.viewmodel;

namespace WpfMagyarorszagEF.mvvm.views
{
    /// <summary>
    /// Interaction logic for MegyeSzuresView.xaml
    /// </summary>
    public partial class MegyeSzuresView : Window
    {
        public MegyeSzuresView()
        {
            InitializeComponent();
        }

        private void comboMegyek_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var vm = DataContext as TelepulesViewModel;
            var selectedMegye = comboMegyek.SelectedValue.ToString();
            var megyeTelepulesei=vm.Telepulesek.Where(x=>x.MegyekodNavigation.Nev==selectedMegye);
            if (megyeTelepulesei.Count()>0)
            {
                datagridAdatok.ItemsSource = megyeTelepulesei;
            } else
            {
                MessageBox.Show("Nincs találat!");
            }
        }
    }
}
