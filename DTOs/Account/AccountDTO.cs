using System.ComponentModel.DataAnnotations;

namespace KassaPro.DTOs
{
    public class AccountDto
    {
        [Required]
        public string Account { get; set; } = string.Empty;

        public string? Description { get; set; }

        [Required]
        public decimal Balance { get; set; }

        [Required]
        public string AccountNumber { get; set; } = string.Empty;
    }
}
