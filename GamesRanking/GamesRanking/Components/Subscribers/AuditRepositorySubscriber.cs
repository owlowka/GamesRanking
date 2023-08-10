using GamesRanking.Data.Entities;
using GamesRanking.Data.Repositories;

namespace GamesRanking.Components.Subscribers;

public class AuditRepositorySubscriber<TEntity> : RepositorySubscriberBase<TEntity>
    where TEntity : class, IEntity
{
    private readonly IRepository<Audit> _auditRepository;

    public AuditRepositorySubscriber(
        IRepository<Audit> auditRepository,
        IRepository<TEntity> entityRepository)
        : base(entityRepository)
    {
        _auditRepository = auditRepository;
    }

    protected override void HandleSaved(object? sender, EventArgs e)
    {
        var audit = new Audit
        {
            Timestamp = DateTime.UtcNow,
            Action = $"{EntityName} Saved",
            Comment = e.ToString(),
        };
        _auditRepository.Add(audit);
        _auditRepository.Save();
    }

    protected override void HandleItemAdded(object? sender, TEntity e)
    {
        var audit = new Audit
        {
            Timestamp = DateTime.UtcNow,
            Action = $"{EntityName} Added",
            Comment = e.ToString(),
        };
        _auditRepository.Add(audit);
    }

    protected override void HandleItemRemoved(object? sender, TEntity e)
    {
        var audit = new Audit
        {
            Timestamp = DateTime.UtcNow,
            Action = $"{EntityName} Removed",
            Comment = e.ToString(),
        };
        _auditRepository.Add(audit);
    }
}
