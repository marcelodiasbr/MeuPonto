﻿using System.ComponentModel.DataAnnotations;

namespace System.ComponentModel;

public abstract class IdentityTableEntity
{
    public int? Id { get; set; }

    public DateTime? CreationDate { get; set; }

    [Timestamp]
    public byte[]? Version { get; set; }
}
