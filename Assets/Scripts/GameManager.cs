using UnityEngine.Assertions;
using UnityEngine;

[RequireComponent(typeof(LevelGenerator))]
public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject player;

    [SerializeField]
    private int level = 1;

    private LevelGenerator levelGenerator;

    public bool[,] Board => levelGenerator.RoomMatrix;

    private void Awake()
    {
        levelGenerator = GetComponent<LevelGenerator>();

        Assert.IsNotNull(levelGenerator);
        Assert.IsNotNull(player);

        player.transform.position = new Vector3(0.5f, 0.5f);
    }

    private void Start()
    {
        levelGenerator.GenerateMaze();
    }
}
