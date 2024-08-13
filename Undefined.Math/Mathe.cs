using System.Numerics;

namespace SkyBots.Api.Mathematics;

public static class Mathe
{
    public static bool TryClamp<T>(T value, T min, T max) where T : INumber<T> => Clamp(value, min, max) == value;

    public static bool TryClamp<T>(Vector3<T> value, Vector3<T> min, Vector3<T> max) where T : INumber<T> =>
        Clamp(value, min, max) == value;

    public static bool TryClamp<T>(Vector2<T> value, Vector2<T> min, Vector2<T> max) where T : INumber<T> =>
        Clamp(value, min, max) == value;

    public static T Clamp<T>(T value, T min, T max) where T : INumber<T> =>
        value < min ? min : value > max ? max : value;

    public static Vector2<T> Clamp<T>(Vector2<T> value, Vector2<T> min, Vector2<T> max) where T : INumber<T> =>
        new(Clamp(value.X, min.X, max.X), Clamp(value.Y, min.Y, max.Y));

    public static Vector3<T> Clamp<T>(Vector3<T> value, Vector3<T> min, Vector3<T> max) where T : INumber<T> =>
        new(Clamp(value.X, min.X, max.X), Clamp(value.Y, min.Y, max.Y), Clamp(value.Z, min.Z, max.Z));

    public static double ToRadians(double degrees) => 0.017453292519943295d * degrees;
    public static float ToDegrees(double radians) => (float)(radians * 180d / Math.PI);

    public static T Min<T>(T value1, T value2) where T : INumber<T> => value1 < value2 ? value1 : value2;
    public static T Max<T>(T value1, T value2) where T : INumber<T> => value1 > value2 ? value1 : value2;

    public static Vector2<T> Min<T>(Vector2<T> value, Vector2<T> value2) where T : INumber<T> =>
        new(Min(value.X, value2.X), Min(value.Y, value2.Y));

    public static Vector3<T> Min<T>(Vector3<T> value, Vector3<T> value2) where T : INumber<T> =>
        new(Min(value.X, value2.X), Min(value.Y, value2.Y), Min(value.Z, value2.Z));

    public static Vector2<T> Max<T>(Vector2<T> value, Vector2<T> value2) where T : INumber<T> =>
        new(Max(value.X, value2.X), Max(value.Y, value2.Y));

    public static Vector3<T> Max<T>(Vector3<T> value, Vector3<T> value2) where T : INumber<T> =>
        new(Max(value.X, value2.X), Max(value.Y, value2.Y), Max(value.Z, value2.Z));

    public static int Floor(double var0)
    {
        var var2 = (int)var0;
        return var0 < var2 ? var2 - 1 : var2;
    }
}