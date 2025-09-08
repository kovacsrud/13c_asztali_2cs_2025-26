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
using WpfDronok.Model;

namespace WpfDronok.Views
{
    /// <summary>
    /// Interaction logic for TipusSzuresView.xaml
    /// </summary>
    public partial class TipusSzuresView : Window
    {
        public List<Dron> Dronok { get; set; }=new List<Dron>();
        public TipusSzuresView(List<Dron> dronok)
        {
            InitializeComponent();
            Dronok= dronok;
            datagridDronok.ItemsSource = Dronok;
        }

        private void buttonKeres_Click(object sender, RoutedEventArgs e)
        {
            var keresett = textboxKereses.Text;
            var eredmeny=Dronok.FindAll(x=>x.Tipus==keresett);

            if(eredmeny.Count()>0)
            {
                datagridDronok.ItemsSource= eredmeny;
            } else
            {
                MessageBox.Show("Nincs ilyen adat!");
            }
        }
    }
}
