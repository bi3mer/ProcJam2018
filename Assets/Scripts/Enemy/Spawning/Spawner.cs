using System.Collections.Generic;
using UnityEngine.Assertions;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public const string EnemyResourceLocation = "Enemies";
    public const int MaxCost = 5;

    private Dictionary<int, GameObject[]> enemies = new Dictionary<int, GameObject[]>();
    private bool retrievedEnemies = false;

    [SerializeField]
    private int baseSpawnCount = 10;

    private void Awake()
    {
        Assert.IsTrue(baseSpawnCount > 0);
    }

    public void SpawnEnemies(bool[,] matrix, int width, int height, int level)
    {
        Assert.IsTrue(width > 0);
        Assert.IsTrue(height > 0);

        if (retrievedEnemies == false)
        {
            RetrieveEnemies();
        }

        int spawnCount = (int) Mathf.Ceil((baseSpawnCount * level) / 1.5f);
        HashSet<float> usedPositions = new HashSet<float>();

        // make it so enemies can't be with in 5 places of where the player
        // spawns
        int x;
        int y;
        for (x = 0; x < 5; ++x)
        {
            for (y = 0; y < 5; ++y)
            {
                usedPositions.Add(new IntVector2(x, y).Hashf);
            }
        }

        for (int i = 0; i < spawnCount; ++i)
        {
            int randX = Random.Range(0, width - 1);
            int randY = Random.Range(0, height - 1);

            // find a position nearby that isn't occupied
            bool found = false;
            for (x = 0; x < width; ++x)
            {
                for (y = 0; y < height; ++y)
                {
                    int testX = (randX + x) % width;
                    int testY = (randY + y) % height;

                    if (matrix[testX, testY])
                    {
                        if (usedPositions.Contains(new IntVector2(testX, testY).Hashf) == false)
                        {
                            found = true;
                            spawnCount = SpawnEnemy(spawnCount, testX, testY);
                            break;
                        }
                    }
                }

                if (found)
                {
                    break;
                }
            }

            if (found == false)
            {
                Debug.LogError("Not enough spaces on the map for the number of enemies :/");
                break;
            }
        }
    }

    private int SpawnEnemy(int spawnCount, int x, int y)
    {
        // choose which enemy cost to use
        int maxCost = spawnCount > MaxCost ? MaxCost : spawnCount;
        List<int> availableCosts = new List<int>();
        for (int i = 1; i <= maxCost; ++i)
        {
            availableCosts.Add(i);
        }

        availableCosts.Shuffle();

        // spawn the enemy
        for (int i = 0; i < availableCosts.Count; ++i)
        {
            if (enemies.ContainsKey(i))
            {
                int cost = availableCosts[i];
                GameObject[] enemyObjects = enemies[cost];
                if (enemyObjects != null && enemyObjects.Length > 0)
                {
                    spawnCount -= cost;
                    GameObject enemy = Instantiate(enemyObjects[Random.Range(0, enemyObjects.Length)]);
                    enemy.transform.position = new Vector3(x, y);
                }
            }
        }

        return spawnCount;
    }

    private void RetrieveEnemies()
    {
        for (int i = 1; i <= MaxCost; ++i)
        {
            enemies.Add(i, Resources.LoadAll<GameObject>($"{EnemyResourceLocation}/{i}/"));
        }
    }
}
