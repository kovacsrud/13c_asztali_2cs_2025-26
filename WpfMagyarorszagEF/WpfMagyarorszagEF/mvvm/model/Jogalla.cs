using System;
using System.Collections.Generic;

namespace WpfMagyarorszagEF.mvvm.model;

public partial class Jogalla
{
    public int Suly { get; set; }

    public string Jogallas { get; set; } = null!;

    public virtual ICollection<Telepulesek> Telepuleseks { get; set; } = new List<Telepulesek>();
}
