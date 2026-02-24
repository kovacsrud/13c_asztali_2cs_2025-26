using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.EntityFrameworkCore;
using PropertyChanged;
using WpfMagyarorszagEF.mvvm.model;

namespace WpfMagyarorszagEF.mvvm.viewmodel
{
    [AddINotifyPropertyChangedInterface]
    public class TelepulesViewModel
    {
        public MagyarTelepulesekContext context;
        public ObservableCollection<Jogalla> Jogallasok { get; set; }
        public ObservableCollection<Megyek> Megyek { get; set; }
        public ObservableCollection<Telepulesek> Telepulesek { get; set; }

        public TelepulesViewModel()
        {
            context = new MagyarTelepulesekContext();
            context.Telepuleseks.Load();
            context.Megyeks.Load();
            context.Jogallas.Load();

            Jogallasok = context.Jogallas.Local.ToObservableCollection();
            Megyek=context.Megyeks.Local.ToObservableCollection();
            Telepulesek=context.Telepuleseks.Local.ToObservableCollection();
            
        }

        public void DbMentes()
        {
            try
            {
                var valasz=MessageBox.Show("Biztosan menti?","Mentés",MessageBoxButton.OKCancel,MessageBoxImage.Question);

                if (valasz==MessageBoxResult.OK)
                {
                    var result = context.SaveChanges();
                    if (result>0)
                    {
                        MessageBox.Show("Adatok mentve!");
                    } else
                    {
                        MessageBox.Show("Nem változtak az adatok!");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
