using System;
using System.Collections.Generic;

namespace FreelancerJerry.Models;

public partial class Booking
{
    public int BookingId { get; set; }

    public string? BookingName { get; set; }

    public DateOnly? Date { get; set; }

    public string? Description { get; set; }

    public int? CustomerId { get; set; }

    public int? FreelancerId { get; set; }

    public virtual Customer? Customer { get; set; }

    public virtual Freelancer? Freelancer { get; set; }

    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();

    public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();
}
