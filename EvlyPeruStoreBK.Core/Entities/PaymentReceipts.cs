using System;
using System.Collections.Generic;

namespace EvlyPeruStoreBK.Infrastructure.core.Data;

public partial class PaymentReceipts
{
    public int ReceiptId { get; set; }

    public int OrderId { get; set; }

    public int ReceiptTypeId { get; set; }

    public string ReceiptNumber { get; set; } = null!;

    public DateOnly IssueDate { get; set; }

    public decimal TotalAmount { get; set; }

    public decimal TaxAmount { get; set; }

    public virtual Orders Order { get; set; } = null!;

    public virtual ReceiptTypes ReceiptType { get; set; } = null!;
}
