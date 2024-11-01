using Echo_Replica.Core.Entities;
using Echo_Replica.Core.Interfaces.Repositories;
using Echo_Replica.Core.Interfaces.Services;

namespace Echo_Replica.Application.Services;

public class ReplicaWordService : IReplicaWordService
{
    private readonly IReplicaWordRepository _replicaWordRepository;

    public ReplicaWordService(IReplicaWordRepository replicaWordRepository)
    {
        _replicaWordRepository = replicaWordRepository;
    }

    public async Task<ReplicaWord?> Get(Guid replicaWordGuid)
    {
        var replicaWord = await _replicaWordRepository.Get(replicaWordGuid);

        return replicaWord;
    }
    
    public async Task<IReadOnlyCollection<ReplicaWord>> GetAllByReplicaGuid(Guid replicaGuid)
    {
        return await _replicaWordRepository.GetAllByReplicaGuid(replicaGuid);
    }
    
    public async Task<ReplicaWord> Add(ReplicaWord replicaWord)
    {
        var addedReplicaWord = await _replicaWordRepository.Add(replicaWord);
        return addedReplicaWord;
    }

    public async Task UpdateFrequency(Guid replicaWordGuid, int frequency)
    {
        await _replicaWordRepository.UpdateFrequency(replicaWordGuid, frequency);
    }
}