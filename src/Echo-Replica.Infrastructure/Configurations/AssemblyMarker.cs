using System.Reflection;

namespace Echo_Replica.Infrastructure.Configurations;

public abstract class AssemblyMarker
{
    public static readonly Assembly Assembly = typeof(AssemblyMarker).Assembly;
}