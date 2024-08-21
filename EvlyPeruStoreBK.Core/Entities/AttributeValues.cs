using System;
using System.Collections.Generic;

namespace EvlyPeruStoreBK.Infrastructure.core.Data;

public partial class AttributeValues
{
    public int AttributeId { get; set; }

    public int ValueId { get; set; }

    public string ValueName { get; set; } = null!;

    public virtual Attributes Attribute { get; set; } = null!;

    public virtual ICollection<ProductVariants> ProductVariants { get; set; } = new List<ProductVariants>();
}
