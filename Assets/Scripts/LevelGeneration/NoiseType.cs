public enum NoiseType
{
    ConwayKeepAlive_1_Epoch,
    ConwayKeepAlive_2_Epochs,
    ConwayKeepAlive_5_Epochs,
    ConwayKeepAlive_10_Epochs,
    Conway_1_Epoch,
    Conway_2_Epochs,
    Conway_5_Epochs,
    Conway_10_Epochs,
    NoNoise,
    MAX
}

public static class NoiseExtensions
{
    public static BaseNoise ToClass(this NoiseType noise, bool[,] matrix, int width, int length)
    {
        switch (noise)
        {
            case NoiseType.ConwayKeepAlive_1_Epoch:
                return new ConwayKeepAlive(matrix, width, length, 1);
            case NoiseType.ConwayKeepAlive_2_Epochs:
                return new ConwayKeepAlive(matrix, width, length, 3);
            case NoiseType.ConwayKeepAlive_5_Epochs:
                return new ConwayKeepAlive(matrix, width, length, 5);
            case NoiseType.ConwayKeepAlive_10_Epochs:
                return new ConwayKeepAlive(matrix, width, length, 10);
            case NoiseType.Conway_1_Epoch:
                return new Conway(matrix, width, length, 1);
            case NoiseType.Conway_2_Epochs:
                return new Conway(matrix, width, length, 2);
            case NoiseType.Conway_5_Epochs:
                return new Conway(matrix, width, length, 5);
            case NoiseType.Conway_10_Epochs:
                return new Conway(matrix, width, length, 10);
            case NoiseType.NoNoise:
                return new NoNoise(matrix, width, length);
            case NoiseType.MAX:
            default:
                UnityEngine.Debug.LogError($"Invalid noise type {noise}");
                return null;
        }
    }
}