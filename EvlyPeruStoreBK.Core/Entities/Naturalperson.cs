using System;
using System.Collections.Generic;

namespace EvlyPeruStoreBK.Infrastructure.core.Data;

public partial class Naturalperson
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int? Age { get; set; }

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Cellphone { get; set; } = null!;

    public int TypeDoc { get; set; }

    public string NumDoc { get; set; } = null!;

    public DateOnly? Birthday { get; set; }

    public string? Address { get; set; }

    public int? District { get; set; }

    public int? Country { get; set; }

    public int? Province { get; set; }

    public bool? Status { get; set; }

    public bool? Adminrole { get; set; }

    public virtual ICollection<Businesscontacts> Businesscontacts { get; set; } = new List<Businesscontacts>();

    public virtual Countries? CountryNavigation { get; set; }

    public virtual Districts? DistrictNavigation { get; set; }

    public virtual Provinces? ProvinceNavigation { get; set; }

    public virtual Typedocs TypeDocNavigation { get; set; } = null!;
}
