using Echo_Replica.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Echo_Replica.Infrastructure.Configurations;

public class ReplicaWordConfiguration : IEntityTypeConfiguration<ReplicaWord>
{
    public void Configure(EntityTypeBuilder<ReplicaWord> builder)
    {
        builder.HasKey(c => c.Guid);
        
        builder.HasOne(c => c.Replica)
            .WithMany(c => c.ReplicaWords)
            .HasForeignKey(c => c.ReplicaId);
        
        builder.HasOne(c => c.Word)
            .WithMany(c => c.ReplicaWords)
            .HasForeignKey(c => c.WordId);
    }
}