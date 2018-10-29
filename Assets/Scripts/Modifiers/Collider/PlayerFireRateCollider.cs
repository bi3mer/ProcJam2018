using UnityEngine;
using System;

[RequireComponent(typeof(PlayerModFireRate))]
[RequireComponent(typeof(BoxCollider2D))]
public class PlayerFireRateCollider : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals(Tags.Player, StringComparison.Ordinal))
        {
            PlayerModFireRate mod = Player.instance.gameObject.AddComponent<PlayerModFireRate>();
            mod.FireRateMultiplier = GetComponent<PlayerModFireRate>().FireRateMultiplier;
            Destroy(gameObject);
        }
    }
}
