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
            Player.instance.AddShotMod(GetComponent<ShotSpeedMod>());
            Destroy(gameObject);
        }
    }
}
