using System.Collections.Generic;
using UnityEngine.Assertions;

public class AStarNode
{
    /// <summary>
    /// Step Count
    /// </summary>
    public float G { get; private set; }

    /// <summary>
    /// Heuristic Cost
    /// </summary>
    public float H { get; private set; }

    /// <summary>
    /// position for this node
    /// </summary>
    public IntVector2 Position { get; private set; }

    public AStarNode Parent { get; private set; }

    public float Cost => G + H;

    public AStarNode(float g, float h, AStarNode parent, IntVector2 position)
    {
        Assert.IsTrue(g >= 0);
        Assert.IsTrue(h >= 0);

        G = g;
        H = h;
        Parent = parent;
        Position = position;
    }

    public List<IntVector2> ReconstructPath()
    {
        List<IntVector2> path = new List<IntVector2>();
        RecursivelyConstructPath(path);

        return path;
    }

    private void RecursivelyConstructPath(List<IntVector2> path)
    {
        Parent?.RecursivelyConstructPath(path);
        path.Add(Position);
    }
}