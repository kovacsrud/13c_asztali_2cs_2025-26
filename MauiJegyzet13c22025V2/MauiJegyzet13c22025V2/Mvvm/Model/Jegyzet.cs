using MauiJegyzet13c22025V2.Intefaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace MauiJegyzet13c22025V2.Mvvm.Model
{
    [System.ComponentModel.DataAnnotations.Schema.Table("jegyzetek")]
    public class Jegyzet:TableData
    {
        [NotNull]
        public string Cim { get; set; }
        [NotNull]
        public string Szoveg { get; set; }
        [NotNull]
        public DateTime Datum { get; set; } = DateTime.Now;
    }
}
