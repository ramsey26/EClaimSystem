using System;
using Shared.DTOs;

namespace Application.Interfaces;

public interface IClaimService
{
    Task<int> SubmitClaimAsync(ClaimCreateDto claimDto, string userId);
    Task<IEnumerable<ClaimDto>> GetClaimsByUserAsync(string userId);
}

