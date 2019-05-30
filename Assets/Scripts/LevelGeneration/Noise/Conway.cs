using UnityEngine.Assertions;

public class Conway : BaseNoise
{
    private readonly int epochs;

    public Conway(bool[,] matrix, int width, int length, int epochs) : base(matrix, width, length)
    {
        Assert.IsTrue(epochs > 0);
        this.epochs = epochs;
    }

    public override bool[,] ApplyNoise()
    {
        int x;
        int y;

        for (int epoch = 0; epoch < epochs; ++epoch)
        {
            bool[,] newMatrix = new bool[width, height];

            for (x = 0; x < width; ++x)
            {
                for (y = 0; y < height; ++y)
                {
                    int neighborCount = NumberOfNeighgors(x, y, alive:true);

                    if (matrix[x, y] == true)
                    {
                        if (neighborCount < 2)
                        {
                            newMatrix[x, y] = false;
                        }
                        else if (neighborCount > 3)
                        {
                            newMatrix[x, y] = false;
                        }
                    }
                    else if (neighborCount == 3)
                    {
                        newMatrix[x, y] = true;
                    }
                }
            }

            matrix = newMatrix;
        }

        return matrix;
    }
}
