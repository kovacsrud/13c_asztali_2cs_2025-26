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
    /// Interaction logic for JogallasView.xaml
    /// </summary>
    public partial class JogallasView : Window
    {
        public JogallasView()
        {
            InitializeComponent();
        }

        private void buttonMentes_Click(object sender, RoutedEventArgs e)
        {
            var vm = DataContext as TelepulesViewModel;
            vm.DbMentes();
        }
    }
}
