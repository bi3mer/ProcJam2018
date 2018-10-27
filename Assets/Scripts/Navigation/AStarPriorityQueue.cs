using System.Collections.Generic;

// https://github.com/bi3mer/gmap377_leathGloves_inc/blob/master/Assets/Scripts/ControlledObjects/AI/Utility/PriorityQueue.cs
// I wrote this a while ago for a project in school. Please don't judge
// me for this code. It's recycled and this is a jam after all...
public class AStarPriorityQueue
{
    private List<AStarNode> queue = new List<AStarNode>();

    public int Size { get; private set; }

    public bool Empty => Size == 0;

    public AStarPriorityQueue()
    {
        Size = 0;
    }

    private int BinarySearch(float targetHeuristic)
    {
        int left = 0;
        int right = Size - 1;
        int mid = 0;
        bool found = false;
        bool rightPush = true;

        while (left <= right)
        {
            // C# doesn't require conversion to int, so get mid point
            mid = (left + right) / 2;
            float currentHeuristic = queue[mid].Cost;

            if (currentHeuristic == targetHeuristic)
            {
                found = true;
                break;
            }

            if (currentHeuristic > targetHeuristic)
            {
                left = mid + 1;
            }
            else
            {
                rightPush = false;
                right = mid - 1;
            }
        }

        if (!found && rightPush)
        {
            mid += 1;
        }

        return mid;
    }

    /// <summary>
    ///     Pop node from queue
    /// </summary>
    /// <returns></returns>
    public AStarNode PopNode()
    {
        int index = queue.Count - 1;
        AStarNode node = queue[index];
        queue.RemoveAt(index);
        --Size;

        return node;
    }

    /// <summary>
    ///     Add node to priority queue
    /// </summary>
    /// <param name="node"></param>
    public void AddNode(AStarNode node)
    {
        if (Empty == false)
        {
            queue.Insert(BinarySearch(node.Cost), node);
        }
        else
        {
            queue.Add(node);
        }

        ++Size;
    }
}