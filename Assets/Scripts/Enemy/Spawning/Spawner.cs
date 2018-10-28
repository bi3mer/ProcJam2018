using System.Collections.Generic;
using UnityEngine.Assertions;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public const string EnemyResourceLocation = "Enemies";
    public const string HardFolder = "Hard";
    public const string MediumFolder = "Medium";
    public const string EasyFolder = "Easy";

    private GameObject[] hardEnemies;
    private GameObject[] mediumEnemies;
    private GameObject[] easyEnemies;
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

        int spawnCount = (int) Mathf.Ceil((baseSpawnCount * 4f) / 1.5f);
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
                            GameObject enemey = Instantiate(easyEnemies[0]);
                            enemey.transform.position = new Vector3(testX, testY);
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

    private void RetrieveEnemies()
    {
        hardEnemies = Resources.LoadAll<GameObject>($"{EnemyResourceLocation}/{HardFolder}");
        mediumEnemies = Resources.LoadAll<GameObject>($"{EnemyResourceLocation}/{MediumFolder}");
        easyEnemies = Resources.LoadAll<GameObject>($"{EnemyResourceLocation}/{EasyFolder}");
    }
}
