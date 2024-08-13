using System.Numerics;

namespace Undefined.Math.Vectors;

public interface IVector
{
    public int Dimension { get; }
}

public interface IVector<T> : IVector where T : INumber<T>
{
    public T[] AsArray();
    public Span<T> AsSpan();
}