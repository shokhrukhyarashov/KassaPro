using System.ComponentModel.DataAnnotations;

namespace KassaPro.DTOs
{
    public class BrandDto
    {
        [Required]
        public string Name { get; set; } = string.Empty;

        public string? Image { get; set; } // filename or path
    }
}
