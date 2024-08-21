using System;
using System.Collections.Generic;

namespace EvlyPeruStoreBK.Infrastructure.core.Data;

public partial class Attributes
{
    public int AttributeId { get; set; }

    public string AttributeName { get; set; } = null!;

    public virtual ICollection<AttributeValues> AttributeValues { get; set; } = new List<AttributeValues>();
}
