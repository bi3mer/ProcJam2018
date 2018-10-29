﻿using UnityEngine.Assertions;
using UnityEngine;

public class PlayerModFireRate : MonoBehaviour, IPlayerAttackMod
{
    public float FireRateMultiplier = -1;

    public void ModAttack(PlayerAttackMod attack)
    {
        Assert.IsNotNull(attack);

        if (FireRateMultiplier <= 0)
        {
            FireRateMultiplier = 1 +  Random.Range(0f, 0.1f);
        }

        attack.AttackRateMultiplier *= FireRateMultiplier;
    }
}
