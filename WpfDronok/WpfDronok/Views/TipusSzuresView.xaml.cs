using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
            comboDronok.ItemsSource = Dronok.OrderBy(x=>x.Tipus).Select(x=>x.Tipus).Distinct().ToList();
        }

        private void buttonKeres_Click(object sender, RoutedEventArgs e)
        {
            datagridDronok.ItemsSource = null;

            var keresett = textboxKereses.Text;
            //Megegyzés vizsgálata
            //var eredmeny=Dronok.FindAll(x=>x.Tipus.ToLower()==keresett.ToLower());

            //Tartalmazás vizsgálata
            var eredmeny = Dronok.FindAll(x => x.Tipus.ToLower().Contains(keresett.ToLower()));


            if (eredmeny.Count()>0)
            {
                datagridDronok.ItemsSource= eredmeny;
            } else
            {
                MessageBox.Show("Nincs ilyen adat!");
            }
        }

        private void buttonVissza_Click(object sender, RoutedEventArgs e)
        {
            datagridDronok.ItemsSource = Dronok;
        }

        private void comboDronok_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var kivalasztott=comboDronok.SelectedItem as string;
            var eredmeny = Dronok.FindAll(x => x.Tipus == kivalasztott);

            datagridDronok.ItemsSource=eredmeny;
        }

        private void buttonMentes_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = ".csv fájlok|*.csv|.txt fájlok|*.txt";
            //???
            if (dialog.ShowDialog()==true)
            {
                try
                {
                    FileStream fajl = new FileStream(dialog.FileName, FileMode.Create);

                    using (StreamWriter writer = new StreamWriter(fajl, Encoding.UTF8))
                    {
                        writer.WriteLine($"nev;tipus;gyartasiev;maxsebesseg;akkukapacitas;repulesido");

                        foreach (var i in datagridDronok.ItemsSource as List<Dron>)
                        {
                            writer.WriteLine($"{i.Nev};{i.Tipus};{i.GyartasiEv};{i.MaxSebesseg};{i.AkkuKapacitas};{i.RepulesiIdo}");
                        }
                    }
                                                      

                    
                    
                    MessageBox.Show("Fájlba írás kész!");

                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Hiba!", MessageBoxButton.OK, MessageBoxImage.Error);                    
                }
            }
        }
    }
}
