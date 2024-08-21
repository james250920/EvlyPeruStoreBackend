using System;
using System.Collections.Generic;

namespace EvlyPeruStoreBK.Infrastructure.core.Data;

public partial class Business
{
    public int Id { get; set; }

    public string SocialReason { get; set; } = null!;

    public string MerchName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Cellphone { get; set; } = null!;

    public string Ruc { get; set; } = null!;

    public DateOnly? Anniversary { get; set; }

    public string? Address { get; set; }

    public int? District { get; set; }

    public int? Country { get; set; }

    public int? Province { get; set; }

    public bool? Status { get; set; }

    public bool IsTax { get; set; }

    public virtual ICollection<Businesscontacts> Businesscontacts { get; set; } = new List<Businesscontacts>();

    public virtual Countries? CountryNavigation { get; set; }

    public virtual Districts? DistrictNavigation { get; set; }

    public virtual Provinces? ProvinceNavigation { get; set; }
}
