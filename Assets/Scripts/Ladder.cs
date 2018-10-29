using UnityEngine;
using System;

[RequireComponent(typeof(BoxCollider2D))]
public class Ladder : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals(Tags.Player, StringComparison.Ordinal))
        {
            GameManager.instance.LevelCompleted();
        }
    }
}
