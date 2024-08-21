using System;
using System.Collections.Generic;

namespace EvlyPeruStoreBK.Infrastructure.core.Data;

public partial class Countries
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public virtual ICollection<Business> Business { get; set; } = new List<Business>();

    public virtual ICollection<Naturalperson> Naturalperson { get; set; } = new List<Naturalperson>();

    public virtual ICollection<Provinces> Provinces { get; set; } = new List<Provinces>();
}
