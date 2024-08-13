using System.Numerics;

namespace Undefined.Math;

public interface IVector
{
    public int Dimension { get; }
}

public interface IVector<out T> : IVector where T : INumber<T>
{
    public T[] AsArray();
}