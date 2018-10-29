using System.Collections.Generic;
using UnityEngine.Assertions;
using UnityEngine;

[RequireComponent(typeof(PlayerHealthListener))]
[RequireComponent(typeof(Healthful))]
public class Player : Singleton<Player>
{
    private Healthful health;

    public List<IShotMod> ShotMods
    {
        get;
        private set;
    }

    private void Awake()
    {
        ShotMods = new List<IShotMod>();

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

    public void AddShotMod(IShotMod mod)
    {
        Assert.IsNotNull(mod);
        ShotMods.Add(mod);
    }
}
