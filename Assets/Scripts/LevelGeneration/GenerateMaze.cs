using UnityEngine.Assertions;
using UnityEngine;

public class GenerateMaze : MonoBehaviour
{
    [SerializeField]
    private int width = 10;

    [SerializeField]
    private int height = 10;

    [SerializeField]
    private GameObject alive;

    [SerializeField]
    private GameObject dead;

    [SerializeField]
    [Range(0, 1)]
    private float percentageToIgnoreNeighbor = 0.5f;

    private void Awake()
    {
        Assert.IsNotNull(alive);
        Assert.IsNotNull(dead);
    }

    private void Start ()
    {
        RoomMatrixGenerator rmg = new RoomMatrixGenerator(width, height, percentageToIgnoreNeighbor);
        bool[,] roomMatrix = rmg.GenerateRoomMatrix();

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
