﻿namespace VeridiCore.Domain.Common;

public abstract class BaseEntity
{
    public Guid Id { get; protected set; }
    public bool IsActive { get; protected set; }
    public DateTime CreatedAt { get; protected set; }
    public DateTime? UpdatedAt { get; protected set; }
    public DateTime? DeletedAt { get; protected set; }

    protected BaseEntity()
    {
        Id = Guid.NewGuid();
        CreatedAt = DateTime.UtcNow;
        IsActive = true;
    }
}