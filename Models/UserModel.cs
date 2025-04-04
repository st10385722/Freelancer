using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FreelancerJerry.Models;

public class UserModel
{
    [Required]
    [NotMapped]
    [EmailAddress]
    public string? Email {get; set;}
    [Required]
    [NotMapped]
    public string? Password {get; set;}
}
