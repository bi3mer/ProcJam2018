using UnityEngine.Assertions;
using UnityEngine;
using UnityEngine.Tilemaps;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField]
    private int width = 10;

    [SerializeField]
    private int height = 10;

    [SerializeField]
    private NoiseType noise;

    [SerializeField]
    private GameObject player;

    [SerializeField]
    private Tilemap wallMap = null;

    [SerializeField]
    private RuleTile wallTile = null;

    [SerializeField]
    private bool removeNoNeighborDeadCells = true;

    private void Awake()
    {
        Assert.IsNotNull(player);
        Assert.IsNotNull(wallMap);
        Assert.IsNotNull(wallTile);

        Assert.IsTrue(width > 1);
        Assert.IsTrue(height > 1);
    }

    private void Start()
    {
        GenerateMaze();
        Instantiate(player);
        player.transform.position = new Vector2(0.5f, 0.5f);
    }

    private void GenerateMaze ()
    {
        RoomMatrixGenerator rmg = new RoomMatrixGenerator(width, height);
        bool[,] roomMatrix = rmg.GenerateRoomMatrix();
        roomMatrix = noise.ToClass(roomMatrix, width, height)?.ApplyNoise();

        if (removeNoNeighborDeadCells)
        {
            roomMatrix = new RemoveNoNeighborAliveCells(roomMatrix, width, height).ApplyNoise();
        }
        
        for (int x = 0; x < width; ++x)
        {
            for (int y = 0; y < height; ++y)
            {
                if (roomMatrix[x, y] == false)
                {
                    wallMap.SetTile(new Vector3Int(x, y, 0), wallTile);
                }
            }
        }
    }
}
