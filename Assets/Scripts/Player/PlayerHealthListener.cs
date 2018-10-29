using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerHealthListener : MonoBehaviour, IHealthUpdateListener
{
    public void Init(int maxHealth, float health)
    {
    }

    public void UpdateHealth(float newHealth)
    {
        if (newHealth <= 0)
        {
            PlayerPrefs.SetInt(PlayerPrefConstants.Level, 1);
            PlayerPrefs.SetInt(PlayerPrefConstants.Health, -1);
            SceneManager.LoadScene(0);
        }
    }

    public void UpdateMaxHealth(int newMaxHealth, float newHealth)
    {
    }
}
