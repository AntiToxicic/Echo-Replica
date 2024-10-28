using Echo_Replica.Core.Common;

namespace Echo_Replica.Core.Entities;

public class Replica : BaseEntity
{
    public Replica(string name)
    {
        Name = name;
    }

    public string Name { get; private set; }
    public int UniqueWordCount { get; set; } = 0;
    
    public ICollection<ReplicaWord> ReplicaWords { get; set; } = new List<ReplicaWord>();
}