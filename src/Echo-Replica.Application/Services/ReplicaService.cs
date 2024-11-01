using Echo_Replica.Core.Entities;
using Echo_Replica.Core.Interfaces.Repositories;
using Echo_Replica.Core.Interfaces.Services;

namespace Echo_Replica.Application.Services;

public class ReplicaService : IReplicaService
{
    private readonly IReplicaRepository _replicaRepository;

    public ReplicaService(IReplicaRepository replicaRepository)
    {
        _replicaRepository = replicaRepository;
    }

    public async Task<Replica?> Get(Guid replicaGuid)
    {
        var replica = await _replicaRepository.Get(replicaGuid);

        return replica;
    }
    
    public async Task<Replica> Add(Replica replica)
    {
        var addedReplica = await _replicaRepository.Add(replica);
        return addedReplica;
    }
    
    public async Task UpdateUniqueWordCount(Guid replicaGuid, int uniqueWordCount)
    {
        await _replicaRepository.UpdateUniqueWordCountAsync(replicaGuid, uniqueWordCount);
    }
}