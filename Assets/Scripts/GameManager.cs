using UnityEngine.SceneManagement;
using System.Collections.Generic;
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
        levelGenerator.GenerateMaze(Level);

        int width = Board.GetLength(0);
        int height = Board.GetLength(1);

        SpawnLadder(width, height);
        spawner.SpawnEnemies(Board, width, height, Level);
        player.transform.position = new Vector3(0.5f, 0.5f);
    }

    private void SpawnLadder(int width, int height)
    {
        List<IntVector2> positions = new List<IntVector2>();
        int endX = width - 1;
        int endY = height - 1;

        if (Board[endX, endY])
        {
            positions.Add(new IntVector2(endX, endY));
        }

        if (Board[0, endY])
        {
            positions.Add(new IntVector2(0, endY));
        }

        if (Board[endX, 0])
        {
            positions.Add(new IntVector2(endX, 0));
        }

        IntVector2 spawnPos = positions[Random.Range(0, positions.Count)];

        GameObject ladderObj = Instantiate(ladder);
        ladderObj.transform.position = new Vector3(spawnPos.X +  0.5f, spawnPos.Y + 0.5f);
        ladderObj.gameObject.SetActive(true);
    }

    public void LevelCompleted()
    {
        Player.instance.UpdateStaticData();
        PlayerPrefs.SetInt(PlayerPrefConstants.Level, Level + 1);
        SceneManager.LoadScene(1);
    }
}
