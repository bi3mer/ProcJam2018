using UnityEngine;
using System;

[RequireComponent(typeof(PlayerModSpeed))]
[RequireComponent(typeof(BoxCollider2D))]
public class PlayerSpeedCollider : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals(Tags.Player, StringComparison.Ordinal))
        {
            PlayerModSpeed mod = Player.instance.gameObject.AddComponent<PlayerModSpeed>();
            mod.SpeedAdd = GetComponent<PlayerModSpeed>().SpeedAdd;
            Destroy(gameObject);
        }
    }
}
