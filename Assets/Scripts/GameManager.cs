using UnityEngine.SceneManagement;
using UnityEngine.Assertions;
using UnityEngine;

// @todo: make this a singleton
[RequireComponent(typeof(LevelGenerator))]
public class GameManager : Singleton<GameManager>
{
    [SerializeField]
    private GameObject player;

    [SerializeField]
    private GameObject ladder;

    private LevelGenerator levelGenerator;

    public int Level { get; private set; }
    public bool[,] Board => levelGenerator.RoomMatrix;

    private void Awake()
    {
        Level = PlayerPrefs.GetInt(PlayerPrefConstants.Level);
        levelGenerator = GetComponent<LevelGenerator>();

        Assert.IsNotNull(levelGenerator);
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
        player.transform.position = new Vector3(0.5f, 0.5f);
    }

    public void LevelCompleted()
    {
        PlayerPrefs.SetInt(PlayerPrefConstants.Level, Level + 1);
        SceneManager.LoadScene(1);
    }
}
