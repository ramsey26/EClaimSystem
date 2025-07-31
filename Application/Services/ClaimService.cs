using System;
using Application.Interfaces;
using Domain.Entities;
using Domain.Enums;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using Shared.DTOs;

namespace Application.Services;

public class ClaimService(AppDbContext context) : IClaimService
{
    public async Task<IEnumerable<ClaimDto>> GetClaimsByUserAsync(string userId)
    {
        var claims = await context.Claims
            .Where(c => c.SubmittedById == userId)
            .Include(c => c.SubmittedBy)
            .OrderByDescending(c => c.SubmittedAt)
            .Select(c => new ClaimDto
            {
                Id = c.Id,
                Title = c.Title,
                Description = c.Description,
                Type = c.Type.ToString(),
                Status = c.Status.ToString(),
                SubmittedAt = c.SubmittedAt,
                SubmittedBy = c.SubmittedBy.FullName
            })
            .ToListAsync();

        return claims;
    }


    public async Task<int> SubmitClaimAsync(ClaimCreateDto claimDto, string userId)
    {
        var claim = new Claim
        {
            Title = claimDto.Title,
            Description = claimDto.Description,
            Type = claimDto.Type,
            Status = ClaimStatus.Submitted,
            SubmittedById = userId,
            SubmittedAt = DateTime.UtcNow
        };

        context.Claims.Add(claim);
        await context.SaveChangesAsync();
        return claim.Id;
    }

}
