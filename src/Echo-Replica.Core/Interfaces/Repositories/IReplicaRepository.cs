using Echo_Replica.Core.Entities;

namespace Echo_Replica.Core.Interfaces.Repositories;

public interface IReplicaRepository
{
    public Task<Replica?> Get(Guid replicaGuid);
    
    public Task<Replica> Add(Replica replica);

    public Task UpdateUniqueWordCountAsync(Guid replicaGuid, int uniqueWordCount);
}