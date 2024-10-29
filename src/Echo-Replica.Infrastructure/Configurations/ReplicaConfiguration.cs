using Echo_Replica.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Echo_Replica.Infrastructure.Configurations;

public class ReplicaConfiguration : IEntityTypeConfiguration<Replica>
{
    public void Configure(EntityTypeBuilder<Replica> builder)
    {
        builder.HasKey(c => c.Guid);
    }
}