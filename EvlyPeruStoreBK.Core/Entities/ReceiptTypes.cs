using System;
using System.Collections.Generic;

namespace EvlyPeruStoreBK.Infrastructure.core.Data;

public partial class ReceiptTypes
{
    public int ReceiptTypeId { get; set; }

    public string ReceiptTypeName { get; set; } = null!;

    public string? Description { get; set; }

    public virtual ICollection<PaymentReceipts> PaymentReceipts { get; set; } = new List<PaymentReceipts>();
}
