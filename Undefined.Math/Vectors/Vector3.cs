using System.Numerics;

namespace Undefined.Math;

public struct Vector3<T> : IVector<T> where T : INumber<T>
{
    public static readonly Vector3<T> Zero = new(T.Zero, T.Zero, T.Zero);
    public static readonly Vector3<T> One = new(T.One, T.One);
    public static readonly Vector3<T> Left = new(-T.One, T.Zero);
    public static readonly Vector3<T> Right = new(T.One, T.Zero);
    public static readonly Vector3<T> Up = new(T.Zero, T.One);
    public static readonly Vector3<T> Down = new(T.Zero, -T.One);
    public static readonly Vector3<T> Forward = new(T.Zero, T.Zero, T.One);
    public static readonly Vector3<T> Backward = new(T.Zero, T.Zero, -T.One);
    public int Dimension => 3;

    public T X;
    public T Y;
    public T Z;


    public Vector3(T x, T y, T z)
    {
        X = x;
        Y = y;
        Z = z;
    }

    public Vector3(T x, T y) : this(x, y, T.Zero)
    {
    }

    public Vector3(Vector3<T> vec, T z) : this(vec.X, vec.Y, z)
    {
    }

    public Vector3(Vector3<T> vec) : this(vec.X, vec.Y, vec.Z)
    {
    }

    public Vector3(Vector2<T> vec, T z) : this(vec.X, vec.Y, z)
    {
    }

    public Vector3(Vector2<T> vec) : this(vec.X, vec.Y, T.Zero)
    {
    }

    public Vector3<T1> Cast<T1>() where T1 : INumber<T1>
    {
        var type = typeof(T1);
        return new Vector3<T1>((T1)Convert.ChangeType(X, type), (T1)Convert.ChangeType(Y, type),
            (T1)Convert.ChangeType(Z, type));
    }

    public T[] AsArray() => [X, Y, Z];

    public T Length() =>
        (T)Convert.ChangeType(System.Math.Sqrt(Convert.ToDouble(X * X + Y * Y + Z * Z)),
            typeof(T));

    public static T Dot(Vector3<T> left, Vector3<T> right) => left.X * right.X + left.Y * right.Y + left.Z * right.Z;

    public static Vector3<T> Cross(Vector3<T> left, Vector3<T> right) => new(
        left.Y * right.Z - left.Z * right.Y, left.Z * right.X - left.X * right.Z, left.X * right.Y - left.Y * right.X);

    public Vector3<T> Normalized()
    {
        var length = Length();
        return new Vector3<T>(X / length, Y / length, Z / length);
    }

    public Vector3<T> Offset(T x, T y, T z) => new(X + x, Y + y, Z + z);
    public Vector3<T> Offset(Vector3<T> offset) => Offset(offset.X, offset.Y, offset.Z);
    public Vector3<T> DirectionTo(Vector3<T> position) => (position - this).Normalized();

    public float DistanceSqr(Vector3<T> other)
    {
        var v1 = (Vector3<float>)this;
        var v2 = (Vector3<float>)other;
        return (v1.X - v2.X) * (v1.X - v2.X) + (v1.Y - v2.Y) * (v1.Y - v2.Y) + (v1.Z - v2.Z) * (v1.Z - v2.Z);
    }
    public bool Equals(Vector3<T> other) => EqualityComparer<T>.Default.Equals(X, other.X) &&
                                            EqualityComparer<T>.Default.Equals(Y, other.Y) &&
                                            EqualityComparer<T>.Default.Equals(Z, other.Z);

    public override bool Equals(object? obj) => obj is Vector3<T> other && Equals(other);

    public override int GetHashCode() => HashCode.Combine(X, Y, Z);

    public static bool operator ==(Vector3<T> left, Vector3<T> right) =>
        left.X == right.X && left.Y == right.Y && left.Z == right.Z;

    public static bool operator !=(Vector3<T> left, Vector3<T> right) => !(left == right);

    public static implicit operator Vector2<T>(Vector3<T> vector) => new(vector.X, vector.Y);

    public static implicit operator Vector3<float>(Vector3<T> vector) =>
        new(Convert.ToSingle(vector.X), Convert.ToSingle(vector.Y), Convert.ToSingle(vector.Z));

    public static implicit operator Vector3<int>(Vector3<T> vector) => new(Mathe.Floor(Convert.ToDouble(vector.X)), Mathe.Floor(Convert.ToDouble(vector.Y)), Mathe.Floor(Convert.ToDouble(vector.Z)));

    public static bool operator >(Vector3<T> left, Vector3<T> right) =>
        left.X > right.X || left.Y > right.Y || left.Z > right.Z;

    public static bool operator <(Vector3<T> left, Vector3<T> right) =>
        left.X < right.X || left.Y < right.Y || left.Z < right.Z;

    public static bool operator <=(Vector3<T> left, Vector3<T> right) =>
        left.X <= right.X || left.Y <= right.Y || left.X <= right.Z;

    public static bool operator >=(Vector3<T> left, Vector3<T> right) =>
        left.X >= right.X || left.Y >= right.Y || left.Z >= right.Z;

    public static Vector3<T> operator +(Vector3<T> left, Vector3<T> right) =>
        new(left.X + right.X, left.Y + right.Y, left.Z + right.Z);

    public static Vector3<T> operator -(Vector3<T> left, Vector3<T> right) =>
        new(left.X - right.X, left.Y - right.Y, left.Z - right.Z);

    public static Vector3<T> operator *(Vector3<T> vector, T scalar) =>
        new(vector.X * scalar, vector.Y * scalar, vector.Z * scalar);

    public static Vector3<T> operator *(T scalar, Vector3<T> vector) =>
        new(vector.X * scalar, vector.Y * scalar, vector.Z * scalar);

    public static Vector3<T> operator /(Vector3<T> vector, T scalar) =>
        new(vector.X / scalar, vector.Y / scalar, vector.Z / scalar);

    public static Vector3<T> operator -(Vector3<T> vector) => new(-vector.X, -vector.Y, -vector.Z);

    public static Vector3<T> operator /(Vector3<T> vector, Vector3<T> scalar) =>
        new(vector.X / scalar.X, vector.Y / scalar.Y, vector.Z / scalar.Z);

    public static Vector3<T> operator *(Vector3<T> left, Vector3<T> right) =>
        new(left.X * right.X, left.Y * right.Y, left.Z * right.Z);

    public override string ToString() => $"{{{X:F2};{Y:F2};{Z:F2}}}";
}