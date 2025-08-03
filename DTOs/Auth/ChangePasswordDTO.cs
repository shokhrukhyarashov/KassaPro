using System.ComponentModel.DataAnnotations;

namespace KassaPro.DTOs.Auth;

public class PasswordChangeDto
{
    [Required]
    [MinLength(8)]
    [Compare("ConfirmPassword")]
    public string Password { get; set; } = null!;

    [Required]
    public string ConfirmPassword { get; set; } = null!;
}
