public struct IntVector2
{
    public int X;
    public int Y;

    public static IntVector2 Right => new IntVector2(1, 0);
    public static IntVector2 Left => new IntVector2(-1, 0);
    public static IntVector2 Down => new IntVector2(0, -1);
    public static IntVector2 Up => new IntVector2(0, 1);

    // Cantor's Paring Function
    public float Hashf => 0.5f * (X + Y)*(X + Y + 1) + Y;

    public IntVector2(int x, int y)
    {
        X = x;
        Y = y;
    }

    public bool Equals(IntVector2 vec)
    {
        return X == vec.X && Y == vec.Y;
    }
}