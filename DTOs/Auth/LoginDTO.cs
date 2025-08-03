using System.ComponentModel.DataAnnotations;

namespace KassaPro.DTOs.Auth;

public class LoginDto
{
    [Required]
    public string Email { get; set; } = null!;

    [Required]
    public string Password { get; set; } = null!;
}
