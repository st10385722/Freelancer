using System;
using System.Collections.Generic;

namespace FreelancerJerry.Models;

public partial class Review
{
    public int ReviewId { get; set; }

    public int? Rating { get; set; }

    public string? Description { get; set; }

    public int? FreelancerId { get; set; }

    public int? CustomerId { get; set; }

    public int? BookingId { get; set; }

    public virtual Booking? Booking { get; set; }

    public virtual Customer? Customer { get; set; }

    public virtual Freelancer? Freelancer { get; set; }
}
