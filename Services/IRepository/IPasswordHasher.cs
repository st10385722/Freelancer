using System;
using Microsoft.AspNetCore.Identity;

namespace FreelancerJerry.Services.IRepository;

public interface IPasswordHasher
{
    string HashPassword(string password);
    PasswordVerificationResult VerifyHashedPassword(string hashedPassword, string password);
}
