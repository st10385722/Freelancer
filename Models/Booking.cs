using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace FreelancerJerry.Models;

public partial class Booking
{
    [DisplayName("Booking ID")]
    public int BookingId { get; set; }
    [DisplayName("Name of Booking")]
    public string? BookingName { get; set; }
    [DisplayName("Date of Booking")]
    public DateOnly? Date { get; set; }
    [DisplayName("Description")]
    public string? Description { get; set; }
    [DisplayName("Customer ID")]
    public int? CustomerId { get; set; }
    [DisplayName("Freelancer ID")]
    public int? FreelancerId { get; set; }

    public virtual Customer? Customer { get; set; }

    public virtual Freelancer? Freelancer { get; set; }

    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();

    public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();
}
