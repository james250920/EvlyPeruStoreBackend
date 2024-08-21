using System;
using System.Collections.Generic;

namespace EvlyPeruStoreBK.Infrastructure.core.Data;

public partial class Typedocs
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Naturalperson> Naturalperson { get; set; } = new List<Naturalperson>();
}
