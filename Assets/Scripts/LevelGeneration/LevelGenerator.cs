using UnityEngine.Assertions;
using UnityEngine.Tilemaps;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField]
    private int maxWidth = 75;

    [SerializeField]
    private int maxHeight = 75;

    [SerializeField]
    private int baseWidth = 10;

    [SerializeField]
    private int baseHeight = 10;

    [SerializeField]
    private NoiseType noise;

    [SerializeField]
    private Tilemap wallMap = null;

    [SerializeField]
    private RuleTile wallTile = null;

    [SerializeField]
    private bool removeNoNeighborDeadCells = true;

    public bool[,] RoomMatrix { get; private set; }
    private int width;
    private int height;

    private void Awake()
    {
        Assert.IsNotNull(wallMap);
        Assert.IsNotNull(wallTile);

        Assert.IsTrue(baseWidth > 1);
        Assert.IsTrue(baseHeight > 1);
    }

    public void GenerateMaze ()
    {
        int multiplier = (int) Mathf.Ceil((2f * GameManager.instance.Level) / 8f);
        width = multiplier * baseWidth;
        height = multiplier * baseHeight;

        width = width > maxWidth ? maxWidth : width;
        height = height > maxHeight ? maxHeight : height;

        RoomMatrixGenerator rmg = new RoomMatrixGenerator(width, height);
        RoomMatrix = rmg.GenerateRoomMatrix();
        RoomMatrix = noise.ToClass(RoomMatrix, width, height)?.ApplyNoise();

        if (removeNoNeighborDeadCells)
        {
            RoomMatrix = new RemoveNoNeighborAliveCells(RoomMatrix, width, height).ApplyNoise();
        }

        int x;
        int y;
        
        for (x = 0; x < width; ++x)
        {
            for (y = 0; y < height; ++y)
            {
                if (RoomMatrix[x, y] == false)
                {
                    wallMap.SetTile(new Vector3Int(x, y, 0), wallTile);
                }
            }
        }

        for (x = -1; x <= width; ++x)
        {
            wallMap.SetTile(new Vector3Int(x, -1, 0), wallTile);
            wallMap.SetTile(new Vector3Int(x, height , 0), wallTile);
        }

        for (y = -1; y <= height; ++y)
        {
            wallMap.SetTile(new Vector3Int(-1, y, 0), wallTile);
            wallMap.SetTile(new Vector3Int(width, y, 0), wallTile);
        }
    }
}
