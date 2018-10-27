using System.Collections.Generic;

public static class AStar
{
    private static int width;
    private static int height;
    private static bool[,] board;
    private static Heuristics heuristic;
    private static IntVector2 end;

    public static List<IntVector2> GetPath(bool[,] board, IntVector2 start, IntVector2 end, Heuristics heuristic)
    {
        AStar.board = board;
        width = board.GetLength(0);
        height = board.GetLength(1);
        AStar.end = end;

        AStarPriorityQueue queue = new AStarPriorityQueue();
        HashSet<float> exploredPositions = new HashSet<float>() { start.Hashf };
        PopulateQueue(queue, new AStarNode(0, 0, null, start));

        while (queue.Empty == false)
        {
            AStarNode node = queue.PopNode();
            IntVector2 position = node.Position;
            float hashf = position.Hashf;

            if (exploredPositions.Contains(hashf) == false)
            {
                if (position.Equals(end))
                {
                    return node.ReconstructPath();
                }
                else
                {
                    exploredPositions.Add(hashf);
                    PopulateQueue(queue, node);
                }
            }
        }

        return null;
    }

    public static void PopulateQueue(AStarPriorityQueue queue, AStarNode parent)
    {
        List<IntVector2> neighbors = GetAvailableNeighbors(board, parent.Position);

        int count = neighbors.Count;
        for (int i = 0; i < count; ++i)
        {
            queue.AddNode(new AStarNode(
                parent.G + 1,
                heuristic.Calculate(neighbors[i], end),
                parent,
                neighbors[i]));
        }
    }

    public static List<IntVector2> GetAvailableNeighbors(bool[,] board, IntVector2 position)
    {
        List<IntVector2> neighbors = new List<IntVector2>();

        // check right
        int testX = position.X + 1;
        int testY = position.Y;
        if (testX < width && board[testX, testY])
        {
            neighbors.Add(new IntVector2(testX, testY));
        }

        // check left
        testX = position.X - 1;
        if (testX >= 0 && board[testX, testY])
        {
            neighbors.Add(new IntVector2(testX, testY));
        }

        // check down
        testX = position.X;
        testY = position.Y - 1;
        if (testY >= 0 && board[testX, testY])
        {
            neighbors.Add(new IntVector2(testX, testY));
        }

        // check up
        testY = position.Y + 1;
        if (testY < height && board[testX, testY])
        {
            neighbors.Add(new IntVector2(testX, testY));
        }

        return neighbors;
    }
}
