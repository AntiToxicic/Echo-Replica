using Echo_Replica.Core.Entities;

namespace Echo_Replica.Core.Interfaces.Repositories;

public interface IReplicaWordRepository
{
    public Task<ReplicaWord?> Get(Guid replicaWordGuid);
    
    public Task<IReadOnlyCollection<ReplicaWord>> GetAllByReplicaGuid(Guid replicaGuid);
    
    public Task<ReplicaWord> Add(ReplicaWord replicaWord);

    public Task UpdateFrequency(Guid replicaWordGuid, int frequency);
}