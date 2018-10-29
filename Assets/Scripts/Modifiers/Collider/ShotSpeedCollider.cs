using UnityEngine;
using System;

[RequireComponent(typeof(ShotSpeedMod))]
[RequireComponent(typeof(BoxCollider2D))]
public class ShotSpeedCollider : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals(Tags.Player, StringComparison.Ordinal))
        {
            ShotSpeedMod mod = Player.instance.gameObject.AddComponent<ShotSpeedMod>();
            mod.Speed = GetComponent<ShotSpeedMod>().Speed;
            Destroy(gameObject);
        }
    }
}
