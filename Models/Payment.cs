using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace FreelancerJerry.Models;

public partial class Payment
{
    [DisplayName("Payment ID")]
    public int PaymentId { get; set; }
    [DisplayName("Total Amount")]
    public decimal? Amount { get; set; }
    [DisplayName("Transation Date")]
    public DateTime? TransactionDate { get; set; }
    [DisplayName("Customer ID")]
    public int? CustomerId { get; set; }
    [DisplayName("Freelancer ID")]
    public int? FreelancerId { get; set; }
    [DisplayName("Booking ID")]
    public int? BookingId { get; set; }

    public virtual Booking? Booking { get; set; }

    public virtual Customer? Customer { get; set; }

    public virtual Freelancer? Freelancer { get; set; }
}
