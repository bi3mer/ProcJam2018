using UnityEngine.SceneManagement;
using UnityEngine;
using System;

[RequireComponent(typeof(BoxCollider2D))]
public class Ladder : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals(Tags.Player, StringComparison.Ordinal))
        {
            PlayerPrefs.SetInt(PlayerPrefConstants.Level, GameManager.instance.Level + 1);
            Player.instance.UpdateStoredPlayerHealth();
            SceneManager.LoadScene(1);
        }
    }
}
