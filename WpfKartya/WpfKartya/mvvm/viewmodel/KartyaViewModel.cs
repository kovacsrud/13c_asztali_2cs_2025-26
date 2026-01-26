using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using PropertyChanged;
using WpfKartya.mvvm.model;

namespace WpfKartya.mvvm.viewmodel
{
    [AddINotifyPropertyChangedInterface]
    public class KartyaViewModel
    {
        public List<Kartya> Pakli { get; set; }=new List<Kartya>();
        public List<BitmapImage> Hatterek { get; set; }= new List<BitmapImage>();
        public Kartya SelectedKartya { get; set; } = new Kartya();
        public BitmapImage SelectedHatter { get; set; } = new BitmapImage();
        public int Kassza { get; set; } = 1000;
        public int Tet { get; set; } = 100;
        public bool Jatekvege { get; set; } = false;

        ResourceManager rsKartyak = new ResourceManager("WpfKartya.Kartyak",Assembly.GetExecutingAssembly());
        ResourceManager rsHatterek = new ResourceManager("WpfKartya.Hatterek", Assembly.GetExecutingAssembly());

        public KartyaViewModel()
        {
                
        }

        public void InitPakli()
        {
            ResourceSet rsKartyaSet = rsKartyak.GetResourceSet(System.Globalization.CultureInfo.CurrentCulture,true,true);



            ResourceSet rsHatterSet = rsKartyak.GetResourceSet(System.Globalization.CultureInfo.CurrentCulture, true, true);
        }
    }
}
