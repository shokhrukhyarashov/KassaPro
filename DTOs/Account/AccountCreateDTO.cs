using System.ComponentModel.DataAnnotations;

namespace KassaPro.DTOs.Accounts;

public class AccountCreateDto
{
    [Required]
    public string Account { get; set; } = null!;

    public string? Description { get; set; }

    [Required]
    public double Balance { get; set; }

    [Required]
    public string AccountNumber { get; set; } = null!;
}
