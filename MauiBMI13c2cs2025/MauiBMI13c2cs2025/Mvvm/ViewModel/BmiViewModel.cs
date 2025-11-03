using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PropertyChanged;

namespace MauiBMI13c2cs2025.Mvvm.ViewModel
{
    [AddINotifyPropertyChangedInterface]
    public class BmiViewModel
    {
        public double BmiErtek { get; set; }
        public string BmiSzoveg { get; set; } = "";
        public double TestTomeg { get; set; } = 0;
        public double Magassag { get; set; } = 0;

        public void BmiSzamol()
        {
            BmiErtek = TestTomeg /Math.Pow(Magassag/100,2);
            
        }

        
    }
}
