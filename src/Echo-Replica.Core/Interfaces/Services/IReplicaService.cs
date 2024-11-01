using Echo_Replica.Core.Entities;

namespace Echo_Replica.Core.Interfaces.Services;

public interface IReplicaService
{
    public Task<Replica?> Get(Guid replicaGuid);
    
    public Task<Replica> Add(Replica replica);
    
    public Task UpdateUniqueWordCount(Guid replicaGuid, int uniqueWordCount);
}