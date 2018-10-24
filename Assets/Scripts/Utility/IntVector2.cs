public struct IntVector2
{
    public int X;
    public int Y;

    public static IntVector2 Right => new IntVector2(1, 0);
    public static IntVector2 Left => new IntVector2(-1, 0);
    public static IntVector2 Down => new IntVector2(0, -1);
    public static IntVector2 Up => new IntVector2(0, 1);

    public IntVector2(int x, int y)
    {
        X = x;
        Y = y;
    }
}