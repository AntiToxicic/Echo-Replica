using Echo_Replica.Core.Entities;
using Echo_Replica.Core.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Echo_Replica.Infrastructure.Repositories;

public class ReplicaWordRepository : IReplicaWordRepository
{
    private readonly SqliteContext _context;

    public ReplicaWordRepository(SqliteContext context)
    {
        _context = context;
    }
    
    public Task<ReplicaWord?> Get(Guid replicaWordGuid) =>
        _context.ReplicaWords.FirstOrDefaultAsync(c => c.Guid == replicaWordGuid);

    public async Task<IReadOnlyCollection<ReplicaWord>> GetAllByReplicaGuid(Guid replicaGuid) =>
        await _context.ReplicaWords.Where(c => c.ReplicaId == replicaGuid).ToListAsync();

    public async Task<ReplicaWord> Add(ReplicaWord replicaWord)
    {
        _context.ReplicaWords.Add(replicaWord);
        await _context.SaveChangesAsync();

        return replicaWord;
    }

    public async Task UpdateFrequency(Guid replicaWordGuid, int frequency)
    {
        var replica = await _context.ReplicaWords.FindAsync(replicaWordGuid);
        
        if (replica == null)
        {
            return;
        }

        replica.Frequency = frequency;

        await _context.SaveChangesAsync();
    }
}