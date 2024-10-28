using Echo_Replica.Core.Entities;

namespace Echo_Replica.Core.Interfaces.Repositories;

public interface IReplicaRepository
{
    public Replica GetById(Guid guid);
    
    public Guid Add(Replica replica);
    
    public Guid UpdateUniqueWordCount(Replica replica);
    
    
}