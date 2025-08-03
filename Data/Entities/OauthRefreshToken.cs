﻿using System;
using System.Collections.Generic;

namespace KassaPro.Data.Entities;

public partial class OauthRefreshToken
{
    public string Id { get; set; } = null!;

    public string AccessTokenId { get; set; } = null!;

    public bool Revoked { get; set; }

    public DateTime? ExpiresAt { get; set; }
}
