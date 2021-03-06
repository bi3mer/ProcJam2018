﻿using UnityEngine;
using System;

[RequireComponent(typeof(ShotLifeTimeMod))]
[RequireComponent(typeof(BoxCollider2D))]
public class ShotLifeTimeCollider : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals(Tags.Player, StringComparison.Ordinal))
        {
            ShotLifeTimeMod mod = Player.instance.gameObject.AddComponent<ShotLifeTimeMod>();
            mod.LifeTimeIncrease = GetComponent<ShotLifeTimeMod>().LifeTimeIncrease;
            Destroy(gameObject);
        }
    }
}

