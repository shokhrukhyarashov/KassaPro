using System.ComponentModel.DataAnnotations;

namespace KassaPro.DTOs.Accounts;

public class AccountUpdateDto
{
    [Required]
    public ulong Id { get; set; }

    [Required]
    public string Account { get; set; } = null!;

    public string? Description { get; set; }

    [Required]
    public string AccountNumber { get; set; } = null!;
}
