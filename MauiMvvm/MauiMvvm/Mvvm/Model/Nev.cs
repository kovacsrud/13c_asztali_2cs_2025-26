using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PropertyChanged;

namespace MauiMvvm.Mvvm.Model
{
    [AddINotifyPropertyChangedInterface]
    public class Nev
    {
        public string Vezeteknev { get; set; } = "";
        public string Keresztnev { get; set; } = "";
    }
}
