public class NoNoise : BaseNoise
{
    public NoNoise(bool[,] matrix, int width, int height) : base(matrix, width, height)
    {
    }

    public override bool[,] ApplyNoise()
    {
        return matrix;
    }
}
