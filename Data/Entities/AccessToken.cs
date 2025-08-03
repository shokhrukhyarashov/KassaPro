using System;
using System.Collections.Generic;

namespace KassaPro.Data.Entities;

public partial class AccessToken
{
     public ulong Id { get; set; }

    public string TokenableType { get; set; } = null!; 
    public ulong AdminId { get; set; }  
    public virtual Admin? Admin { get; set; }          
    public string Name { get; set; } = null!;
    public string Token { get; set; } = null!;

    public string? Abilities { get; set; }      
    public DateTime? LastUsedAt { get; set; }
    public DateTime? CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}
