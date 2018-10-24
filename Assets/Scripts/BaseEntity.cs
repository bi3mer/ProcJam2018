using UnityEngine.Assertions;
using UnityEngine;

public abstract class BaseEntity : MonoBehaviour
{
    private void Awake()
    {
        OnEntityAwake();
    }

    protected virtual void OnEntityAwake() { }
}
