using Echo_Replica.Core.Common;

namespace Echo_Replica.Core.Entities;

public class ReplicaWord : BaseEntity
{
    public Guid ReplicaId { get; set; }
    public Replica? Replica { get; set; }

    public Guid WordId { get; set; }
    public Word? Word { get; set; }

    public int Frequency { get; set; }
}