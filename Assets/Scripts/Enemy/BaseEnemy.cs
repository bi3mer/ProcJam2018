using UnityEngine;

public abstract class BaseEnemy : BaseEntity
{
    sealed protected override void OnEntityAwake()
    {
        OnEnemyAwake();
    }

    protected virtual void OnEnemyAwake() { }
}
