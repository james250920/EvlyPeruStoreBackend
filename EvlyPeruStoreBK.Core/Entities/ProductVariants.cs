using System;
using System.Collections.Generic;

namespace EvlyPeruStoreBK.Infrastructure.core.Data;

public partial class ProductVariants
{
    public int VariantId { get; set; }

    public int ProductId { get; set; }

    public int AttributeValueId { get; set; }

    public int Stock { get; set; }

    public decimal? AdditionalPrice { get; set; }

    public string Sku { get; set; } = null!;

    public virtual AttributeValues AttributeValue { get; set; } = null!;

    public virtual ICollection<OrderItems> OrderItems { get; set; } = new List<OrderItems>();

    public virtual Products Product { get; set; } = null!;
}
