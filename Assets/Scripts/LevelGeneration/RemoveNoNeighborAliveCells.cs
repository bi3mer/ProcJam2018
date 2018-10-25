public class RemoveNoNeighborAliveCells : BaseNoise
{
    public RemoveNoNeighborAliveCells(bool[,] matrix, int width, int height) : base(matrix, width, height)
    {
    }

    public override bool[,] ApplyNoise()
    {
        for (int x = 0; x < width; ++x)
        {
            for(int y = 0; y < height; ++y)
            {
                if (NumberOfNeighgors(x, y, alive: false) == 0)
                {
                    matrix[x, y] = true;
                }
            }
        }

        return matrix;
    }
}
