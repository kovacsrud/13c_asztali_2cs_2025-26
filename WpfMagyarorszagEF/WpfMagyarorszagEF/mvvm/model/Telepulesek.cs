using System;
using System.Collections.Generic;

namespace WpfMagyarorszagEF.mvvm.model;

public partial class Telepulesek
{
    public int Id { get; set; }

    public int Irszam { get; set; }

    public string Nev { get; set; } = null!;

    public string Megyekod { get; set; } = null!;

    public double Lat { get; set; }

    public double Long { get; set; }

    public string Kshkod { get; set; } = null!;

    public int Jogallas { get; set; }

    public int Terulet { get; set; }

    public int Nepesseg { get; set; }

    public int Lakasok { get; set; }

    public virtual Jogalla JogallasNavigation { get; set; } = null!;

    public virtual Megyek MegyekodNavigation { get; set; } = null!;
}
