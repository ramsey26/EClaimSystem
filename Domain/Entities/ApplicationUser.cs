using System;
using Microsoft.AspNetCore.Identity;

namespace Domain.Entities;

public class ApplicationUser : IdentityUser
{
    public required string FullName { get; set; }
    public bool IsVerified { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}
