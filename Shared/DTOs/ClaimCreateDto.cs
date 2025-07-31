using System;
using Domain.Enums;
namespace Shared.DTOs;

public class ClaimCreateDto
{
    public string Title { get; set; }
    public string Description { get; set; }
    public ClaimType Type { get; set; }
}
