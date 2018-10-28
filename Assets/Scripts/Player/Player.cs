using UnityEngine.Assertions;
using UnityEngine;

[RequireComponent(typeof(PlayerHealthListener))]
[RequireComponent(typeof(Healthful))]
public class Player : Singleton<Player>
{
    private Healthful health;

    private void Awake()
    {
        health = GetComponent<Healthful>();
        Assert.IsNotNull(health);
    }

    private void Start()
    {
        int health = PlayerPrefs.GetInt(PlayerPrefConstants.Health);

        if (health != -1)
        {
            this.health.Health = health;
        }
    }

    public void UpdateStoredPlayerHealth()
    {
        PlayerPrefs.SetInt(PlayerPrefConstants.Health, health.Health);
    }
}
