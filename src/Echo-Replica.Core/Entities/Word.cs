using Echo_Replica.Core.Common;
using Echo_Replica.Core.Enums;

namespace Echo_Replica.Core.Entities;

public class Word : BaseEntity
{
    public Guid ReplicaId { get; set; }
    
    public string Text { get; set; }
    public PartOfSpeech PartOfSpeech { get; set; }
    
    public IList<ReplicaWord> ReplicaWords { get; private set; } = new List<ReplicaWord>();
}