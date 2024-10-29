using Echo_Replica.Core.Entities;
using Echo_Replica.Core.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Echo_Replica.Infrastructure.Repositories;

public class ReplicaRepository : IReplicaRepository
{
    private readonly SqliteContext _context;

    public ReplicaRepository(SqliteContext context)
    {
        _context = context;
    }
    
    public Task<Replica?> Get(Guid replicaGuid) =>
        _context.Replicas.FirstOrDefaultAsync(c => c.Guid == replicaGuid);

    public async Task<Replica> Add(Replica replica)
    {
        _context.Replicas.Add(replica);
        await _context.SaveChangesAsync();

        return replica;
    }

    public async Task UpdateUniqueWordCountAsync(Guid replicaGuid, int uniqueWordCount)
    {
        var replica = await _context.Replicas.FindAsync(replicaGuid);
        
        if (replica == null)
        {
            return;
        }

        replica.UniqueWordCount = uniqueWordCount;

        await _context.SaveChangesAsync();
    }
}