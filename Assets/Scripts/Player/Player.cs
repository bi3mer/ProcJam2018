using System.Collections.Generic;
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
        ReadStaticData();
        int health = PlayerPrefs.GetInt(PlayerPrefConstants.Health);

        if (health != -1)
        {
            this.health.Health = health;
        }
    }

    public void UpdateStaticData()
    {
        PlayerAttackMod attackMod = new PlayerAttackMod();
        IPlayerAttackMod[] mods = GetComponents<IPlayerAttackMod>();
        int count = mods.Length;
        for (int i = 0; i < count; ++i)
        {
            mods[i].ModAttack(attackMod);
        }

        IPlayerMovementMod[] movementMods = GetComponents<IPlayerMovementMod>();
        count = movementMods.Length;
        PlayerMovementMod movementMod = new PlayerMovementMod();

        for (int i = 0; i < count; ++i)
        {
            movementMods[i].ModifyPlayerMovement(movementMod);
        }

        IShotMod[] shotMods = GetComponents<IShotMod>();
        count = shotMods.Length;
        ShotDataStructure shot = new ShotDataStructure();
        for (int i = 0; i < count; ++i)
        {
            shotMods[i].ModifyShot(shot);
        }

        PlayerPrefs.SetInt(PlayerPrefConstants.Health, (int)health.Health);
        PlayerPrefs.SetFloat(PlayerPrefConstants.ShotDamage, shot.Damage);
        PlayerPrefs.SetFloat(PlayerPrefConstants.ShotSpeed, shot.Speed);
        PlayerPrefs.SetFloat(PlayerPrefConstants.ShotLifeTime, shot.LifeTime);
        PlayerPrefs.SetFloat(PlayerPrefConstants.PlayerSpeed, movementMod.MovementAdder);
        PlayerPrefs.SetFloat(PlayerPrefConstants.PlayerFireRate, attackMod.AttackRateMultiplier);
    }

    public void ReadStaticData()
    {
        float shotDamage = PlayerPrefs.GetFloat(PlayerPrefConstants.ShotDamage);
        float shotSpeed = PlayerPrefs.GetFloat(PlayerPrefConstants.ShotSpeed);
        float shotLifeTime =  PlayerPrefs.GetFloat(PlayerPrefConstants.ShotLifeTime);
        float playerSpeed = PlayerPrefs.GetFloat(PlayerPrefConstants.PlayerSpeed);
        float playerFireRate = PlayerPrefs.GetFloat(PlayerPrefConstants.PlayerFireRate);

        if(shotDamage > 0)
        {
            ShotDamageMod shotDmgMod = gameObject.AddComponent<ShotDamageMod>();
            shotDmgMod.DamageIncrease = shotDamage;
        }

        if (shotSpeed > 0)
        {
            ShotSpeedMod shotSpeedMod = gameObject.AddComponent<ShotSpeedMod>();
            shotSpeedMod.Speed = shotSpeed;
        }

        if (shotLifeTime > 0)
        {
            ShotLifeTimeMod shotLifeTimeMod = gameObject.AddComponent<ShotLifeTimeMod>();
            shotLifeTimeMod.LifeTimeIncrease = shotLifeTime;
        }

        if (playerSpeed > 0)
        {
            PlayerModSpeed speedMod = gameObject.AddComponent<PlayerModSpeed>();
            speedMod.SpeedAdd = playerSpeed;
        }

        if (playerFireRate > 0)
        {
            PlayerModFireRate fireRateMod = gameObject.AddComponent<PlayerModFireRate>();
            fireRateMod.FireRateMultiplier = playerFireRate;
        }
    }
}
