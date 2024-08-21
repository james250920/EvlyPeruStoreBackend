using System;
using System.Collections.Generic;

namespace EvlyPeruStoreBK.Infrastructure.core.Data;

public partial class Products
{
    public int Id { get; set; }

    public string ProductName { get; set; } = null!;

    public int CategoryId { get; set; }

    public string? Description { get; set; }

    public decimal Price { get; set; }

    public virtual ProductCategories Category { get; set; } = null!;

    public virtual ICollection<ProductVariants> ProductVariants { get; set; } = new List<ProductVariants>();
}
