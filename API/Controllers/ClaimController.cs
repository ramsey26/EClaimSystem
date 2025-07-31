using System.Security.Claims;
using Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shared.DTOs;

namespace API.Controllers
{
    [Authorize(Roles = "Claimant")]
    [ApiController]
    [Route("api/[controller]")]
    public class ClaimsController(IClaimService claimService, IHttpContextAccessor accessor) : ControllerBase
    {
        private readonly IClaimService _claimService = claimService;
        private readonly IHttpContextAccessor _httpContextAccessor = accessor;

        [HttpGet("my")]
        public async Task<IActionResult> GetMyClaims()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var claims = await _claimService.GetClaimsByUserAsync(userId);
            return Ok(claims);
        }

        [HttpPost]
        public async Task<IActionResult> SubmitClaim([FromBody] ClaimCreateDto dto)
        {
            var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var claimId = await _claimService.SubmitClaimAsync(dto, userId);
            return Ok(new { claimId });
        }
    }

}
