using System;

namespace Domain.Entities;

public class ClaimDocument
{
    public int Id { get; set; }
    public string FileName { get; set; }
    public string FilePath { get; set; }
    public int ClaimId { get; set; }
    public Claim Claim { get; set; }
    public DateTime UploadedAt { get; set; } = DateTime.UtcNow;
}

