using System;
using System.Collections.Generic;

namespace EvlyPeruStoreBK.Infrastructure.core.Data;

public partial class Districts
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public int ProvinciaId { get; set; }

    public virtual ICollection<Business> Business { get; set; } = new List<Business>();

    public virtual ICollection<Naturalperson> Naturalperson { get; set; } = new List<Naturalperson>();

    public virtual Provinces Provincia { get; set; } = null!;
}
