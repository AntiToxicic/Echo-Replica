using Echo_Replica.Core.Entities;
using Echo_Replica.Core.Interfaces.Repositories;

namespace Echo_Replica.Infrastructure.Repositories;

public class ReplicaWordRepository : IReplicaWordRepository
{
    private readonly SqliteContext _context;

    public ReplicaWordRepository(SqliteContext context)
    {
        _context = context;
    }
    
    public Task<ReplicaWord> Get(Guid replicaWordGuid)
    {
        throw new NotImplementedException();
    }

    public Task<IReadOnlyCollection<ReplicaWord>> GetAllByReplicaGuid(Guid replicaGuid)
    {
        throw new NotImplementedException();
    }

    public Task<Guid> Add(ReplicaWord replicaWord)
    {
        throw new NotImplementedException();
    }

    public Task UpdateFrequency(Guid replicaWordGuid, int frequency)
    {
        throw new NotImplementedException();
    }
}