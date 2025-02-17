﻿using FluentValidation.Results;

namespace Sakura.Core;

public abstract class Entity
{
    public Entity()
    {
        Id = Guid.NewGuid();
    }
    public virtual Guid Id { get; protected set; }
    public virtual DateTime Created { get; protected set; }
    public virtual DateTime Updated { get; protected set; }
    public virtual ValidationResult ResultValidation { get; protected set; }
    public virtual void SetUpdated()
    {
        Updated = DateTime.UtcNow;
    }
    public virtual void SetCreated(DateTime? createdAt = null)
    {
        Created = Updated = createdAt ?? DateTime.UtcNow;
    }
    public abstract bool IsValid();

    public override string ToString()
    {
        return this.GetType().ToString() + " - " + Id.ToString();
    }

}
