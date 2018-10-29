using UnityEngine;

public class DestroyOnDeath : MonoBehaviour, IHealthUpdateListener
{
    private void Die()
    {
        foreach (IDestructionListener listener in gameObject.GetComponentsInChildren<IDestructionListener>())
        {
            listener.NotifyDestruction(causedByDamage: true);
        }

        Destroy(gameObject);
    }

    void IHealthUpdateListener.Init(int maxHealth, float health)
    {
        if (health == 0)
        {
            Die();
        }
    }

    void IHealthUpdateListener.UpdateHealth(float newHealth)
    {
        if (newHealth == 0)
        {
            Die();
        }
    }

    void IHealthUpdateListener.UpdateMaxHealth(int newMaxHealth, float newHealth)
    {
        //Don't care
    }
}
