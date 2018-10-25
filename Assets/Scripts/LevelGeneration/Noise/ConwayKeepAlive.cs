using UnityEngine.Assertions;

/// <summary>
/// This is a version of coonways game of life:
///     https://en.wikipedia.org/wiki/Conway%27s_Game_of_Life
///     
/// But, it won't kill anything. Only keep cells alive
/// </summary>
public class ConwayKeepAlive : BaseNoise
{
    private readonly int epochs;

    public ConwayKeepAlive(bool[,] matrix, int width, int length, int epochs) : base(matrix, width, length)
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
            for (x = 0; x < width; ++x)
            {
                for(y = 0; y < height; ++y)
                {
                    if (matrix[x, y] == false && NumberOfNeighgors(x, y) == 3)
                    {
                        matrix[x, y] = true;
                    }
                }
            }
        }

        return matrix;
    }
}
