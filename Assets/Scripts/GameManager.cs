using UnityEngine.SceneManagement;
using UnityEngine.Assertions;
using UnityEngine;

[RequireComponent(typeof(LevelGenerator))]
[RequireComponent(typeof(Spawner))]
public class GameManager : Singleton<GameManager>
{
    [SerializeField]
    private GameObject player;

    [SerializeField]
    private GameObject ladder;

    private LevelGenerator levelGenerator;
    private Spawner spawner;

    public int Level { get; private set; }
    public bool[,] Board => levelGenerator.RoomMatrix;

    private void Awake()
    {
        Level = PlayerPrefs.GetInt(PlayerPrefConstants.Level);
        levelGenerator = GetComponent<LevelGenerator>();
        spawner = GetComponent<Spawner>();

        Assert.IsNotNull(levelGenerator);
        Assert.IsNotNull(spawner);
        Assert.IsNotNull(player);
        Assert.IsNotNull(ladder);
    }

    private void Start()
    {
        levelGenerator.GenerateMaze();

        GameObject ladderObj = Instantiate(ladder);
        int width = Board.GetLength(0);
        int height = Board.GetLength(1);
        ladderObj.transform.position = new Vector3(width - 0.5f, height - 0.5f);
        ladderObj.gameObject.SetActive(true);

        spawner.SpawnEnemies(Board, width, height, Level);
        player.transform.position = new Vector3(0.5f, 0.5f);
    }

    public void LevelCompleted()
    {
        PlayerPrefs.SetInt(PlayerPrefConstants.Level, Level + 1);
        SceneManager.LoadScene(1);
    }
}
