﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace MyBank.Repository.Interceptors;

public class AuditDbContextInterceptor : SaveChangesInterceptor
{
    private static readonly Dictionary<EntityState, Action<DbContext, IAuditEntity>> Behaviors = new()
    {
        { EntityState.Added, AddBehavior },
        { EntityState.Modified, ModifiedBehavior }
    };

    private static void AddBehavior(DbContext context, IAuditEntity auditEntity)
    {
        auditEntity.Created = DateTime.UtcNow;
        context.Entry(auditEntity).Property(x => x.Updated).IsModified = false;
    }

    private static void ModifiedBehavior(DbContext context, IAuditEntity auditEntity)
    {
        auditEntity.Updated = DateTime.UtcNow;
        context.Entry(auditEntity).Property(x => x.Created).IsModified = false;
    }


    public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
    {
        foreach (var entityEntry in eventData.Context!.ChangeTracker.Entries().ToList())
        {
            if (entityEntry.Entity is not IAuditEntity auditEntity) continue;

            Behaviors[entityEntry.State](eventData.Context, auditEntity);

        }

        return base.SavingChangesAsync(eventData, result, cancellationToken);
    }
}
