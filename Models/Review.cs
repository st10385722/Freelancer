using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace FreelancerJerry.Models;

public partial class Review
{
    [DisplayName("Review ID")]
    public int ReviewId { get; set; }
    [DisplayName("Rating")]
    public int? Rating { get; set; }
    [DisplayName("Review Message")]
    public string? Description { get; set; }
    [DisplayName("Freelancer ID")]
    public int? FreelancerId { get; set; }
    [DisplayName("Customer ID")]
    public int? CustomerId { get; set; }
    [DisplayName("Booking ID")]
    public int? BookingId { get; set; }

    public virtual Booking? Booking { get; set; }

    public virtual Customer? Customer { get; set; }

    public virtual Freelancer? Freelancer { get; set; }
}
