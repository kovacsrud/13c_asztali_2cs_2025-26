using System;
using System.Collections.Generic;

namespace WpfMagyarorszagEF.mvvm.model;

public partial class Megyek
{
    public string Kod { get; set; } = null!;

    public string Nev { get; set; } = null!;

    public virtual ICollection<Telepulesek> Telepuleseks { get; set; } = new List<Telepulesek>();
}
