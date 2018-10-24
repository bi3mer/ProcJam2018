using UnityEngine.Assertions;
using UnityEngine;

public abstract class BaseEntity : MonoBehaviour
{
    [SerializeField]
    private int health = 10;

    public int Health
    {
        get
        {
            return health;
        }
    }

    protected void BaseEntityAwake()
    {
        Assert.IsTrue(health >= 0);
    }

    protected virtual void OnDeath()
    {
        Destroy(gameObject);
    }

    public virtual void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            OnDeath();
        }
    }
}
