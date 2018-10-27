using UnityEngine.SceneManagement;
using UnityEngine.Assertions;
using UnityEngine;

// @todo: make this a singleton
[RequireComponent(typeof(LevelGenerator))]
public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject player;

    private LevelGenerator levelGenerator;

    public int Level { get; private set; }
    public bool[,] Board => levelGenerator.RoomMatrix;

    private void Awake()
    {
        Level = PlayerPrefs.GetInt(PlayerPrefConstants.Level);
        levelGenerator = GetComponent<LevelGenerator>();

        Assert.IsNotNull(levelGenerator);
        Assert.IsNotNull(player);

        player.transform.position = new Vector3(0.5f, 0.5f);
    }

    private void Start()
    {
        levelGenerator.GenerateMaze();
    }

    public void LevelCompleted()
    {
        PlayerPrefs.SetInt(PlayerPrefConstants.Level, Level + 1);
        SceneManager.LoadScene(1);
    }
}
