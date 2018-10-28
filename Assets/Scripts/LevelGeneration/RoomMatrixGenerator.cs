using System.Collections.Generic;
using UnityEngine.Assertions;
using UnityEngine;

// start is always bottom left and finish is always top right
public class RoomMatrixGenerator
{
    private readonly int width;
    private readonly int height;

    public RoomMatrixGenerator(int width, int height)
    {
        Assert.IsTrue(width > 0);
        Assert.IsTrue(height > 0);

        this.width = width;
        this.height = height;
    }

    // @todo: should remove the invalid leaf, but it isn't important right now
    public bool[,] GenerateRoomMatrix()
    {
        int endX = width - 1;
        int endY = height - 1;

        bool[,] matrix = new bool[width, height];
        matrix[0, 0] = true;
        bool pathFound = false;

        List<IntVector2> leafs = new List<IntVector2>() { new IntVector2(0, 0) };

        while (pathFound == false)
        {
            int leafIndex;
            int leafX = 0;
            int leafY = 0;
            for (leafIndex = 0; leafIndex < leafs.Count; ++leafIndex)
            {
                leafX = leafs[leafIndex].X;
                leafY = leafs[leafIndex].Y;
                List<IntVector2> directions = GetDirections(matrix, leafX, leafY);

                if (directions.Count > 0)
                {
                    IntVector2 direction = directions[Random.Range(0, directions.Count)];
                    int newLeafX = leafX + direction.X;
                    int newLeafY = leafY + direction.Y;

                    matrix[newLeafX, newLeafY] = true;
                    leafs.Add(new IntVector2(newLeafX, newLeafY));

                    if ((newLeafX == endX && newLeafY == endY))
                    {
                        pathFound = true;
                    }
                    else if (newLeafX + 1 == endX && newLeafY + 1 == endY)
                    {
                        pathFound = true;

                        if (Random.Range(0f, 1f) > 0.5f)
                        {
                            matrix[endX - 1, endY] = true;
                        }
                        else
                        {
                            matrix[endX, endY - 1] = true;
                        }

                        matrix[endX, endY] = true;
                    }

                    break;
                }
            }

            // remove leaf it has no other directions to offer
            if (GetDirections(matrix, leafX, leafY).Count == 0)
            {
                if (leafIndex >= 0 && leafIndex < leafs.Count)
                {
                    leafs.RemoveAt(leafIndex);
                }
                else
                {
                    // @note: i'm not sure why it would ever get here but it is possible.
                    //        If it it is at this point, then we should scrap previous
                    //        work and try again
                    return GenerateRoomMatrix();
                }
            }

            leafs.Shuffle();
        }

        return matrix;
    }

    private List<IntVector2> GetDirections(bool[,] matrix, int x, int y)
    {
        List<IntVector2> directions = new List<IntVector2>();

        // check right
        int testX = x + 1;
        int testY = y;
        if (testX < width && matrix[testX, testY] == false && HasNeighbor(matrix, testX, testY) == false)
        {
            directions.Add(IntVector2.Right);
        }

        // check left
        testX = x - 1;
        if (testX >= 0 && matrix[testX, testY] == false && HasNeighbor(matrix, testX, testY) == false)
        {
            directions.Add(IntVector2.Left);
        }

        // check down
        testX = x;
        testY = y - 1;
        if (testY >= 0 && matrix[testX, testY] == false && HasNeighbor(matrix, testX, testY) == false)
        {
            directions.Add(IntVector2.Down);
        }

        // check up
        testY = y + 1;
        if (testY < height && matrix[testX, testY] == false && HasNeighbor(matrix, testX, testY) == false)
        {
            directions.Add(IntVector2.Up);
        }

        return directions;
    }

    private bool HasNeighbor(bool[,] matrix, int x, int y)
    {
        int neighborCount = 0;

        // check right
        int testX = x + 1;
        int testY = y;
        if (testX < width && matrix[testX, testY])
        {
            ++neighborCount;
        }

        // check left
        testX = x - 1;
        if (testX >= 0 && matrix[testX, testY])
        {
            ++neighborCount;
        }

        // check down
        testX = x;
        testY = y - 1;
        if (testY >= 0 && matrix[testX, testY])
        {
            ++neighborCount;
        }

        // check up
        testY = y + 1;
        if (testY < height && matrix[testX, testY])
        {
            ++neighborCount;
        }

        //return neighborCount > 1;
        return neighborCount > 1;
    }
}