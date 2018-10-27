using UnityEngine;

public static class EuclidianHeuristic
{
    public static float Calculate(IntVector2 v1, IntVector2 v2)
    {
        return Mathf.Sqrt(Mathf.Pow(v2.X - v1.X, 2) + Mathf.Pow(v2.Y - v1.X, 2));
    }
}
