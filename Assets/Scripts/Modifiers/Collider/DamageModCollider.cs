using UnityEngine;
using System;

[RequireComponent(typeof(ShotDamageMod))]
[RequireComponent(typeof(BoxCollider2D))]
public class DamageModCollider : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals(Tags.Player, StringComparison.Ordinal))
        {
            ShotDamageMod mod = Player.instance.gameObject.AddComponent<ShotDamageMod>();
            mod.DamageIncrease = GetComponent<ShotDamageMod>().DamageIncrease;
            Destroy(gameObject);
        }
    }
}
