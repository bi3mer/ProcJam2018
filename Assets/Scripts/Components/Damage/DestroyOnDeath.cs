using System.Collections;
using System.Collections.Generic;
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

    void IHealthUpdateListener.Init(int maxHealth, int health)
    {
        if (health == 0)
        {
            Die();
        }
    }

    void IHealthUpdateListener.UpdateHealth(int newHealth)
    {
        if (newHealth == 0)
        {
            Die();
        }
    }

    void IHealthUpdateListener.UpdateMaxHealth(int newMaxHealth, int newHealth)
    {
        //Don't care
    }
}
