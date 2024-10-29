using Echo_Replica.Core.Entities;

namespace Echo_Replica.Core.Interfaces.Services;

public interface IReplicaWordService
{
    public Task<ReplicaWord> Get(Guid replicaWordGuid);
    
    public Task<IReadOnlyCollection<ReplicaWord>> GetAllByReplicaGuid(Guid replicaGuid);
    
    public Task<Guid> Add(ReplicaWord replicaWord);

    public Task UpdateFrequency(Guid replicaWordGuid, int frequency);
} 