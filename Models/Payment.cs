using System;
using System.Collections.Generic;

namespace FreelancerJerry.Models;

public partial class Payment
{
    public int PaymentId { get; set; }

    public decimal? Amount { get; set; }

    public DateTime? TransactionDate { get; set; }

    public int? CustomerId { get; set; }

    public int? FreelancerId { get; set; }

    public int? BookingId { get; set; }

    public virtual Booking? Booking { get; set; }

    public virtual Customer? Customer { get; set; }

    public virtual Freelancer? Freelancer { get; set; }
}
