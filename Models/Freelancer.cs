using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace FreelancerJerry.Models;

public partial class Freelancer
{
    [DisplayName("Freelancer ID")]
    public int FreelancerId { get; set; }
    [DisplayName("First Name")]
    public string? FirstName { get; set; }
    [DisplayName("Last Name")]
    public string? LastName { get; set; }
    [DisplayName("Phone Number")]
    public string? PhoneNumber { get; set; }
    [DisplayName("Email")]
    public string? Email { get; set; }
    [DisplayName("Freelancer Description")]
    public string? Description { get; set; }

    public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();

    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();

    public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();
}
