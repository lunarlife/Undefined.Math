using System.Numerics;

namespace Undefined.Math;

public struct Vector2<T> : IVector<T> where T : INumber<T>
{
    public static readonly Vector2<T> Zero = new(T.Zero, T.Zero);
    public static readonly Vector2<T> One = new(T.One, T.One);
    public static readonly Vector2<T> Left = new(-T.One, T.Zero);
    public static readonly Vector2<T> Right = new(T.One, T.Zero);
    public static readonly Vector2<T> Up = new(T.Zero, T.One);
    public static readonly Vector2<T> Down = new(T.Zero, -T.One);


    public int Dimension => 2;

    public T X;
    public T Y;

    public Vector2(T x, T y)
    {
        X = x;
        Y = y;
    }

    public T[] AsArray() => [X, Y];

    public T Length()
    {
        return (T)Convert.ChangeType(System.Math.Sqrt(((IConvertible)(X * X + Y * Y)).ToDouble(null)), typeof(T));
    }

    public Vector2<T> Normalized()
    {
        var length = Length();
        return new Vector2<T>(X / length, Y / length);
    }

    public Vector2<T1> Cast<T1>() where T1 : INumber<T1>
    {
        var type = typeof(T1);
        return new Vector2<T1>((T1)Convert.ChangeType(X, type), (T1)Convert.ChangeType(Y, type));
    }

    public Vector2<T> Offset(T x, T y) => new(X + x, Y + y);
    public Vector2<T> Offset(Vector2<T> offset) => Offset(offset.X, offset.Y);


    public Vector2<T> DirectionTo(Vector2<T> position) => (position - this).Normalized();

    public bool Equals(Vector2<T> other) => EqualityComparer<T>.Default.Equals(X, other.X) &&
                                            EqualityComparer<T>.Default.Equals(Y, other.Y);

    public float DistanceSqr(Vector2<T> other)
    {
        var v1 = (Vector2<float>)this;
        var v2 = (Vector2<float>)other;
        return (v1.X - v2.X) * (v1.X - v2.X) + (v1.Y - v2.Y) * (v1.Y - v2.Y);
    }

    public override bool Equals(object? obj) => obj is Vector2<T> other && Equals(other);

    public override int GetHashCode() => HashCode.Combine(X, Y);
    public override string ToString() => $"{{{X:F2};{Y:F2}}}";

    public static bool operator ==(Vector2<T> left, Vector2<T> right) =>
        left.X == right.X && left.Y == right.Y;

    public static bool operator !=(Vector2<T> left, Vector2<T> right) => !(left == right);

    public static implicit operator Vector2<float>(Vector2<T> vector)
    {
        if (vector is Vector2<float> v) return v;
        return new Vector2<float>(Convert.ToSingle(vector.X), Convert.ToSingle(vector.Y));
    }

    public static implicit operator Vector2<int>(Vector2<T> vector) =>
        new(Mathe.Floor(Convert.ToDouble(vector.X)), Mathe.Floor(Convert.ToDouble(vector.Y)));

    public static implicit operator Vector3<T>(Vector2<T> vector) => new(vector.X, vector.Y, T.Zero);
    public static bool operator >(Vector2<T> left, Vector2<T> right) => left.X > right.X || left.Y > right.Y;
    public static bool operator <(Vector2<T> left, Vector2<T> right) => left.X < right.X || left.Y < right.Y;
    public static bool operator <=(Vector2<T> left, Vector2<T> right) => left.X <= right.X || left.Y <= right.Y;
    public static bool operator >=(Vector2<T> left, Vector2<T> right) => left.X >= right.X || left.Y >= right.Y;

    public static Vector2<T> operator +(Vector2<T> left, Vector2<T> right) => new(left.X + right.X, left.Y + right.Y);
    public static Vector2<T> operator -(Vector2<T> left, Vector2<T> right) => new(left.X - right.X, left.Y - right.Y);
    public static Vector2<T> operator -(Vector2<T> vector) => new(-vector.X, -vector.Y);

    public static Vector2<T> operator *(Vector2<T> vector, T scalar) => new(vector.X * scalar, vector.Y * scalar);
    public static Vector2<T> operator *(T scalar, Vector2<T> vector) => new(vector.X * scalar, vector.Y * scalar);
    public static Vector2<T> operator *(Vector2<T> left, Vector2<T> right) => new(left.X * right.X, left.Y * right.Y);

    public static Vector2<T> operator /(Vector2<T> vector, T scalar) => new(vector.X / scalar, vector.Y / scalar);

    public static Vector2<T> operator /(Vector2<T> vector, Vector2<T> divisor) =>
        new(vector.X / divisor.X, vector.Y / divisor.Y);
}