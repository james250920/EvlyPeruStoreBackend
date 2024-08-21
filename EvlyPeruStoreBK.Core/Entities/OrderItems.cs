using System;
using System.Collections.Generic;

namespace EvlyPeruStoreBK.Infrastructure.core.Data;

public partial class OrderItems
{
    public int OrderItemId { get; set; }

    public int OrderId { get; set; }

    public int VariantId { get; set; }

    public int Quantity { get; set; }

    public decimal UnitPrice { get; set; }

    public decimal Subtotal { get; set; }

    public virtual Orders Order { get; set; } = null!;

    public virtual ProductVariants Variant { get; set; } = null!;
}
