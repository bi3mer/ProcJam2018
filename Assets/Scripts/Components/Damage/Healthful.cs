using UnityEngine;

public class Healthful : MonoBehaviour
{
    [SerializeField]
    private int maxHealth = 1;
    [SerializeField]
    private float health = 1;

    public float Health
    {
        get { return health; }
        set
        {
            value = Mathf.Clamp(value, 0, maxHealth);
            if (health != value)
            {
                health = value;
                NotifyListeners();
            }
        }
    }

    public int MaxHealth
    {
        get { return maxHealth; }
        set
        {
            if (maxHealth != value)
            {
                maxHealth = value;
                NotifyMaxListeners();
                Health = Mathf.Clamp(Health, 0, maxHealth);
            }
        }
    }

    private void Awake()
    {
        foreach (IHealthUpdateListener listener in gameObject.GetComponentsInChildren<IHealthUpdateListener>())
        {
            listener.Init(
                maxHealth: MaxHealth,
                health: Health);
        }
    }

    private void NotifyListeners()
    {
        foreach (IHealthUpdateListener listener in gameObject.GetComponentsInChildren<IHealthUpdateListener>())
        {
            listener.UpdateHealth(Health);
        }
    }

    private void NotifyMaxListeners()
    {
        foreach (IHealthUpdateListener listener in gameObject.GetComponentsInChildren<IHealthUpdateListener>())
        {
            listener.UpdateMaxHealth(
                newMaxHealth: MaxHealth,
                newHealth: Health);
        }
    }
}