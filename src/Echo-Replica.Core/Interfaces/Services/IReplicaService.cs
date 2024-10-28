using Echo_Replica.Core.Entities;

namespace Echo_Replica.Core.Interfaces.Services;

public interface IReplicaService
{
    public Replica GetById(Guid guid);
    
    public Guid Add(Replica replica);
    
    public void UpdateUniqueWordCount(Replica replica);
}