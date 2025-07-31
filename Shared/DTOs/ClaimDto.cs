using System;

namespace Shared.DTOs;

public class ClaimDto
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string Type { get; set; }
    public string Status { get; set; }
    public DateTime SubmittedAt { get; set; }
    public string SubmittedBy { get; set; }
}

