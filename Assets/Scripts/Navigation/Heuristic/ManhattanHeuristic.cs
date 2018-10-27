using UnityEngine;

public static class ManhattanHeuristic
{
    public static float Calculate(IntVector2 v1, IntVector2 v2)
    {
        return Mathf.Abs(v2.X - v1.X) + Mathf.Abs(v2.Y - v1.Y);
    }
}
