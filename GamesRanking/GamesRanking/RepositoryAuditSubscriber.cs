using GamesRanking.Entities;
using GamesRanking.Repositories;

namespace GamesRanking;

//1a.stwórz serwis
//2a.serwis ma byc genryczny<> parametryzowany typem encji 
public class RepositoryAuditSubscriber<TEntity> where TEntity : class, IEntity
{

    private readonly IRepository<Audit> _auditRepository;
    private readonly IRepository<TEntity> _entityRepository;

    //3.mieć 2 parametry w konstruktorze z TEntity i Audit
    public RepositoryAuditSubscriber(
        IRepository<Audit> auditRepository,
        IRepository<TEntity> entityRepository)
    {
        _auditRepository = auditRepository;
        _entityRepository = entityRepository;
    }

    public void Subscribe()
    {
        //1b. który się subskybuje na repozytorium na event ItemAdded i ItemSaved
        //2b  parametryzowany na zmiany encji której sie subskrybuje
        _entityRepository.Saved += HandleSaved;
        _entityRepository.ItemAdded += HandleItemAdded;
    }

    private void HandleSaved(object? sender, EventArgs e)
    {
        _auditRepository.Save();
    }

    private void HandleItemAdded(object? sender, TEntity e)
    {
        var audit = new Audit
        {
            Timestamp = DateTime.UtcNow,
            Action = "GameAdded",
            Comment = e.ToString(),
        };
        _auditRepository.Add(audit);
    }
}
