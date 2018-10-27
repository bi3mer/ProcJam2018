using UnityEngine;

public static class InadmissableHeuristic
{
    public static float Calculate(IntVector2 v1, IntVector2 v2)
    {
        return Random.Range(0f, 10000f);
    }
}