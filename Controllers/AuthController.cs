

using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using KassaPro.Data.Entities;
using KassaPro.DTOs.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace KassaPro.Controllers.Api.V1;

[ApiController]
[Route("api/v1")]
public class AuthController : ControllerBase
{
    private readonly PosContext _context;
    private readonly IConfiguration _config;

    public AuthController(PosContext context, IConfiguration config)
    {
        _context = context;
        _config = config;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginDto dto)
    {
        var admin = await _context.Admins.Include(a => a.AdminRole).FirstOrDefaultAsync(a => a.Email == dto.Email);
        if (admin == null || !BCrypt.Net.BCrypt.Verify(dto.Password, admin.Password))
        {
            return Unauthorized(new { message = "Wrong credentials! Please input correct email and password." });
        }
var claims = new[]
{
    new Claim(ClaimTypes.NameIdentifier, admin.Id.ToString()),
    new Claim(ClaimTypes.Name, admin.FName ?? string.Empty),
    new Claim(ClaimTypes.Email, admin.Email ?? string.Empty),
    new Claim(ClaimTypes.Role, admin.AdminRole?.Name ?? "Admin")
};

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]!));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: _config["Jwt:Issuer"],
            audience: _config["Jwt:Audience"],
            claims: claims,
            expires: DateTime.UtcNow.AddHours(10),
            signingCredentials: creds
        );

        return Ok(new
        {
            message = "You are logged in",
            token = new JwtSecurityTokenHandler().WriteToken(token)
        });
    }

    [Authorize]
    [HttpPost("change-password")]
    public async Task<IActionResult> ChangePassword([FromBody] PasswordChangeDto dto)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        var adminId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        var admin = await _context.Admins.FindAsync(Convert.ToInt64(adminId));
        if (admin == null)
        {
            return NotFound(new { message = "Admin not found" });
        }

        admin.Password = BCrypt.Net.BCrypt.HashPassword(dto.ConfirmPassword);
        _context.Admins.Update(admin);
        await _context.SaveChangesAsync();

        return Ok(new { message = "Password changed successfully." });
    }

    [Authorize]
    [HttpGet("profile")]
    public async Task<IActionResult> Profile()
    {
        var adminId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        var admin = await _context.Admins.Include(a => a.AdminRole).FirstOrDefaultAsync(a => a.Id == Convert.ToUInt64(adminId));
        if (admin == null)
            return NotFound(new { message = "Profile not found" });

        var result = new
        {
            admin.Id,
            admin.FName,
            admin.Email,
            Role = new
            {
                admin.AdminRole?.Name,
                Modules = admin.AdminRole?.Modules != null ? System.Text.Json.JsonSerializer.Deserialize<List<string>>(admin.AdminRole.Modules) : new List<string>()
            }
        };

        return Ok(result);
    }

    [Authorize]
    [HttpPost("logout")]
    public IActionResult Logout()
    {
        // JWT logout - usually handled client-side by deleting the token
        return Ok(new { success = true, message = "Successfully logged out" });
    }
}
