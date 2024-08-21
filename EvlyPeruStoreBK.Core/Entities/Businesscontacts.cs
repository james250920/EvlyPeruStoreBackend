using System;
using System.Collections.Generic;

namespace EvlyPeruStoreBK.Infrastructure.core.Data;

public partial class Businesscontacts
{
    public int Id { get; set; }

    public int IdNaturalperson { get; set; }

    public int IdBusiness { get; set; }

    public virtual Business IdBusinessNavigation { get; set; } = null!;

    public virtual Naturalperson IdNaturalpersonNavigation { get; set; } = null!;
}
