using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace FreelancerJerry.Models;

public partial class Customer
{
    [DisplayName("Customer ID")]
    public int CustomerId { get; set; }
    [DisplayName("First Name")]
    public string? FirstName { get; set; }
    [DisplayName("Last Name")]
    public string? LastName { get; set; }
    [DisplayName("Email")]
    public string? Email { get; set; }
    
    [NotMapped]
    public string? Password {get; set;}

    [NotMapped]
    [DisplayName("Confirm Password")]
    public string? ConfirmPassword {get; set;}
    public string? Password_Hash {get; set;}

    public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();

    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();

    public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();
}
