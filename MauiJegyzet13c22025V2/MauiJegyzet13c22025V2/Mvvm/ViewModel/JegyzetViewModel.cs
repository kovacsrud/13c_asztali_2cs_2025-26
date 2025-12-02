using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MauiJegyzet13c22025V2.Mvvm.Model;
using PropertyChanged;

namespace MauiJegyzet13c22025V2.Mvvm.ViewModel
{
    [AddINotifyPropertyChangedInterface]
    public class JegyzetViewModel
    {
        public List<Jegyzet> Jegyzetek { get; set; }=new List<Jegyzet>();
        public Jegyzet AktualisJegyzet { get; set; }


        public JegyzetViewModel()
        {
            GetJegyzetek();
        }

        public void GetJegyzetek()
        {
            Jegyzetek = App.JegyzetRepo.GetItems();
        }
    }
}
