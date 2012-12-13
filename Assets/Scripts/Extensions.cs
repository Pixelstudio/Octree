
using UnityEngine;

public static class Extensions
{
    public static bool Contains(this Bounds b, Bounds other)
    {
        return b.Contains(other.min) && b.Contains(other.max);
    }

}

