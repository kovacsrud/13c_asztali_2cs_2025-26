using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MauiMvvm.Mvvm.Model;
using PropertyChanged;

namespace MauiMvvm.Mvvm.ViewModel
{
    [AddINotifyPropertyChangedInterface]
    public class PageViewModel
    {
        public Nev  Nev { get; set; }= new Nev();
    }
}
