using UnityEngine.Assertions;

public abstract class BaseNoise
{
    protected bool[,] matrix;
    protected int width;
    protected int height;

    public BaseNoise(bool[,] matrix, int width, int height)
    {
        Assert.IsNotNull(matrix);
        Assert.AreEqual(matrix.GetLength(0), width);
        Assert.AreEqual(matrix.GetLength(1), height);

        this.matrix = matrix;
        this.width = width;
        this.height = height;
    }

    public abstract bool[,] ApplyNoise();

    protected int NumberOfNeighgors(int x, int y, bool alive=true)
    {
        int neighborCount = 0;

        // check right
        int testX = x + 1;
        int testY = y;
        if (testX < width && matrix[testX, testY] == alive)
        {
            ++neighborCount;
        }

        // check left
        testX = x - 1;
        if (testX >= 0 && matrix[testX, testY] == alive)
        {
            ++neighborCount;
        }

        // check down
        testX = x;
        testY = y - 1;
        if (testY >= 0 && matrix[testX, testY] == alive)
        {
            ++neighborCount;
        }

        // check up
        testY = y + 1;
        if (testY < height && matrix[testX, testY] == alive)
        {
            ++neighborCount;
        }

        return neighborCount;
    }
}
