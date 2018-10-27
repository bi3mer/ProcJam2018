using UnityEngine;

public enum Heuristics
{
    Euclidian = 0,
    Manhattan,
    Inadmissable
}

public static class HeuristicsExtensions
{
    public static float Calculate(this Heuristics heuristic, IntVector2 v1, IntVector2 v2)
    {
        switch (heuristic)
        {
            case Heuristics.Euclidian:
                return EuclidianHeuristic.Calculate(v1, v2);
            case Heuristics.Manhattan:
                return ManhattanHeuristic.Calculate(v1, v2);
            case Heuristics.Inadmissable:
                return InadmissableHeuristic.Calculate(v1, v2);
            default:
                Debug.LogError($"Invalid Heuristic: {heuristic}");
                return 0f;
        }
    }
}