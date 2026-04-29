using System;
using System.Collections.Generic;

namespace BankMlekaBackendApp.Models;

public partial class Rented
{
    public int Id { get; set; }

    public int DeviceId { get; set; }

    public DateOnly RentDate { get; set; }

    public DateOnly? ReturnDate { get; set; }

    public int TransportId { get; set; }

    public virtual Device Device { get; set; } = null!;

    public virtual Delivery Transport { get; set; } = null!;
}
