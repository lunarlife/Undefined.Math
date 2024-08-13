using System.Collections;
using System.Numerics;

namespace SkyBots.Api.Mathematics;

public readonly struct Cube<T> : IEnumerable<Vector3<T>> where T : INumber<T>
{
    public Vector3<T> Start { get; }
    public Vector3<T> End { get; }

    public Cube(Vector3<T> position, T width, T height, T length)
    {
        Preconditions.Min(width, T.Zero, nameof(width));
        Preconditions.Min(height, T.Zero, nameof(height));
        Preconditions.Min(length, T.Zero, nameof(length));
        Start = position;
        End = new Vector3<T>(position.X + width, position.Y + height, position.Z + length);
    }

    public Cube(Vector3<T> start, Vector3<T> end)
    {
        var xStart = Mathe.Min(start.X, end.X);
        var yStart = Mathe.Min(start.Y, end.Y);
        var zStart = Mathe.Min(start.Z, end.Z);
        var xEnd = Mathe.Max(start.X, end.X);
        var yEnd = Mathe.Max(start.Y, end.Y);
        var zEnd = Mathe.Max(start.Z, end.Z);
        Start = new Vector3<T>(xStart, yStart, zStart);
        End = new Vector3<T>(xEnd, yEnd, zEnd);
    }

    public Cube(T startX, T startY, T startZ, T endX, T endY, T endZ)
    {
        var xStart = Mathe.Min(startX, endX);
        var yStart = Mathe.Min(startY, endY);
        var zStart = Mathe.Min(startZ, endZ);
        var xEnd = Mathe.Max(startX, endX);
        var yEnd = Mathe.Max(startY, endY);
        var zEnd = Mathe.Max(startZ, endZ);
        Start = new Vector3<T>(xStart, yStart, zStart);
        End = new Vector3<T>(xEnd, yEnd, zEnd);
    }

    public Cube<T> Intersection(Cube<T> other)
    {
        var start = Mathe.Max(Start, other.Start);
        var end = Mathe.Min(End, other.End);
        return new Cube<T>(start, end);
    }

    public bool TryIntersection(Cube<T> other, out Cube<T> result)
    {
        if (Start > other.End || other.Start > End)
        {
            result = new Cube<T>();
            return false;
        }
        result = Intersection(other);
        return true;
    }

    public IEnumerator<Vector3<T>> GetEnumerator()
    {
        for (var x = Start.X; x <= End.X; x++)
        for (var y = Start.Y; y <= End.Y; y++)
        for (var z = Start.Z; z <= End.Z; z++)
            yield return new Vector3<T>(x, y, z);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}