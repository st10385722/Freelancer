using System;
using System.Collections.Generic;

namespace FreelancerJerry.Models;

public partial class Listing
{
    public int ListingId { get; set; }

    public string? Title { get; set; }

    public string? Description { get; set; }

    public DateOnly? Date { get; set; }

    public int? FreelancerId { get; set; }

    public virtual Freelancer? Freelancer { get; set; }
}
