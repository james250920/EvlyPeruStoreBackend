using System;
using System.Collections.Generic;

namespace EvlyPeruStoreBK.Infrastructure.core.Data;

public partial class Orders
{
    public int OrderId { get; set; }

    public int UserId { get; set; }

    public DateTime OrderDate { get; set; }

    public string Status { get; set; } = null!;

    public decimal TotalAmount { get; set; }

    public string ShippingAddress { get; set; } = null!;

    public string ShippingMethod { get; set; } = null!;

    public string PaymentMethod { get; set; } = null!;

    public virtual ICollection<OrderItems> OrderItems { get; set; } = new List<OrderItems>();

    public virtual ICollection<PaymentReceipts> PaymentReceipts { get; set; } = new List<PaymentReceipts>();
}
