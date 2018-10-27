using UnityEngine.Assertions;
using UnityEngine.Tilemaps;
using UnityEngine;

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

    public bool[,] RoomMatrix { get; private set; }

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
        player.transform.position = new Vector2(0.5f, 0.5f);
    }

    private void GenerateMaze ()
    {
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

    /* Dead code to generate a visualized path from bottom left to top right of the board
    public void OnDrawGizmos()
    {
        if (Application.isPlaying)
        {
            List<IntVector2> path = AStar.GetPath(RoomMatrix, new IntVector2(0, 0), new IntVector2(width - 1, height - 1), Heuristics.Manhattan);
            Gizmos.color = new Color(1, 0, 0, 0.7f);

            for (int i = 0; i < path.Count; ++i)
            {
                Gizmos.DrawCube(new Vector3(path[i].X, path[i].Y), Vector3.one);
            }
        }
    }
    */
}
