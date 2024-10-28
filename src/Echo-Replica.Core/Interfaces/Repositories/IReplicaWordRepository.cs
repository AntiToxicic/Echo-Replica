using System.Collections.ObjectModel;
using Echo_Replica.Core.Entities;

namespace Echo_Replica.Core.Interfaces.Repositories;

public interface IReplicaWordRepository
{
    public Task<Collection<ReplicaWord>> GetWordsByReplicaGuid(Guid replicaGuid);
}