using System;
using Domain.Enums;

namespace Domain.Entities;

public class Claim
{
    public int Id { get; set; }
    public required string Title { get; set; }
    public required string Description { get; set; }
    public ClaimType Type { get; set; }
    public ClaimStatus Status { get; set; }
    public required string SubmittedById { get; set; }
    public ApplicationUser SubmittedBy { get; set; } = null!;
    public DateTime SubmittedAt { get; set; }
}
