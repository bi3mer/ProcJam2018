using UnityEngine.Assertions;
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
    private GameObject alive;

    [SerializeField]
    private GameObject dead;

    private void Awake()
    {
        Assert.IsNotNull(alive);
        Assert.IsNotNull(dead);
    }

    private void Start()
    {
        GenerateMaze();
    }

    private void GenerateMaze ()
    {
        RoomMatrixGenerator rmg = new RoomMatrixGenerator(width, height);
        bool[,] roomMatrix = rmg.GenerateRoomMatrix();
        roomMatrix = noise.ToClass(roomMatrix, width, height)?.ApplyNoise();

        for (int x = 0; x < width; ++x)
        {
            for (int y = 0; y < height; ++y)
            {
                GameObject obj;
                if (roomMatrix[x, y])
                {
                    obj = Instantiate(alive);
                }
                else
                {
                    obj = Instantiate(dead);
                }

                obj.transform.position = new Vector2(x, y);
            }
        }
    }
}
