using System;
using System.Collections.Generic;

namespace EvlyPeruStoreBK.Infrastructure.core.Data;

public partial class Provinces
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public int CountryId { get; set; }

    public virtual ICollection<Business> Business { get; set; } = new List<Business>();

    public virtual Countries Country { get; set; } = null!;

    public virtual ICollection<Districts> Districts { get; set; } = new List<Districts>();

    public virtual ICollection<Naturalperson> Naturalperson { get; set; } = new List<Naturalperson>();
}
